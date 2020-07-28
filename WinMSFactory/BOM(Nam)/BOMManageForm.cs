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
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory.BOM
{
    
    public partial class BOMManageForm : BasicForm
    {
        BomService bomSv = new BomService();
        ProductGroupService pdgSv = new ProductGroupService();

        List<BomVO> SelectedAllMaterial;
        List<BomVO> CheckedList;

        new string ProductName;
        int ProductID;

        char BOMEnrollStatus; // DB에 Insert

        bool BomEnrollCheck; // 등록, 수정 결정
        bool IsBomUpdateData = false;

        // BOM 등록 및 수정
        public BOMManageForm(bool BomEnrollCheck, int ProductID, string ProductName, char BOMEnrollStatus)
        {
            InitializeComponent();
            CheckedList = new List<BomVO>();
            this.BomEnrollCheck = BomEnrollCheck;
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.BOMEnrollStatus = BOMEnrollStatus;

            if(BomEnrollCheck == true)
            {
                this.Text = "BOM 수정";
                btnSubmit.Text = "수정";
            }
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            // 왼쪽 그리드 뷰에는 반제품, 재료 만 조회 가능
            cboSearch.ComboBinding(BomService.CboProductType(), "ValueMember", "Member");
            cboType.ComboBinding(pdgSv.ProductGroupComboBindingsNotAll(),"Product_Group_ID", "Product_Group_Name");

            txtProductName.Text = ProductName;

            dgv.IsAllCheckColumnHeader = true;
            dgv2.IsAllCheckColumnHeader = true;

            MaterialColumns();
            SelectedAllMaterial = bomSv.SelectMaterialSettings("반제품", "재료", ProductID);
            dgv.DataSource = SelectedAllMaterial; // 반제품, 재료만 조회

            if(BomEnrollCheck == true)
            {
                CheckedList = bomSv.BOMEnrolledMaterial(ProductID);
            }

            dgv2.DataSource = CheckedList;
        }

        private void MaterialColumns()
        {
            dgv.AddNewColumns("번호", "Product_ID", 100, true);
            dgv.AddNewColumns("제품 그룹명", "Product_Group_Name", 140, true);
            dgv.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv.AddNewColumns("기본 단위", "Product_Unit", 100, true);
            dgv.AddNewColumns("비고 1", "Product_Note1", 100, true);
            dgv.AddNewColumns("비고 2", "Product_Note2", 100, true);

            dgv2.AddNewColumns("번호", "Product_ID", 100, false);
            dgv2.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv2.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv2.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv2.AddNewColumns("필요 수량", "Bom_Use_Quantity", 100, true);
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
            cboSearch.SelectedIndex = 0;
            cboSearch.ComboBinding(BomService.CboProductType(), "ValueMember", "Member");
            dgv.Columns.Clear();
            dgv2.Columns.Clear();
            BOMManageForm_Load(null, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
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
            
            // dgv2에서 목록 Sorting
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                InsertBOMLists.Add(new BOMInsertUpdateVO
                {
                    Higher_Product_ID = ProductID,
                    Lower_Product_ID = dgv2[1,i].Value.ToInt(),   // 재료들의 ID
                    Bom_Use_Quantity = dgv2[5,i].Value.ToInt(),
                    Final_Regist_Time = DateTime.Now.Date,
                    Final_Regist_Employee = "직원명",                        // 나중에 로그인 완성시 직원 명 넣어줄 것
                    Bom_Status = BOMEnrollStatus// BOM 사용 여부 넣어줄 것
                }) ;
            }


            if (bomSv.InsertUpdateProduct(InsertBOMLists))
            {
                string Status_String = string.Empty;

                if (BomEnrollCheck == true)
                    Status_String = "BUS";
                else
                    Status_String = "BIS";

                // BOM Log에 등록
                BomLogVO AddLog = new BomLogVO
                {
                    High_Product_ID = ProductID,
                    Bom_Enroll_Date = DateTime.Now,
                    Employee_ID = "홍길동",                                 // 직원명, ID는 회원가입이 만들어진 후 꼭 수정할 것
                    Bom_Log_Status = Status_String,             // BOM 입력
                    Bom_Exists = 'Y'
                };
                BomLogService service = new BomLogService();

                service.InsertLogs(AddLog);

                MessageBox.Show("BOM 등록이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //InitListCheck();

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
            //InitListCheck();

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

        private void InitListCheck()
        {
            if (BomEnrollCheck == true && IsBomUpdateData == false)
            {
                foreach (var a in ((List<BomVO>)dgv2.DataSource))
                {
                    CheckedList.Add(a);
                }
                IsBomUpdateData = true;
            }
        }
    }
    
}
