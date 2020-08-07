using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinMSFactory
{
	public partial class WorkOrderForm : WinMSFactory.ListForm
	{
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
				dataGridViewControl1.AddNewColumns("작업지시 번호", "", 100, false);
				dataGridViewControl1.AddNewColumns("지시일자", "", 100);
				dataGridViewControl1.AddNewColumns("작업일자", "", 100);
				dataGridViewControl1.AddNewColumns("라인명칭", "", 100);
				dataGridViewControl1.AddNewColumns("공정명칭", "", 100);
				dataGridViewControl1.AddNewColumns("작업자", "", 100);
				dataGridViewControl1.AddNewColumns("품목명칭", "", 100);
				dataGridViewControl1.AddNewColumns("지시수량", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("양품수량", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("불량수량", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
				dataGridViewControl1.AddNewColumns("작업지시 상태", "", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);

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
		}


		//private void Search(object sender, EventArgs e)
		//{
		//	if (((MainForm)this.MdiParent).ActiveMdiChild == this)
		//	{
		//		dt.CaseSensitive = false;
		//		DataView dv = dt.DefaultView;
		//		string search = txtSearch.Text.Trim();

		//		if (search.Length > 0)
		//			dv.RowFilter = $"APP_NAME LIKE '%{search}%'";
		//		else
		//			dv.RowFilter = "";
		//	}
		//}

		//private void Add(object sender, EventArgs e)
		//{
		//	if (((MainForm)this.MdiParent).ActiveMdiChild == this)
		//	{
		//		EmployeeVO employeeVO = this.GetEmployee();
		//		ApplicationPopupForm frm = new ApplicationPopupForm(employeeVO);

		//		if (frm.ShowDialog() == DialogResult.OK)
		//		{
		//			LoadData();
		//		}
		//	}
		//}

		//private void Delete(object sender, EventArgs e)
		//{
		//	if (((MainForm)this.MdiParent).ActiveMdiChild == this)
		//	{
		//		try
		//		{
		//			string app_id = dataGridViewControl1.GetCheckIDs("APP_ID");

		//			if (string.IsNullOrEmpty(app_id))
		//				return;

		//			if (applicationService.DeleteApplication(app_id))
		//			{
		//				MessageBox.Show("정상적으로 삭제되었습니다.");
		//				LoadData();
		//			}
		//		}
		//		catch (Exception err)
		//		{
		//			MessageBox.Show(err.Message);
		//		}
		//	}
		//}

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
		}
	}
}
