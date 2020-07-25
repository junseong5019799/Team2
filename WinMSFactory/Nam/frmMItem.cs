using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.BOM;

namespace WinMSFactory
{
    public enum UseCheckNum
    {
        // 사용 Y, 사용 N, BOM 미등록된 상태
        ProductUsed = 1, ProductUnUsed
    }
    public partial class frmMItem : ListForm
    {
        // 제품 관리

        List<ProductVO> SelectAllProducts;

        ProductService pdSv = new ProductService();

        ProductGroupService pdgSv = new ProductGroupService();

        char UseCheck = 'Y';
        private List<ProductVO> CheckUseSortList;

        public frmMItem()
        {
            InitializeComponent();
        }

        private void frmMItem_Load(object sender, EventArgs e)
        {
            
            // 사용 여부 변경 가능, BOM 확인
            dgv.AddNewColumns("제품코드", "product_id", 100, true);
            dgv.AddNewColumns("제품그룹명", "product_group_name", 100, true);
            dgv.AddNewColumns("제품명", "product_name", 100, true);

            dgv.AddNewBtnCol("사용", "사용 여부", new Padding(1, 1, 1, 1));
            dgv.AddNewBtnCol("", "BOM 등록 여부", new Padding(1, 1, 1, 1));

            dgv.AddNewColumns("제품스펙", "product_information", 100, true);
            dgv.AddNewColumns("기본단위", "product_unit", 100, true);
            dgv.AddNewColumns("생산기준량", "product_standards", 100, true);
            dgv.AddNewColumns("비고 1", "product_note1", 100, true);
            dgv.AddNewColumns("비고 2", "product_note2", 100, true);
            dgv.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgv.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgv.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgv.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);
            dgv.AddNewColumns("사용 여부", "product_use", 100, false);
            dgv.AddNewColumns("BOM 등록 여부", "bom_check", 100, false);
            dgv.AddNewColumns("순번", "product_seq", 100, false);

            SelectAllProducts = pdSv.SelectAllProducts();

            cboProductType.ComboBinding(pdgSv.ProductGroupComboBindings(), "Product_Group_ID", "Product_Group_Name");
            ReviewDGV();

            rdoAll.CheckedChanged += rdoActive_CheckedChanged;
            rdoUnUse.CheckedChanged += rdoActive_CheckedChanged;
            rdoUse.CheckedChanged += rdoActive_CheckedChanged;

            rdoAll.Checked = true;
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;
            
            dgv.DataSource = SelectAllProducts;
        }
        
        private void buttonControl1_Click(object sender, EventArgs e)
        {
            ProductInfoForm frm = new ProductInfoForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("등록되었습니다."); 
                ReviewDGV();
            }
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (dgv[14, row.Index].Value.ToString() == "Y") // 사용 여부 확인
                    dgv[3,row.Index].Value = "사용";
                else
                    dgv[3, row.Index].Value = "미사용";           


                // BOM에 등록되지 않았으면 등록이 나오고, 등록되어있으면 수정으로 나온다.
                if(dgv[15, row.Index].Value.ToString() == "Y") // BOM 등록 여부 확인
                    dgv[4, row.Index].Value = "BOM 수정";
                else
                    dgv[4, row.Index].Value = "BOM 등록";
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ItemNum = dgv[0, e.RowIndex].Value.ToInt();
            if(e.ColumnIndex == 3)
            {
                if (dgv[3, e.RowIndex].Value.ToString() == "미사용")
                {
                    pdSv.UpdateStatus(ItemNum, Convert.ToInt32(UseCheckNum.ProductUnUsed));
                    dgv[3, e.RowIndex].Value = "사용";
                }
                    

                else
                {
                    pdSv.UpdateStatus(ItemNum, Convert.ToInt32(UseCheckNum.ProductUsed));
                    dgv[3, e.RowIndex].Value = "미사용";
                }

            }
            
            else if(e.ColumnIndex == 4)
            {
                if (dgv[4, e.RowIndex].Value.ToString() == "BOM 등록")// 미등록 상태일 때
                {
                    BOMManageForm frm = new BOMManageForm();
                    frm.ProductNm = dgv[2, e.RowIndex].Value.ToString();
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                        dgv[4, e.RowIndex].Value = "BOM 수정";
                    }

                }
            }
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
        private void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUse.Checked)
            {
                UseCheck = 'Y';
                CheckUseSortList = SelectAllProducts.FindAll(p => p.Product_Use == UseCheck.ToString());
            }
                
            else if (rdoUnUse.Checked)
            {
                UseCheck = 'N';
                CheckUseSortList = SelectAllProducts.FindAll(p => p.Product_Use == UseCheck.ToString());
            }
                
            else if (rdoAll.Checked)
            {
                UseCheck = 'A';
                CheckUseSortList = SelectAllProducts;
            }
                
        }

        private void buttonControl2_Click(object sender, EventArgs e) // 검색 버튼
        {
            

            if (cboProductType.SelectedIndex == 0) // 전체 선택시
            {
                if (txtProductSearch.Text.Length < 1)
                {
                    dgv.DataSource = CheckUseSortList;
                }
                    
                else
                {
                    var SortedList = (from sort in CheckUseSortList
                                      where sort.Product_Name.Contains(txtProductSearch.Text)
                                      select sort).ToList();

                    dgv.DataSource = SortedList;
                }
            }
            else
            {
                if (txtProductSearch.Text.Length < 1)
                    dgv.DataSource = CheckUseSortList.FindAll(p => p.Product_Group_Name == cboProductType.Text);

                else
                {
                    var SortedList = (from sort in CheckUseSortList
                                      where sort.Product_Name.Contains(txtProductSearch.Text) && sort.Product_Group_Name.Equals(cboProductType.Text)
                                      select sort).ToList();

                    dgv.DataSource = SortedList;
                }
            }
        }

    }
}
