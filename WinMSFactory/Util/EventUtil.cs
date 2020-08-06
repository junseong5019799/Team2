using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory;

namespace WinCoffeePrince2nd.Util
{
	public class EventUtil
	{
		private List<MethodInfo> mInfoList;
		private bool tsbSearchVisible;
		private bool tsbSaveVisible;
		private bool tsbDeleteVisible;
		private bool tsbNewVisible;

		//private void New(object sender, EventArgs e)
		//{
		//	if (((MainForm)this.MdiParent).ActiveMdiChild == this)
		//	{
		//		btnNew.PerformClick();
		//	}
		//}

		//public void CommonEvent(Form frm, IEnumerable<MethodVO> methods)
		//{
		//	this.mInfoList = new List<MethodInfo>();
		//	Type type = frm.GetType();
		//	Type thisType = this.GetType();

		//	foreach (var method in methods)
		//	{
		//		string methodID = method.Method_id;
		//		FieldInfo fieldInfo = thisType.GetField("tsb" + methodID + "Visible", BindingFlags.NonPublic | BindingFlags.Instance);

		//		if (fieldInfo != null)
		//		{
		//			if (method.Method_usable == "Y")
		//			{
		//				MethodInfo mInfo = type.GetMethod(methodID, BindingFlags.NonPublic | BindingFlags.Instance);

		//				if (mInfo != null && mInfo.ReturnType == typeof(void) && IsBtnEventParameters(mInfo))
		//				{
		//					mInfoList.Add(mInfo);
		//				}

		//				fieldInfo.SetValue(this, true);
		//			}
		//			else
		//				fieldInfo.SetValue(this, false);
		//		}
		//	}

		//	frm.Load += Form_load;
		//	frm.FormClosing += Form_FormClosing;
		//	frm.Activated += Form_Activated;
		//	frm.Deactivate += Form_Deactivate;
		//	frm.Shown += Form_Shown_dgvClearSelection;
		//}

		private bool IsBtnEventParameters(MethodInfo mInfo)
		{
			ParameterInfo[] pInfos = mInfo.GetParameters();
			Type[] parameterTypes = { typeof(object), typeof(EventArgs) };

			foreach (ParameterInfo pInfo in pInfos)
			{
				bool flag = false;

				foreach (Type parameterType in parameterTypes)
				{
					if (pInfo.ParameterType == parameterType)
					{
						flag = true;
						break;
					}
				}

				if (!flag)
					return false;
			}

			return true;
		}

		private void Form_load(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);
			Type type = mainFrm.GetType();

			foreach (MethodInfo mInfo in mInfoList)
			{
				EventInfo eInfo = type.GetEvent(mInfo.Name);
				eInfo.AddEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
			}
		}

		private void Form_FormClosing(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);
			Type type = mainFrm.GetType();

			foreach (MethodInfo mInfo in mInfoList)
			{
				EventInfo eInfo = type.GetEvent(mInfo.Name);
				eInfo.RemoveEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
			}
		}

		//private void Form_Activated(object sender, EventArgs e)
		//{
		//	MainForm mainFrm = GetMdiParent(sender);

		//	mainFrm.TsbSearchVisible = tsbSearchVisible;
		//	mainFrm.TsbSaveVisible = tsbSaveVisible;
		//	mainFrm.TsbDeleteVisible = tsbDeleteVisible;
		//	mainFrm.TsbNewVisible = tsbNewVisible;
		//}

		//private void Form_Deactivate(object sender, EventArgs e)
		//{
		//	MainForm mainFrm = GetMdiParent(sender);

		//	mainFrm.TsbSearchVisible = false;
		//	mainFrm.TsbSaveVisible = false;
		//	mainFrm.TsbDeleteVisible = false;
		//	mainFrm.TsbNewVisible = false;
		//}

		private MainForm GetMdiParent(object sender)
		{
			return (MainForm)((Form)sender).MdiParent;
		}

		public static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				// 수정해야 함
				DataTable dt = (DataTable)((DataGridView)sender).DataSource;
				DataRow dr = dt.Rows[e.RowIndex];
				string path = string.Concat(dr["IMG_PATH"], dr["IMG_SYS_NAME"]);

				if (File.Exists(path))
				{
					using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
					{
						Image image = Image.FromStream(ms);
						e.Value = image;
					}
				}
			}
		}

		public static void Form_Shown_dgvClearSelection(object sender, EventArgs e)
		{
			Form frm = (Form)sender;

			foreach (Control ctr in frm.Controls)
			{
				if (ctr is DataGridView)
					((DataGridView)ctr).ClearSelection();
			}
		}
	}
}
