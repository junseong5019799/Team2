using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class WorkOrderPopupForm : WinMSFactory.PopUpDialogForm
	{
		EmployeeVO employeeVO;
		int work_order_no;
		WorkOrderService workOrderService = new WorkOrderService();
		DataTable toDoesDt;

		public WorkOrderPopupForm(EmployeeVO employeeVO, int work_order_no = 0)
		{
			try
			{
				InitializeComponent();
				this.employeeVO = employeeVO;
				this.work_order_no = work_order_no;
				this.Text = work_order_no > 0 ? "작업 지시 수정" : "작업 지시 등록";
				cboFactory.ComboBinding(new FactoryService().GetFactories(this.employeeVO.GetCorporationID()), "FACTORY_NAME", "FACTORY_ID", "선택", 0);
				cboLine.ComboBinding("선택", 0);
				cboProcess.ComboBinding("선택", 0);
				cboProduct.ComboBinding(new ProductService().GetProducts(), "PRODUCT_NAME", "PRODUCT_ID", "선택", 0);
				
				if (work_order_no > 0)
				{
					DateTime now = DateTime.Now;
					WorkOrderVO workOrderVO = workOrderService.GetWorkOrder(work_order_no);
					cboFactory.SelectedValue = workOrderVO.Factory_id;
					cboLine.SelectedValue = workOrderVO.Line_id;
					cboProcess.SelectedValue = workOrderVO.Process_id;
					cboWorker.SelectedValue = workOrderVO.Worker_id;
					cboProduct.SelectedValue = workOrderVO.Product_id;
					dtpWorkDate.Value = workOrderVO.Work_order_date;
					dtpWorkStartTime.Value = GetDateTime(workOrderVO.Work_start_time);
					dtpWorkFinishTime.Value = GetDateTime(workOrderVO.Work_finish_time);
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void WorkOrderPopupForm_Load(object sender, EventArgs e)
		{
			dataGridViewControl1.headerCheckBox.Visible = false;
			dataGridViewControl1.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
			dataGridViewControl1.ColumnHeadersHeight = 30;

			dataGridViewControl1.AddNewColumns("주문번호", "RELEASE_NO", 80, false);
			dataGridViewControl1.AddNewColumns("순서", "RELEASE_SEQ", 70, false);
			dataGridViewControl1.AddNewColumns("품목", "PRODUCT_ID", 80, false);
			dataGridViewControl1.AddNewColumns("품명", "PRODUCT_NAME", 120, true);
			dataGridViewControl1.AddNewColumns("발주 수량", "ORDER_REQUEST_QUANTITY", 80, true);
			dataGridViewControl1.AddNewColumns("최대 생산량", "MAX_QTY", 100, true);
			dataGridViewControl1.AddNewColumns("주문일", "RELEASE_PLAN_DATE", 100, true);

			toDoesDt = workOrderService.GetToDoes();
			dataGridViewControl1.DataSource = toDoesDt;
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			try
			{
				if (cboFactory.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("공장을 선택해주세요.");
					return;
				}
				if (cboLine.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("라인을 선택해주세요.");
					return;
				}
				if (cboProcess.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("공정을 선택해주세요.");
					return;
				}
				if (cboWorker.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("작업자를 선택해주세요.");
					return;
				}
				if (cboProduct.SelectedValue.ToInt() < 1)
				{
					MessageBox.Show("품목을 선택해주세요.");
					return;
				}

				WorkOrderVO workOrderVO = new WorkOrderVO
				{
					Work_order_no = work_order_no,
					Worker_id = cboWorker.SelectedValue.ToInt(),
					Product_id = cboProduct.SelectedValue.ToInt(),
					Work_date = dtpWorkDate.Value,
					Work_start_time = dtpWorkStartTime.Value.ToString("HH:mm:00"),
					Work_finish_time = dtpWorkStartTime.Value.ToString("HH:mm:00"),
					Regist_employee = employeeVO.Employee_id
				};

				if (workOrderService.SaveWorkOrder(workOrderVO))
				{
					MessageBox.Show("정상적으로 저장되었습니다.");
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int factory_id = cboFactory.SelectedValue.ToInt();

			if (factory_id > 0)
				cboLine.ComboBinding(new LineService().GetLines(factory_id), "LINE_NAME", "LINE_ID", "선택", 0);
			else
				cboLine.ComboBinding("선택", 0);
		}

		private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			int line_id = cboLine.SelectedValue.ToInt();

			if (line_id > 0)
				cboProcess.ComboBinding(new ProcessService().GetProcesses(line_id), "PROCESS_NAME", "PROCESS_ID", "선택", 0);
			else
				cboProcess.ComboBinding("선택", 0);
		}

		private void cboProcess_SelectedIndexChanged(object sender, EventArgs e)
		{
			int process_id = cboProcess.SelectedValue.ToInt();

			if (process_id > 0)
				cboWorker.ComboBinding(new ProcessWorkerService().GetProcessWorkers(process_id), "EMPLOYEE_NAME", "WORKER_ID", "선택", 0);
			else
				cboWorker.ComboBinding("선택", 0);
		}

		private DateTime GetDateTime(string time)
		{
			return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, time.Substring(0, time.LastIndexOf(":") - 1).ToInt(), time.Substring(time.LastIndexOf(":") + 1).ToInt(), 0);
		}

		private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			DGVChkClear();
			int product_id = cboProduct.SelectedValue.ToInt();
			DataTable dt = toDoesDt;

			if (product_id > 0)
			{
				var v = (from item in toDoesDt.AsEnumerable()
						 where item["PRODUCT_ID"].ToInt() == product_id
						 select item);

				dt = v.Count() > 0 ? v.CopyToDataTable() : null;
			}
			
			dataGridViewControl1.DataSource = dt;
		}

		private void DGVChkClear()
		{
			foreach (DataGridViewRow dgvr in dataGridViewControl1.Rows)
			{
				((DataGridViewCheckBoxCell)dgvr.Cells["chk"]).Value = false;
			}
		}

		private void dataGridViewControl1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DGVChkClear();
		}
	}
}
