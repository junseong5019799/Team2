using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory.BOM
{
    
    public partial class BOMManageForm : BasicForm
    {
        BomService bomSv = new BomService();
        ProductGroupService pdgSv = new ProductGroupService();
        ProductService pdSv = new ProductService();

        List<BomVO> SelectedAllMaterial;
        List<BomVO> CheckedList;
        List<int> ProductIDs = null;

        new string ProductName;
        int ProductID;
        char BOMEnrollStatus; // DB에 Insert
        bool BomEnrollCheck; // 등록, 수정 결정
        bool IsBomCopy = false;
        EmployeeVO employee;

        public ProductInsertVO ProductInformation { get; set; } // Bom Copy에서 사용

        // BOM 등록 및 수정
        public BOMManageForm(EmployeeVO employee, bool BomEnrollCheck, int ProductID, string ProductName, char BOMEnrollStatus)
        {
            InitializeComponent();
            CheckedList = new List<BomVO>();
            this.BomEnrollCheck = BomEnrollCheck;
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.BOMEnrollStatus = BOMEnrollStatus;
            this.employee = employee;

            if(BomEnrollCheck == true)
            {
                this.Text = "BOM 수정";
                btnSubmit.Text = "수정";
            }
        }
        // BOM 복사
        public BOMManageForm(EmployeeVO employee, List<int> ProductIDs, bool IsBomCopy)
        {
            InitializeComponent();
            this.ProductIDs = ProductIDs;
            this.IsBomCopy = IsBomCopy;
            this.BomEnrollCheck = true;
            CheckedList = new List<BomVO>();
            ProductName = "";
            this.employee = employee;
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            // 왼쪽 그리드 뷰에는 반제품, 재료 만 조회 가능
            cboSearch.ComboBinding(BomService.CboProductType(), "ValueMember", "Member");
            //cboType.ComboBinding(pdgSv.ProductGroupComboBindingsNotAll(),"Product_Group_ID", "Product_Group_Name");

            btnInformation.Visible = false;
            txtProductName.Text = ProductName;

            dgv.IsAllCheckColumnHeader = true;
            dgv2.IsAllCheckColumnHeader = true;

            MaterialColumns();
            SelectedAllMaterial = bomSv.SelectMaterialSettings("반제품", "재료", ProductID);
            dgv.DataSource = SelectedAllMaterial; // 반제품, 재료만 조회

            DataSourceBinding();
        }

        private void DataSourceBinding()
        {
            if (BomEnrollCheck == true && IsBomCopy == false)
            {
                CheckedList = bomSv.BOMEnrolledMaterial(ProductID);
                dgv2.DataSource = CheckedList;
            }

            // BOM Copy
            else if (IsBomCopy == true)
            {
                dgv2.DataSource = bomSv.BOMEnrolledMaterial(ProductIDs);
                CheckedList = (List<BomVO>)dgv2.DataSource;
                txtProductName.Enabled = true;
                btnInformation.Visible = true;
                btnSubmit.Visible = false;
            }
        }

        private void MaterialColumns()
        {
            dgv.AddNewColumns("번호", "Product_ID", 70, true);
            dgv.AddNewColumns("제품 그룹명", "Product_Group_Name", 150, true);
            dgv.AddNewColumns("제품명", "Product_Name", 150, true);
            dgv.AddNewColumns("품명 스펙", "Product_Information", 200, true);
            dgv.AddNewColumns("기본 단위", "Product_Unit", 100, false);
            dgv.AddNewColumns("비고 1", "Product_Note1", 100, true);
            dgv.AddNewColumns("비고 2", "Product_Note2", 100, true);

            dgv2.AddNewColumns("번호", "Product_ID", 100, false);
            dgv2.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv2.AddNewColumns("제품명", "Product_Name", 150, true);
            dgv2.AddNewColumns("품명 스펙", "Product_Information", 100, false);
            dgv2.AddNewColumns("필요 수량", "Bom_Use_Quantity", 100, true);
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            // 이 이벤트는 BOM Copy에서만 사용하는 이벤트

            if (txtProductName.TextLength<1)
            {
                MessageBox.Show("제품명을 추가 해주세요");
                return;
            }

            
            ProductInfoForm frm = new ProductInfoForm(this, employee.Employee_name, txtProductName.Text, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnInformation.Visible = false;
                btnSubmit.Visible = true;
                txtProductName.Enabled = false;
            }
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0) // 전체 선택시
            {
                if(txtSearch.Text.Length<1)
                    dgv.DataSource = SelectedAllMaterial;
                else
                {
                    var SortedList = (from sort in SelectedAllMaterial
                                      where sort.Product_Name.Contains(txtSearch.Text) && (sort.Product_Group_Name == "반제품"
                                      || sort.Product_Group_Name == "재료")
                                      select sort).ToList();
                    
                    dgv.DataSource = SortedList;
                }
            }
            else
            {
                if (txtSearch.Text.Length < 1)
                    dgv.DataSource = SelectedAllMaterial.FindAll(p => p.Product_Group_Name == cboSearch.Text);

                else
                {
                    var SortedList = (from sort in SelectedAllMaterial
                                      where sort.Product_Name.Contains(txtSearch.Text) && sort.Product_Group_Name.Equals(cboSearch.Text)
                                      select sort).ToList();

                    dgv.DataSource = SortedList;
                }
            }
           
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 초기화 진행 시
            if(IsBomCopy == false)
            {
                cboSearch.SelectedIndex = 0;
                dgv.headerCheckBox.Checked = false;
                dgv2.headerCheckBox.Checked = false;
            }
            else // IsBomCopy == true
            {
                cboSearch.SelectedIndex = 0;
                
                ProductInformation = null;
                btnInformation.Visible = true;
                btnSubmit.Visible = false;
                dgv.headerCheckBox.Checked = false;
                dgv2.headerCheckBox.Checked = false;
            }

            DataSourceBinding();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if(txtProductName.TextLength<1) // BOM 복사 때문에 필요함
            {
                MessageBox.Show("제품명을 추가 해주세요");
                return;
            }
            if (dgv2.Rows.Count < 2)
            {
                MessageBox.Show("재료를 2개 이상 추가해주세요");
                return;
            }
            // 재료 수량이 입력이 안된 경우 중단 시킴
            foreach(DataGridViewRow row in dgv2.Rows)
            { 
                if(dgv2[5,row.Index].Value == null)
                {
                    MessageBox.Show("수량을 모두 입력해주세요");
                    return;
                }
            }

            if (MessageBox.Show("등록을 진행하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // BOM 테이블에 등록
            List<BOMInsertUpdateVO> InsertBOMLists = new List<BOMInsertUpdateVO>();
            
            if(IsBomCopy == true) // BOM COPY
            {
                // 정보 등록이 완료되면
                if(pdSv.InsertProducts(ProductInformation, 'Y'))
                {
                    ListSortings(InsertBOMLists);

                    if(bomSv.InsertUpdateProductByBomCopy(InsertBOMLists, txtProductName.Text))
                    {
                        string Status_String = "BIS";

                        // BOM Log에 등록
                        BomAddLogs(Status_String);
                    }
                }
            }
            else
            {
                // dgv2에서 목록 Sorting
                ListSortings(InsertBOMLists, ProductID);

                if (bomSv.InsertUpdateProduct(InsertBOMLists))
                {
                    string Status_String = string.Empty;

                    if (BomEnrollCheck == true)
                        Status_String = "BUS";
                    else
                        Status_String = "BIS";
                    
                    // BOM Log에 등록
                    BomAddLogs(Status_String);
                }

            }
        }

        private void ListSortings(List<BOMInsertUpdateVO> InsertBOMLists, int ProductIDNum = 0) // BOM List Sorting
        {
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                InsertBOMLists.Add(new BOMInsertUpdateVO
                {
                    Higher_Product_ID = ProductIDNum,
                    Lower_Product_ID = dgv2[1, row.Index].Value.ToInt(),   // 재료들의 ID
                    Bom_Use_Quantity = dgv2[5, row.Index].Value.ToInt(),
                    Final_Regist_Time = DateTime.Now.Date,
                    Final_Regist_Employee = employee.Employee_name,                        
                    Bom_Status = BOMEnrollStatus// BOM 사용 여부 넣어줄 것
                });
            }
        }

        private void BomAddLogs(string Status_String) // BomLog 저장
        {
            BomLogVO AddLog = new BomLogVO
            {
                High_Product_ID = ProductID,
                Bom_Enroll_Date = DateTime.Now,
                Employee_ID = employee.Employee_id,                                 // 직원명, ID는 회원가입이 만들어진 후 꼭 수정할 것
                Bom_Log_Status = Status_String,             // BOM 입력
                Bom_Exists = 'Y'
            };
            BomLogService service = new BomLogService();

            service.InsertLogs(AddLog);

            MessageBox.Show("BOM 등록이 완료되었습니다.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            List<object> NullCheck = new List<object>();
            bool ShowMessage = false;
            bool IsAllNull = true;

            foreach(DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];
                // 체크 상태가 아닌 경우
                if (chk.Value == null)
                {
                    NullCheck.Add(chk.Value); // null일때 list에 추가
                    continue;
                }

                NullCheck.Add(chk.Value);    // null가 아닐 때 값 list 추가

                BomVO InsertData = new BomVO
                {
                    Product_ID = dgv[1, row.Index].Value.ToInt(),
                    Product_Group_Name = dgv[2, row.Index].Value.ToString(),
                    Product_Name = dgv[3, row.Index].Value.ToString(),
                    Product_Information = dgv[4, row.Index].Value.ToString(),
                    Bom_Use_Quantity = 1
                };
                // 체크 상태인 경우
                if((bool)chk.Value == true)
                {
                    bool check = false;

                    if(dgv2.Rows.Count==0 && BomEnrollCheck == false)
                    {
                        CheckedList.Add(InsertData);
                        continue;
                    }
                    // 왼쪽 오른쪽 중복 체크
                    foreach(DataGridViewRow row1 in dgv2.Rows)
                    {
                        if (InsertData.Product_ID == dgv2[1, row1.Index].Value.ToInt())
                        {
                            check = true;
                            ShowMessage = true;
                        }
                    }

                    if (check == false)
                        CheckedList.Add(InsertData);
                }
            }

            foreach (object row in NullCheck)
            {
                if (row != null)
                    IsAllNull = false;
            }

            if(IsAllNull == false)
            {
                dgv2.DataSource = null;
                dgv2.DataSource = CheckedList;
            }

            if (ShowMessage == true)
                MessageBox.Show("이미 등록한 제품입니다.");
            // dgv 갱신
            

            // 첫번째 그리드 뷰에 대한 모든 체크박스 없앰
            foreach (DataGridViewRow row in dgv.Rows)
                dgv[0, row.Index].Value = null;

            // 두번째 필요 수량은 변경 가능하도록 설정
            foreach (DataGridViewRow row in dgv2.Rows)
                dgv2[5, row.Index].ReadOnly = false;
            
        }


        private void btnUnRegister_Click_1(object sender, EventArgs e) // 재료 삭제
        {

            List<int> DelList = new List<int>();
            for (int i = dgv2.Rows.Count - 1; i > -1; i--)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv2[0, i];

                if (chk.Value == null)
                    continue;

                if ((bool)chk.Value == true)
                    DelList.Add(i);
            }

            if (DelList.Count > 0)
            {
                foreach (int dr in DelList)
                {
                    CheckedList.RemoveAt(dr);
                }
            }

            dgv2.DataSource = null;
            dgv2.DataSource = CheckedList;
            // dgv2가 체크된 것이 모두 해제
            foreach (DataGridViewRow row in dgv2.Rows)
                dgv2[0, row.Index].Value = null;
        }

        
    }
    
}
