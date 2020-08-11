using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.ManagePriceForm;

namespace WinMSFactory
{
    public partial class SellPriceForm : ListForm
    {
        ProductService service = new ProductService();
        List<SellPriceManageVO> sellVO;

        public SellPriceForm()
        {
            InitializeComponent();
        }

        private void SellPriceForm_Load(object sender, EventArgs e)
        {
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;

            dgv.AddNewColumns("품목", "product_id", 150, false);
            dgv.AddNewColumns("품목명", "product_name", 200, true);
            dgv.AddNewColumns("품목 스펙(규격)", "product_information", 200, true);
            dgv.AddNewColumns("품목 단위", "product_unit", 80, true);
            dgv.AddNewColumns("현재 단가", "sell_current_price", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("이전 단가", "sell_previous_price", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("시작일", "start_date", 80, true);
            dgv.AddNewColumns("종료일", "end_date", 80, true);
            dgv.AddNewColumns("비고", "note", 300, true);
            dgv.AddNewColumns("코드번호", "sellprice_code", 150, false);    
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)    //수정
        {
            if (e.RowIndex < 0)
                return;
        }

        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
               
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                SellPriceDialogForm popfrm = new SellPriceDialogForm(true, null);
                popfrm.Show();

            }
        }
    }
}
