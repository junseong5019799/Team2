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
using WinMSFactory.Nam;
using WinMSFactory.Services;

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
        char BomEnrollStatus = 'N';
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
            dgv.AddNewColumns("BOM 등록 여부", "bom_exists", 100, true);
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

            dgv.DataSource = pdSv.SelectAllProducts();
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


                if(dgv[1,row.Index].Value.ToString() == "재료")
                {
                    dgv[4, row.Index].Value = "-";
                    dgv[4, row.Index].ReadOnly = true;
                }
                // BOM에 등록되지 않았으면 등록이 나오고, 등록되어있으면 수정으로 나온다.
                else if (dgv[15, row.Index].Value.ToString() == "Y") // BOM 등록 여부 확인
                {
                    dgv[4, row.Index].Value = "BOM 수정";
                    BomEnrollStatus = 'Y';
                }
                    
                else if(dgv[15, row.Index].Value.ToString() == "N")
                {
                    dgv[4, row.Index].Value = "BOM 등록";
                    BomEnrollStatus = 'N';
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
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
                    frm.ProductID = dgv[0, e.RowIndex].Value.ToInt();
                    frm.BOMEnrollStatus = BomEnrollStatus;

                    if (frm.ShowDialog() == DialogResult.OK)
                        ReviewDGV();

                }
                else if(dgv[4, e.RowIndex].Value.ToString() == "BOM 수정") // 수정 상태일 때
                {
                    BOMUpdateForm frm = new BOMUpdateForm();
                    frm.ProductNm = dgv[2, e.RowIndex].Value.ToString();
                    frm.ProductID = dgv[0, e.RowIndex].Value.ToInt();
                    frm.BOMEnrollStatus = BomEnrollStatus;

                    if (frm.ShowDialog() == DialogResult.OK)
                        ReviewDGV();
                }
                
                // 재료의 - 상태는 return됨
            }
            
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
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("제품을 삭제하시겠습니까? BOM에 해당 제품이 있을 경우 같이 삭제됩니다.", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int ProductNo = dgv.SelectedRows[0].Cells[0].Value.ToInt();

            

            if (pdSv.DeleteProducts(ProductNo))
            {
                // BOM이 수정 될 경우에만 BOM 로그 추가
                if(dgv.SelectedRows[0].Cells[4].Value.ToString() == "BOM 수정")
                {
                    List<ProductVO> DeleteHighProductList = new List<ProductVO>();
                    List<ProductVO> DeleteLowProductList = new List<ProductVO>();

                    pdSv.DeleteList(ProductNo, ref DeleteHighProductList, ref DeleteLowProductList);

                    BomLogVO AddLog = new BomLogVO
                    {
                        High_Product_ID = ProductNo,
                        Bom_Enroll_Date = DateTime.Now,
                        Employee_ID = 1,                                 // 직원명, ID는 회원가입이 만들어진 후 꼭 수정할 것
                        Bom_Use = UseCheck,
                        Bom_Log_Status = "BDS",             // BOM 입력
                        Bom_Exists = 'N'
                    };

                    BomLogService service = new BomLogService();

                    service.InsertLogs(AddLog);

                    ItemDeleteList frm = new ItemDeleteList(DeleteHighProductList, DeleteLowProductList);
                    frm.ShowDialog();
                    ReviewDGV();
                    return;
                }

                MessageBox.Show("삭제가 완료되었습니다.");
                
            }
        }

        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirm.PerformClick();
        }
    }
}
