using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactoryPOP
{
	public partial class PopForm : Form
	{
		public PopForm()
		{
			InitializeComponent();
		}

		private void PopForm_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.MultiSelect = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.RowHeadersVisible = false;

			// 작업지시 번호, 품명, 작업자, 지시량, 양품수, 불량수
			dataGridView1.AddNewColumns("작업지시 번호", "", 150);
			dataGridView1.AddNewColumns("품명", "", 200);
			dataGridView1.AddNewColumns("작업자", "", 150);
			dataGridView1.AddNewColumns("지시량", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
			dataGridView1.AddNewColumns("양품수", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
			dataGridView1.AddNewColumns("불량수", "", 100, true, true, false, DataGridViewContentAlignment.MiddleRight);
		}
	}
}
