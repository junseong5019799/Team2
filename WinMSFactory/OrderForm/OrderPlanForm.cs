using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory.OrderForm
{
    public partial class OrderPlanForm : ListForm
    {
        public OrderPlanForm()
        {
            InitializeComponent();
        }

        private void OrderPlanForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("품목 명", "", 100, true);
            dgv.AddNewColumns("카테고리", "", 100, true);

            
        }
    }
}
