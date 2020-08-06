using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinMSFactory.BOM;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public enum UseCheckNum
    {
        // 사용 Y, 사용 N, BOM 미등록된 상태
        ProductUsed = 1, ProductUnUsed
    }
    public partial class ProductManagementForm : ListForm
    {
        // 제품 관리

        List<ProductVO> SelectAllProducts;
        List<ProductVO> CheckUseSortList;

        ProductService pdSv = new ProductService();

        ProductGroupService pdgSv = new ProductGroupService();

        char UseCheck = 'Y';
        char BomEnrollStatus = 'N';

        bool BomEnrollCheck;
        List<ProductVO> BarcodeList = new List<ProductVO>();
        public ProductManagementForm()
        {
            InitializeComponent();
        }

        private void frmMItem_Load(object sender, EventArgs e)
        {
            dgv.IsAllCheckColumnHeader = true;
            // 사용 여부 변경 가능, BOM 확인
            dgv.AddNewColumns("제품코드", "product_id", 80, true);
            dgv.AddNewColumns("제품그룹명", "product_group_name", 100, true);
            dgv.AddNewColumns("제품명", "product_name", 150, true);
            dgv.AddNewBtnCol("사용", "사용 여부", new Padding(1, 1, 1, 1)); // 버튼
            dgv.AddNewBtnCol("", "BOM 등록 여부", new Padding(1, 1, 1, 1)); // 버튼
            dgv.AddNewColumns("제품스펙", "product_information", 200, true);
            dgv.AddNewColumns("기본단위", "product_unit", 80, true);
            dgv.AddNewColumns("생산기준량", "product_standards", 90, true);
            dgv.AddNewColumns("Tact Time", "product_tact_time", 100, true);
            dgv.AddNewColumns("Lead Time", "product_lead_time", 100, true);
            dgv.AddNewColumns("비고 1", "product_note1", 200, true);
            dgv.AddNewColumns("비고 2", "product_note2", 200, true);
            dgv.AddNewColumns("최초등록시각", "first_regist_time", 130, true);
            dgv.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgv.AddNewColumns("최종등록시각", "final_regist_time", 130, true);
            dgv.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);
            dgv.AddNewColumns("사용 여부", "product_use", 100, false);
            dgv.AddNewColumns("BOM 등록 여부", "bom_exists", 100, false);

            dgvBarCodeColumns();

            SelectAllProducts = pdSv.SelectAllProducts();

            cboProductType.ComboBinding(pdgSv.ProductGroupComboBindings(), "Product_Group_ID", "Product_Group_Name");
            ReviewDGV();

            rdoAll.CheckedChanged += rdoActive_CheckedChanged;
            rdoUnUse.CheckedChanged += rdoActive_CheckedChanged;
            rdoUse.CheckedChanged += rdoActive_CheckedChanged;

            rdoAll.Checked = true;

            ((MainForm)this.MdiParent).Readed += Readed_Completed;

        }

        private void dgvBarCodeColumns()
        {
            dgvBarcode.AddNewColumns("제품 코드", "Product_ID", 100, false);
            dgvBarcode.AddNewColumns("바코드 제품명", "Product_Name", 150, true);
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;

            dgv.DataSource = pdSv.SelectAllProducts();
        }


        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (dgv[17, row.Index].Value.ToString() == "Y") // 사용 여부 확인
                    dgv[4, row.Index].Value = "사용";
                else
                    dgv[4, row.Index].Value = "미사용";


                if (dgv[2, row.Index].Value.ToString() == "재료")
                {
                    dgv[5, row.Index].Value = "-";
                    dgv[5, row.Index].ReadOnly = true;
                }
                // BOM에 등록되지 않았으면 등록이 나오고, 등록되어있으면 수정으로 나온다.
                else if (dgv[18, row.Index].Value.ToString() == "Y") // BOM 등록 여부 확인
                {
                    dgv[5, row.Index].Value = "BOM 수정";
                    BomEnrollStatus = 'Y';
                }

                else if (dgv[18, row.Index].Value.ToString() == "N")
                {
                    dgv[5, row.Index].Value = "BOM 등록";
                    BomEnrollStatus = 'N';
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int ProductID = dgv[1, e.RowIndex].Value.ToInt();

            string ProductName = dgv[3, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == 4)
            {
                if (dgv[4, e.RowIndex].Value.ToString() == "미사용")
                {
                    pdSv.UpdateStatus(ProductID, Convert.ToInt32(UseCheckNum.ProductUnUsed));
                    dgv[4, e.RowIndex].Value = "사용";
                }


                else
                {
                    pdSv.UpdateStatus(ProductID, Convert.ToInt32(UseCheckNum.ProductUsed));
                    dgv[4, e.RowIndex].Value = "미사용";
                }

            }

            else if (e.ColumnIndex == 5)
            {
                if (dgv[5, e.RowIndex].Value.ToString() == "BOM 등록")// 미등록 상태일 때
                    BomEnrollCheck = false; // bom 미등록 상태

                else if (dgv[5, e.RowIndex].Value.ToString() == "BOM 수정") // 수정 상태일 때
                    BomEnrollCheck = true;

                else // 재료의 - 상태일 때
                    return;

                BOMManageForm frm = new BOMManageForm(BomEnrollCheck, ProductID, ProductName, BomEnrollStatus);

                if (frm.ShowDialog() == DialogResult.OK)
                    ReviewDGV();
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
        private void Add(object sender, EventArgs e)
        {
            ProductInfoForm frm = new ProductInfoForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("등록되었습니다.");
                ReviewDGV();
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            dgv.EndEdit();
            if (MessageBox.Show("제품을 삭제하시겠습니까? BOM에 해당 제품이 있을 경우 같이 삭제됩니다.", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            List<int> CheckList = new List<int>(); // 체크한 제품 번호들을 담는다.

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    CheckList.Add(dgv[1, row.Index].Value.ToInt());
            }

            // 목록을 선택한 경우(파란색으로, 1개만 가능)
            if (CheckList.Count < 1)
            {
                int ProductNo = dgv.SelectedRows[0].Cells[1].Value.ToInt();
                ProductDelete(ProductNo);
            }
            else
            {
                foreach (int ProductNum in CheckList)
                {
                    ProductDelete(ProductNum);
                }

            }

            MessageBox.Show("삭제가 완료되었습니다.");
            ReviewDGV();
        }

        private void ProductDelete(int ProductNo)
        {
            if (pdSv.DeleteProducts(ProductNo))
            {
                // BOM이 수정 될 경우에만 BOM 로그 추가
                if (dgv.SelectedRows[0].Cells[5].Value.ToString() == "BOM 수정")
                {
                    BomLogVO AddLog = new BomLogVO
                    {
                        High_Product_ID = ProductNo,
                        Bom_Enroll_Date = DateTime.Now,
                        Employee_ID = "홍길동",                                 // 직원명, ID는 회원가입이 만들어진 후 꼭 수정할 것
                        Bom_Log_Status = "BDS",             // BOM 입력
                        Bom_Exists = 'N'
                    };

                    BomLogService service = new BomLogService();

                    service.InsertLogs(AddLog);

                    return;
                }


            }
        }

        

        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirm.PerformClick();
        }

        private void buttonControl2_Click_1(object sender, EventArgs e)
        {
            BOMSelectAllForm frm = new BOMSelectAllForm(); // 상황에 따라 this.MdiParent로 바꿀 것
            frm.Show();

        }

        private void btnBOMCopy_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();
            List<int> Selectedlist = new List<int>();
            List<object> IsCheckedList = new List<object>();


            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                // 체크되면 해당되는 제품 번호를 가져옴

                if (chk.Value == null)
                {
                    IsCheckedList.Add(chk.Value);
                    continue;
                }
                if ((bool)chk.Value == true)
                {
                    if (dgv[2, chk.RowIndex].Value.ToString() == "재료") // 재료를 체크하고 복사를 진행하는 경우
                    {
                        MessageBox.Show("재료는 BOM 정보가 없습니다. 복사는 반제품, 완제품만 가능합니다.");
                        return;
                    }
                    Selectedlist.Add(dgv[1, row.Index].Value.ToInt());
                }
                else
                {
                    chk.Value = null;
                    IsCheckedList.Add(chk.Value);
                }
            }

            // 체크를 안하고 복사를 진행하는 경우
            if (IsCheckedList.Count == dgv.Rows.Count)
            {
                MessageBox.Show("체크를 한 후 복사를 진행해주시기 바랍니다.");

                return;
            }

            BOMManageForm frm = new BOMManageForm(Selectedlist, true);

            if (frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }

        private void Barcode(object sender, EventArgs e)
        {
            BarCodeProductBOM report = new BarCodeProductBOM();

            report.DataSource = pdSv.SelectAllProductsToTable();
            report.CreateDocument();

            ReportPreviewForm frm = new ReportPreviewForm(report);

        }

        private void Readed_Completed(object sender, ReadEventArgs e)
        {
            ((MainForm)this.MdiParent).ClearStrs();

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (e.ReadMsg.Contains("N")) // 재료 선택시
                {
                    MessageBox.Show("재료의 BOM 정보가 없으므로 복사를 진행하실 수 없습니다.");
                    return;
                }
                int CodeNum = e.ReadMsg.Substring(0, 4).ToInt();

                BarcodeList.Add(new ProductVO
                {
                    Product_ID = CodeNum,
                    Product_Name = pdSv.SelectProductName(CodeNum)
                });
            }

            dgvBarcode.DataSource = null;
            dgvBarcode.DataSource = BarcodeList;

        }
        private void btnbarCopy_Click(object sender, EventArgs e)
        {
            if(dgvBarcode.Rows.Count<1)
            {
                MessageBox.Show("데이터가 존재하지 않습니다.");
                return;
            }

            List<int> productNum = new List<int>();

            foreach(DataGridViewRow row in dgvBarcode.Rows)
            {
                productNum.Add(dgvBarcode[0, row.Index].Value.ToInt());
            }
            BOMManageForm frm = new BOMManageForm(productNum, true);

            if (frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }

        private void btnBarDelete_Click(object sender, EventArgs e)
        {
            if (dgvBarcode.Rows.Count < 1)
            {
                MessageBox.Show("데이터가 존재하지 않습니다.");
                return;
            }
            dgvBarcode.DataSource = null;
            BarcodeList.Clear();
            dgvBarCodeColumns();
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            BOMLogForm frm = new BOMLogForm();
            frm.ShowDialog();
        }
    }
}
