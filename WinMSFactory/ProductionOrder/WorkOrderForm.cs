using DevExpress.XtraRichEdit.Commands;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class WorkOrderForm : WinMSFactory.ListForm
	{
		WorkOrderService workOrderService = new WorkOrderService();
		DataTable dt;

		public WorkOrderForm()
		{
			InitializeComponent();
		}

		private void WorkOrderForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("작업지시 번호", "WORK_ORDER_NO", 100, false);
				dataGridViewControl1.AddNewColumns("지시일자", "WORK_ORDER_DATE", 100);
				dataGridViewControl1.AddNewColumns("작업일자", "WORK_DATE", 100);
				dataGridViewControl1.AddNewColumns("공장명칭", "FACTORY_NAME", 100);
				dataGridViewControl1.AddNewColumns("라인명칭", "LINE_NAME", 100);
				dataGridViewControl1.AddNewColumns("공정명칭", "PROCESS_NAME", 100);
				dataGridViewControl1.AddNewColumns("작업자", "EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("품목명칭", "PRODUCT_NAME", 100);
				dataGridViewControl1.AddNewColumns("지시수량", "QTY", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("양품수량", "RESULT_QUANTITY", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("불량수량", "DEFECTIVE_QUANTITY", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("작업지시 상태", "WORK_ORDER_STATUS", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);


				cboFactory.ComboBinding(new FactoryService().GetFactories(this.GetEmployee().GetCorporationID()), "FACTORY_NAME", "FACTORY_ID", "전체", 0);
				cboLine.ComboBinding("전체", 0);
				cboProcess.ComboBinding("전체", 0);
				cboProduct.ComboBinding(new ProductService().GetProducts(), "PRODUCT_NAME", "PRODUCT_ID", "전체", 0);

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadData()
		{
			WorkOrderClear();
			dt = workOrderService.GetAllWorkOrders();
			dataGridViewControl1.DataSource = dt;			
		}


		private void Search(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				WorkOrderVO workOrderVO = new WorkOrderVO
				{
					Line_id = cboLine.SelectedValue.ToInt(),
					Process_id = cboLine.SelectedValue.ToInt(),
					Product_id = cboProduct.SelectedValue.ToInt(),
					SearchFromDate = fromToDateControl1.From.ToShortDateString(),
					SearchToDate = fromToDateControl1.To.ToShortDateString(),
					SearchWord = txtSearch.Text.Trim()
				};
				dt = workOrderService.GetAllWorkOrders(workOrderVO);
				dataGridViewControl1.DataSource = dt;
			}
		}

		private void Add(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				EmployeeVO employeeVO = this.GetEmployee();
				WorkOrderPopupForm frm = new WorkOrderPopupForm(employeeVO);

				if (frm.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void Delete(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				try
				{
					string work_order_no = dataGridViewControl1.GetCheckIDs("APP_ID");

					if (string.IsNullOrEmpty(work_order_no))
						return;

					if (workOrderService.DeleteWorkOrder(work_order_no))
					{
						MessageBox.Show("정상적으로 삭제되었습니다.");
						LoadData();
					}
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
		}

		private void Clear(object sender, EventArgs e)
		{
			if (((MainForm)this.MdiParent).ActiveMdiChild == this)
			{
				LoadData();
			}
		}

		private void WorkOrderClear()
		{
			this.Clear();
			fromToDateControl1.From = DateTime.Now.AddDays(-7);
		}

		private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int factory_id = cboFactory.SelectedValue.ToInt();

			if (factory_id > 0)
				cboLine.ComboBinding(new LineService().GetLines(factory_id), "LINE_NAME", "LINE_ID", "전체", 0);
			else
				cboLine.ComboBinding("전체", 0);
			
		}

		private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			int line_id = cboLine.SelectedValue.ToInt();

			if (line_id > 0)
				cboProcess.ComboBinding(new ProcessService().GetProcesses(line_id), "PROCESS_NAME", "PROCESS_ID", "선택", 0);
			else
				cboProcess.ComboBinding("선택", 0);
		}

		private void dataGridViewControl1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			foreach (DataGridViewRow dgvr in dataGridViewControl1.Rows)
			{
				if (DateTime.TryParse(dgvr.Cells["WORK_DATE"].Value.ToString(), out DateTime workDate) && DateTime.Compare(workDate, DateTime.Now) < 0)
				{
					dgvr.Cells["chk"].ReadOnly = true;
				}
			}
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			DataGridViewRow dgvr = dataGridViewControl1.Rows[e.RowIndex];

			if ((Convert.ToDateTime(dgvr.Cells["WORK_DATE"].Value) - DateTime.Now).Days > 0)
			{
				EmployeeVO employeeVO = this.GetEmployee();
				WorkOrderPopupForm frm = new WorkOrderPopupForm(employeeVO, dgvr.Cells["WORK_ORDER_NO"].Value.ToInt());

				if (frm.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
	}
}
