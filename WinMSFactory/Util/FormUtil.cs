using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory;

namespace WinCoffeePrince2nd.Util
{
	public static class FormUtil
	{
		#region DataGridView
		public static void InitDGV(this DataGridView dgv)
		{
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.AutoGenerateColumns = false;
			dgv.AllowUserToAddRows = false;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
		}

		public static void InitImgDGV(this DataGridView dgv)
		{
			dgv.RowTemplate.Height = 100;
			InitDGV(dgv);
		}

		public static void AddNewCol(this DataGridView dgv, string headerText, string dataPropertyName, bool visibility = true,
								   int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
		{
			DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
			gridCol.HeaderText = headerText;
			gridCol.DataPropertyName = dataPropertyName;
			gridCol.Width = colWidth;
			gridCol.Visible = visibility;
			gridCol.ValueType = typeof(string);
			gridCol.ReadOnly = true;
			gridCol.DefaultCellStyle.Alignment = textAlign;
			dgv.Columns.Add(gridCol);
		}

		public static void AddNewBtnCol(this DataGridView dgv, string text, Padding padding)
		{
			DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

			btn.Text = text;
			btn.Width = 50;
			btn.DefaultCellStyle.Padding = padding;
			btn.UseColumnTextForButtonValue = true;

			dgv.Columns.Add(btn);
		}

		public static void AddNewBtnDelCol(this DataGridView dgv)
		{
			DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

			btn.Text = "X";
			btn.Width = 23;
			btn.FlatStyle = FlatStyle.Flat;
			btn.DefaultCellStyle.ForeColor = Color.Red;
			btn.DefaultCellStyle.Padding = new Padding(5);
			btn.UseColumnTextForButtonValue = true;

			dgv.Columns.Add(btn);
		}

		public static void AddNewChkCol(this DataGridView dgv, string propertyName)
		{
			AddNewChkCol(dgv, propertyName, null);
		}

		public static void AddNewChkCol(this DataGridView dgv, string propertyName, EventHandler HeaderChk_Clicked)
		{
			// 데이터그리드뷰의 헤더의 위치할 체크박스
			DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
			chk.Width = 30;
			chk.Name = "chk";
			chk.HeaderText = "";
			chk.DataPropertyName = propertyName;
			dgv.Columns.Add(chk);

			if (HeaderChk_Clicked != null)
			{
				Point headerCell = dgv.GetCellDisplayRectangle(0, -1, true).Location;
				CheckBox headerChk = new CheckBox();
				headerChk.Name = "headerChk";
				//headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 2);
				headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 4);
				//headerChk.Size = new Size(18, 18);
				headerChk.Size = new Size(15, 15);
				headerChk.BackColor = Color.White;
				headerChk.Click += HeaderChk_Clicked;

				dgv.Controls.Add(headerChk);
			}

		}

		public static void AddNewImgCol(this DataGridView dgv, string headerText, DataGridViewImageCellLayout imgLayout = DataGridViewImageCellLayout.Zoom)
		{
			DataGridViewImageColumn img = GetDGVImgCol(headerText, imgLayout);

			dgv.Columns.Add(img);
			dgv.CellFormatting += EventUtil.DataGridView_CellFormatting;
		}

		public static void AddNewImgBlobCol(this DataGridView dgv, string headerText, string propertyName, DataGridViewImageCellLayout imgLayout = DataGridViewImageCellLayout.Zoom)
		{
			DataGridViewImageColumn img = GetDGVImgCol(headerText, imgLayout, propertyName);

			dgv.Columns.Add(img);
		}

		private static DataGridViewImageColumn GetDGVImgCol(string headerText, DataGridViewImageCellLayout imgLayout)
		{
			DataGridViewImageColumn img = new DataGridViewImageColumn();
			img.HeaderText = headerText;
			img.ImageLayout = DataGridViewImageCellLayout.Stretch;

			return img;
		}
		private static DataGridViewImageColumn GetDGVImgCol(string headerText, DataGridViewImageCellLayout imgLayout, string propertyName)
		{
			DataGridViewImageColumn img = GetDGVImgCol(headerText, imgLayout);
			img.DataPropertyName = propertyName;

			return img;
		}
		#endregion

		#region Form
		public static Form MdiChildrenShow(this MainForm mdiParent, TabControl mainTabControl, DataRow authDr)
		{
			Type type = Type.GetType("WinMSFactory." + authDr["PROG_FORM_NAME"]);

			if (type != null)
			{
				foreach (TabPage tp in mainTabControl.TabPages)
				{
					Form frm = (Form)tp.Tag;

					if (frm.GetType() == type && frm.IsMdiChild)
					{
						mainTabControl.SelectedTab = tp;
						return frm;
					}
				}

				Form f = (Form)Activator.CreateInstance(type);
				f.MdiParent = mdiParent;
				f.FormBorderStyle = FormBorderStyle.None;
				f.Dock = DockStyle.Fill;

				new EventUtil().CommonEvent(f, authDr);

				f.Show();

				return f;
			}

			return null;
		}

		public static bool HasEmptyTxt(this Form frm)
		{
			TextBox txt = GetEmptyTxt(frm.Controls, null);

			if (txt != null)
			{
				MessageBox.Show(txt.Tag.ToString());
				txt.Focus();

				return true;
			}

			return false;
		}

		public static TextBox GetEmptyTxt(Control.ControlCollection controls, TextBox txt)
		{
			if (txt == null)
			{
				foreach (Control contorl in controls)
				{
					if (contorl is TextBox)
					{
						if (!string.IsNullOrEmpty(contorl.Tag?.ToString()?.Trim()) && string.IsNullOrEmpty(contorl.Text.Trim()))
							return (TextBox)contorl;
					}
					else
					{
						if (contorl.Controls.Count > 0)
							txt = GetEmptyTxt(contorl.Controls, txt);
					}
				}
			}

			return txt;
		}

		public static void Clear(this Form frm)
		{
			Clear(frm.Controls);
		}

		public static void Clear(Control.ControlCollection controls)
		{
			foreach (Control contorl in controls)
			{
				if (!contorl.Name.Contains("Search"))
				{
					if (contorl is NumericUpDown)
						((NumericUpDown)contorl).Value = 0;
					else if (contorl is TextBox)
					{
						contorl.Text = "";
						contorl.Enabled = true;
					}
					else if (contorl is ComboBox)
						((ComboBox)contorl).SelectedIndex = 0;
					else if (contorl is DataGridView)
						((DataGridView)contorl).ClearSelection();
					else if (contorl is CheckBox)
						((CheckBox)contorl).Checked = false;
					else if (contorl is RadioButton)
						((RadioButton)contorl).Checked = false;
					else if (contorl is DateTimePicker)
						((DateTimePicker)contorl).Value = DateTime.Now;
					else if (contorl.Controls.Count > 0)
						Clear(contorl.Controls);
				}
			}
		}

		public static MainForm GetMdiParent(this Form frm)
		{
			return frm.MdiParent as MainForm;
		}

		public static EmployeeVO GetEmployee(this Form frm)
		{
			EmployeeVO employee = null;
			MainForm mainForm = GetMdiParent(frm);

			if (mainForm != null)
				employee = mainForm.Employee;

			return employee;
		}
		#endregion

		#region comboBox 바인딩 관련
		public static void ComboBinding(this ComboBox combo, List<CommonCodeVO> list, string blankText = "", string blankValue = "")
		{
			if (list == null)
				list = new List<CommonCodeVO>();

			if (!string.IsNullOrEmpty(blankText))
				list.Insert(0, new CommonCodeVO { Common_name = blankText, Common_id = blankValue });

			combo.DataSource = list;
			combo.DisplayMember = "Common_name";
			combo.ValueMember = "Common_id";
		}

		public static void ComboBinding<T>(this ComboBox combo, List<T> list, string Code, string CodeNm)
		{
			if (list == null)
				list = new List<T>();

			combo.DataSource = list;
			combo.DisplayMember = CodeNm;
			combo.ValueMember = Code;
		}

		public static void ComboBinding<T>(this ComboBox combo, List<T> list, string Code, string CodeNm, string blankText, object blankValue = null) where T : class, new()
		{
			if (list == null)
				list = new List<T>();

			T blankItem = new T();

			blankItem.GetType().GetProperty(CodeNm).SetValue(blankItem, blankText);
			blankItem.GetType().GetProperty(Code).SetValue(blankItem, blankValue);
			list.Insert(0, blankItem);

			combo.DataSource = list;
			combo.DisplayMember = CodeNm;
			combo.ValueMember = Code;
		}

		public static void ComboBinding(this ComboBox cbo, DataTable dt, string DisplayMember, string ValueMember, string emptyName = null, object emptyValue = null)
		{
			if (!string.IsNullOrEmpty(emptyName))
			{
				DataRow dr = dt.NewRow();
				dr[DisplayMember] = emptyName;
				dr[ValueMember] = emptyValue;
				dt.Rows.InsertAt(dr, 0);
			}

			cbo.DataSource = dt;
			cbo.DisplayMember = DisplayMember;
			cbo.ValueMember = ValueMember;
		}
		#endregion

		public static void ShowOrgImg(this PictureBox pictureBox, string imgPath)
		{
			try
			{
				if (!string.IsNullOrEmpty(imgPath))
				{
					using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imgPath)))
					{
						Image image = Image.FromStream(ms);
						Form frm = new Form();
						frm.Text = "이미지 보기";
						frm.Size = new Size(image.Height > 600 ? image.Width + 33 : image.Width, image.Height > 600 ? 600 : image.Height);

						if (image.Height > 600)
							frm.AutoScroll = true;

						PictureBox pic = new PictureBox();
						pic.Size = new Size(image.Width, image.Height);
						pic.Image = image;
						pic.Cursor = Cursors.Hand;
						pic.Click += (sender2, e2) => frm.Close();

						frm.Controls.Add(pic);
						frm.ShowDialog();
					}
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		public static Control GetControl(this Form frm, string name)
		{
			return GetControl(name, frm.Controls);
		}

		public static Control GetControl(string name, Control.ControlCollection controls)
		{
			Control control = null;

			foreach (Control c in controls)
			{
				if (control != null)
					return control;
				else if (c.Name == name)
					return c;
				else if (c.Controls.Count > 0)
					control = GetControl(name, c.Controls);
			}

			return control;
		}

		public static bool IsRdoCheck(Control.ControlCollection controls)
		{
			foreach (Control c in controls)
			{
				if (c is RadioButton && ((c as RadioButton).Checked))
					return true;
			}

			return false;
		}

		public static string GetCheckIDs(this DataGridView dgv, string id)
		{
			string ids = "";

			dgv.EndEdit();

			foreach (DataGridViewRow dgvr in dgv.Rows)
			{
				if (dgvr.Cells["chk"].Value.ToBool())
					ids += dgvr.Cells[id].Value + "@";
			}

			return ids;
		}
	}
}
