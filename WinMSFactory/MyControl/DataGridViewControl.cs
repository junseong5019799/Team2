using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class DataGridViewControl : DataGridView
    {
        CheckBox headerCheckBox = new CheckBox();
        
        bool _allCheckHeader;
        bool _autoGenerateColumns;

        public bool IsAllCheckColumnHeader
        {
            get { return _allCheckHeader; }
            set
            {
                _allCheckHeader = value;

                if (_allCheckHeader && this.Columns.Count < 1)
                {
                    this.AddNewChkCol(HeaderCheckBox_Clicked, ref headerCheckBox);
                }
            }
        }

        public bool IsAutoGenerateColumns
        {
            get { return _autoGenerateColumns; }
            set
            {
                _autoGenerateColumns = value;
                if (_autoGenerateColumns)
                    this.AutoGenerateColumns = true;
                else
                    this.AutoGenerateColumns = false;

            }
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            this.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in this.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }

		public DataGridViewControl()
        {                  
            InitializeComponent();

            DataGridViewContentAlignment centerAlign = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.Alignment = centerAlign;
            
            this.DefaultCellStyle.ForeColor = Color.Black;
            //this.DefaultCellStyle.BackColor = Color.White;
            this.BackgroundColor = Color.White;

            // 테두리 설정
            this.BorderStyle = BorderStyle.None;

            this.AllowUserToAddRows = false;
            this.MultiSelect = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (IsAutoGenerateColumns)
                this.AutoGenerateColumns = true;
            else
                this.AutoGenerateColumns = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
