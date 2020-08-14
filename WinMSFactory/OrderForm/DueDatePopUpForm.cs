using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class DueDatePopUpForm : PopUpDialogForm
    {
        private DateTime due_date;

        public DateTime Due_date
        {
            get { return due_date; }
            set { due_date = value; }
        }

        private int order_no;

        public int Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        private string gubun;

        public string Gubun
        {
            get { return gubun; }
            set { gubun = value; }
        }

        public DueDatePopUpForm()
        {
           InitializeComponent();
        }

        private void DueDatePopUpForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = Due_date;
            dtpTo.Value = Due_date.AddDays(1);
        }


        /// <summary>
        /// 날짜 변경하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            DateTime dt = dtpTo.Value;

            OrderService service = new OrderService();

            if (Gubun == "발주")
            {
                service.UpdateOrderDate(dt, order_no);
                MessageBox.Show("발주 납기일이 변경되었습니다.");
            }
            else if(Gubun == "출고")
            {
                service.UpdateReleaseRequestDate(dt, order_no);
                MessageBox.Show("출고요청 납기일이 변경되었습니다.");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
        
        
        private void btnC_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if(dtpTo.Value < dtpFrom.Value)
            {
                dtpTo.Value = Due_date.AddDays(1);
                MessageBox.Show("현 날짜는 불가능 합니다.");
                return;
            }
        }
    }
}
