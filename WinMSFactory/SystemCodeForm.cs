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
	public partial class SystemCodeForm : ListListForm
	{
		private CommonCodeService commonCodeService = new CommonCodeService();
		private List<DataRow> commonGroupList = new List<DataRow>();
		private List<DataRow> commonList = new List<DataRow>();
		private DataTable commonGroupDt;
		private DataTable commonDt;

		public SystemCodeForm()
		{
			InitializeComponent();
		}

		private void SystemCodeForm_Load(object sender, EventArgs e)
		{
			LoadData();

			dataGridViewControl1.AddNewColumns("분류코드", "Sort_id", 100, true, false);
			dataGridViewControl1.AddNewColumns("분류명", "Sort_name", 100, true, false);
			dataGridViewControl1.AddNewColumns("비고", "Note", 100, true, false);

			dataGridViewControl2.AddNewComCol("분류명", "Sort_id", commonGroupDt, "Sort_name", "Sort_id");
			dataGridViewControl2.AddNewColumns("코드", "Common_id", 100, true, false);
			dataGridViewControl2.AddNewColumns("코드명", "Common_name", 100, true, false);
			dataGridViewControl2.AddNewColumns("비고", "Note", 100, true, false);
		}

		private void LoadData()
		{
			DataSet ds = commonCodeService.GetCommonCodes();
			commonGroupDt = ds.Tables[0];
			commonDt = ds.Tables[1];
			dataGridViewControl1.DataSource = commonGroupDt;
			dataGridViewControl2.DataSource = commonDt;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dt = (DataTable)dataGridViewControl2.DataSource;
			DataRow dr = dt.NewRow();

			dt.Rows.Add(dr);
			commonGroupList.Add(dr);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridViewControl1.SelectedRows.Count != 1 || dataGridViewControl1.SelectedRows[0].Index < 0)
				return;
			
			
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{

		}

		private void dataGridViewControl1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
