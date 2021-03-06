﻿using MSFactoryVO;
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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class BOMSelectAllForm : BasicForm
    {
        BomService service = new BomService();
        BomLogService bls = new BomLogService();

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

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (cboSelectName.Text.Length < 1)
                    MessageBox.Show("재료를 선택한 후 진행해주세요");
                else
                {
                    dgv.DataSource = service.BOMDeployDGVBinding(IsBOMForward, cboSelectName.SelectedValue.ToInt());

                    if (cboSelect.SelectedIndex == 0 && dgv.Rows.Count == 1) // 정전개를 선택했는데 원재료 1개만 나오는 경우
                    {
                        // 이는 bom이 등록되지 않았거나 하위 재료가 등록되지 않았다는 것을 의미함
                        dgv.DataSource = null;
                        MessageBox.Show("bom 미등록이거나 하위 재료가 존재하지 않습니다.");
                    }

                    else if (cboSelect.SelectedIndex == 1 && dgv.Rows.Count == 1)
                    {
                        // 이는 bom이 등록되지 않았거나 상위 재료가 등록되지 않았다는 것을 의미함
                        dgv.DataSource = null;
                        MessageBox.Show("bom 미등록이거나 상위 재료가 존재하지 않습니다.");
                    }
                }
            }
        }

        private void buttonControl2_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count<1)
            {
                MessageBox.Show("Bom를 먼저 조회해주세요");
                return;
            }
            if(MessageBox.Show("정말로 삭제하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int productNum = dgv[0, 0].Value.ToInt();
                if (service.BOMDelete(productNum) == true)
                {
                    bls.ChangeBomStatus(productNum, 'N');
                    MessageBox.Show("해당하는 BOM이 삭제되었습니다. 그에 따른 상위 / 하위 목록도 같이 삭제되었습니다.");
                    cboSelect.SelectedIndex = 0;
                }
                this.DialogResult = DialogResult.OK;
                dgv.DataSource = null;
            }
        }

        private void buttonControl2_Click_1(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count<1 )
            {
                MessageBox.Show("삭제할 목록을 선택해주세요");
                return;
            }

            int SelectRowIndex = dgv.SelectedRows[0].Index;
            int HighProductNo = dgv[0, 0].Value.ToInt();
            int LowProductNo = dgv[0, SelectRowIndex].Value.ToInt();

            if(SelectRowIndex == 0)
            {
                MessageBox.Show("맨 상위 목록은 선택할 수 없습니다.");
                return;
            }

            else if(MessageBox.Show("선택한 하위 BOM 물품을 삭제하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(service.BomPartialDelete(HighProductNo, LowProductNo))
                {
                    MessageBox.Show("삭제되었습니다.");
                    dgv.DataSource = service.BOMDeployDGVBinding(IsBOMForward, cboSelectName.SelectedValue.ToInt());
                }

            }
        }
    }
}
