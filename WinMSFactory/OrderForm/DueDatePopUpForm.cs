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

namespace WinMSFactory.OrderForm
{
    public partial class DueDatePopUpForm : PopUpDialogForm
    {
        private DateTime release_plan_date;

        public DateTime Release_plan_date
        {
            get { return release_plan_date; }
            set { release_plan_date = value; }
        }

        private int release_no;

        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; }
        }


        public DueDatePopUpForm()
        {
           InitializeComponent();
        }

        private void DueDatePopUpForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = Release_plan_date;
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

            if (service.UpdateOrderDate(dt, release_no))
                this.Close();
        }
        
        
        private void btnC_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
