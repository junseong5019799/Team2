using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactoryPOP.Services;

namespace WinMSFactoryPOP
{
	public partial class PopForm : Form
	{
		string taskID;

		public PopForm()
		{
			InitializeComponent();
		}

		private void PopForm_Load(object sender, EventArgs e)
		{
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.MultiSelect = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowTemplate.Height = 100;

			// 작업지시 번호, 품명, 작업자, 지시량, 양품수, 불량수
			dataGridView1.AddNewColumns("작업지시 번호", "Work_order_no", 150);
			dataGridView1.AddNewColumns("품명", "Product_name", 250);
			dataGridView1.AddNewColumns("작업자", "Employee_name", 200);
			dataGridView1.AddNewColumns("지시량", "Qty", 120, true, true, false, DataGridViewContentAlignment.MiddleRight);
			dataGridView1.AddNewColumns("양품수", "ResultQty", 120, true, true, false, DataGridViewContentAlignment.MiddleRight);
			dataGridView1.AddNewColumns("불량수", "BadQty", 120, true, true, false, DataGridViewContentAlignment.MiddleRight);

			var popList = (this.MdiParent as MainForm).popList;

			dataGridView1.DataSource = popList;

			if (popList.Count > 0)
			{ 
				foreach (var pop in popList)
				{
					pop.Frm.ReadData += ReadDataDisplay;
				}
			}
		}

		public void ReadDataDisplay(object sender, ReadDataEventAgrs e)
		{
			string[] datas = e.Data.Split('|');

			if (datas.Length < 5) return;

			MainForm mf = this.MdiParent as MainForm;
			var popList = mf.popList;

			if (popList.Count > 0)
			{
				foreach (var pop in popList)
				{
					int resultQty = int.Parse(datas[3]);
					int badQty = int.Parse(datas[4]);

					if (pop.TaskID.Replace("task", "").TrimStart('0') == datas[1])
					{
						resultQty = pop.ResultQty += resultQty;
						badQty = pop.BadQty += badQty;
						this.Invoke((MethodInvoker)(() =>
						{
							dataGridView1.DataSource = null;
							dataGridView1.DataSource = popList;
						}));

						//if (pop.Qty <= pop.ResultQty)
						//{
						//	this.Invoke((MethodInvoker)(() => mf.Stop(pop.Worker, pop.Frm, pop.Task_proc_id)));
						//}
					}

					if (!string.IsNullOrEmpty(taskID) && taskID.Replace("task", "").TrimStart('0') == datas[1])
					{
						this.Invoke((MethodInvoker)(() =>
						{
							label10.Text = (pop.Qty - resultQty).ToString();
							label14.Text = resultQty.ToString();
							label15.Text = badQty.ToString();
						}));
					}
				}
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex < 0)
					return;

				MainForm mf = this.MdiParent as MainForm;
				var popList = mf.popList;
				int workOrderNo = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
				var pop = popList.AsEnumerable().FirstOrDefault(item => item.Work_order_no == workOrderNo);
				var ti = mf.tasks.FirstOrDefault(item => item.taskID == pop.TaskID);

				taskID = pop.TaskID;
				textBox5.Text = pop.Process_name;
				textBox1.Text = pop.Product_name;
				textBox3.Text = pop.Employee_name;
				textBox2.Text = ti.hostIP;
				textBox4.Text = ti.hostPort;
				textBox7.Text = ti.taskID;
				textBox6.Text = ti.remark;
				label9.Text = pop.Qty.ToString();
				label14.Text = pop.ResultQty.ToString();
				label10.Text = (pop.Qty - pop.ResultQty).ToString();
				label15.Text = pop.BadQty.ToString();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				POPItem pop = Stop();
				new WorkOrderService().SaveResultUse(new MSFactoryVO.WorkOrderVO { Work_order_no = pop.Work_order_no, Result_quantity = pop.ResultQty, Defective_quantity = pop.BadQty });
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private POPItem Stop()
		{
			MainForm mf = this.MdiParent as MainForm;
			var popList = mf.popList;
			var pop = popList.FirstOrDefault(item => item.TaskID == taskID);

			if (pop != null)
			{
				mf.Stop(pop.Worker, pop.Frm, pop.Task_proc_id);
				popList.Remove(pop);
			}

			return pop;
		}
	}
}
