using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;

namespace WinMSFactory
{
    public partial class BOMSelectAllForm : BasicForm
    {
        BomService service = new BomService();

        bool IsBOMForward;
        public BOMSelectAllForm()
        {
            InitializeComponent();
        }

        private void BOMSelectAllForm_Load(object sender, EventArgs e)
        {
            // 콤보박스 바인딩
            cboSelect.ComboBinding(service.BOMDeployeeBinding(), "Combo_Value_Member", "Combo_Display_Member");
            dgv.IsAllCheckColumnHeader = false;
            dgv.AddNewColumns("제품번호", "Product_ID", 50, false);
            dgv.AddNewColumns("제품명", "Product_Name", 250, true);
            dgv.AddNewColumns("제품 스펙", "Product_Information", 200, true);
            dgv.AddNewColumns("제품 수량", "Bom_Use_Quantity", 100, true);
            dgv.AddNewColumns("제품 사용여부", "Product_Use", 110, true);
            dgv.AddNewColumns("제품비고1", "Product_Note1", 160, true); 
            dgv.AddNewColumns("제품비고2", "Product_Note2", 160, true);
            dgv.AddNewColumns("최초 수정 시간", "First_Regist_Time", 130, true);
            dgv.AddNewColumns("최초 수정 직원", "First_Regist_Employee", 110, true);
            dgv.AddNewColumns("최종 수정 시간", "Final_Regist_Time", 130, true);
            dgv.AddNewColumns("최종 수정 직원", "Final_Regist_Employee", 110, true);

            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            string ValueMember = cboSelectType.SelectedValue.ToString();

            cboSelectName.ComboBinding(service.BOMProductBinding(ValueMember), "PRODUCT_ID", "PRODUCT_NAME");
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSelect.SelectedIndex == 0)
                IsBOMForward = true;
                
            else
                IsBOMForward = false;

            cboSelectType.ComboBinding(service.BOMTypeBinding(IsBOMForward), "Combo_Value_Member", "Combo_Display_Member");
        }

        private void cboSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueMember = cboSelectType.SelectedValue.ToString();

            cboSelectName.ComboBinding(service.BOMProductBinding(ValueMember), "PRODUCT_ID", "PRODUCT_NAME");

        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if (cboSelectName.Text.Length < 1)
                MessageBox.Show("재료를 선택한 후 진행해주세요");
            else
                dgv.DataSource = service.BOMDeployDGVBinding(IsBOMForward, cboSelectName.SelectedValue.ToInt());

            if (cboSelect.SelectedIndex == 0 && dgv.Rows.Count == 1)
                MessageBox.Show("bom 미등록이거나 하위 재료가 존재하지 않습니다.");
            else if (cboSelect.SelectedIndex == 1 && dgv.Rows.Count == 1)
                MessageBox.Show("bom 미등록이거나 상위 재료가 존재하지 않습니다.");
        }

        private void buttonControl2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("정말로 삭제하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //service.BOMDelete(dgv[0, 0].Value.ToInt());
            }
        }
    }
}
