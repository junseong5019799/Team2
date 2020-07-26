using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;

namespace WinMSFactory.BOM
{
    
    public partial class BOMUpdateForm : BasicForm
    {
        BomService bomSv = new BomService();
        ProductGroupService pdgSv = new ProductGroupService();

        List<BomVO> SelectedAllMaterial;
        List<BomVO> CheckMaterialList;
        char UseCheck = 'Y';

        public ProductInsertVO ProductInfo { get; set; }
        public string ProductNm { get; set; }
        public int ProductID { get; set; }// HIGHER_ID
        public char BOMEnrollStatus { get; set; }

        // BOM 등록 및 수정
        public BOMUpdateForm()
        {
            InitializeComponent();

            CheckMaterialList = new List<BomVO>();
            
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            MaterialColumns();
            SelectedAllMaterial = bomSv.SelectMaterialSettings("반제품", "재료");
            dgv.DataSource = SelectedAllMaterial; // 반제품, 재료만 조회

            cboSearch.ComboBinding(BomService.CboProductType(), "ValueMember", "Member");
            cboType.ComboBinding(pdgSv.ProductGroupComboBindingsNotAll(), "Product_Group_ID", "Product_Group_Name");

            rdoActive.Checked = true;
            txtProductName.Text = ProductNm; 
            
            dgv2.DataBindingComplete += dgv2_DataBindingComplete;

            dgv2.DataSource = bomSv.BOMEnrolledMaterial(ProductID);

            

        }

        private void MaterialColumns()
        {
            
            dgv.AddNewColumns("번호", "Product_ID", 100, true);
            dgv.AddNewBtnCol("선택", "선택", new Padding(1, 1, 1, 1));
            dgv.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv.AddNewColumns("기본 단위", "Product_Unit", 100, true);
            dgv.AddNewColumns("비고 1", "Product_Note1", 100, true);
            dgv.AddNewColumns("비고 2", "Product_Note2", 100, true);

            dgv2.AddNewColumns("번호", "Product_ID", 100, true);
            dgv2.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv2.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv2.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv2.AddNewColumns("필요 수량", "1", 100, true);
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
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int dgvNum = dgv[0, i].Value.ToInt();
                List<BomVO> slist = (List<BomVO>)dgv2.DataSource;
                if (slist != null)
                {
                    for(int j = 0; j<dgv.Rows.Count; j++)
                    {
                        if (slist.FindAll(p => p.Product_ID == dgvNum).Count > 0)
                        {
                            dgv[1, j].Value = "선택 취소";
                            continue;
                        }
                    }
                    
                } // slist가 null일때 중단 ,slist가 존재하나, 데이터가 존재하지 않은 경우
            }

        }
        

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
                dgv[1, row.Index].Value = "선택";
        }
        private void dgv2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CheckMaterialList.Clear();
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                int dgvNum = dgv2[0, row.Index].Value.ToInt();
                List<BomVO> slist = (List<BomVO>)dgv.DataSource;
                if (slist != null)
                {
                    foreach(DataGridViewRow rows in dgv.Rows)
                    {
                        if (slist[rows.Index].Product_ID == dgvNum)
                        {
                            dgv[1, rows.Index].Value = "선택 취소";

                            CheckMaterialList.Add(slist[rows.Index]);
                            break;
                        }
                    }
                    
                }
                
            }

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1)
            {
               
                BomVO bo = new BomVO
                {
                    Product_ID = dgv[0, e.RowIndex].Value.ToInt(),
                    Product_Group_Name = dgv[2, e.RowIndex].Value.ToString(),
                    Product_Name = dgv[3, e.RowIndex].Value.ToString(),
                    Product_Information = dgv[4, e.RowIndex].Value.ToString()
                };

                if (dgv[1, e.RowIndex].Value.ToString() == "선택")
                {
                    dgv[1, e.RowIndex].Value = "선택 취소";
                    dgv.CurrentRow.DefaultCellStyle.BackColor = Color.Beige;

                    CheckMaterialList.Add(bo);
                }
                else 
                {
                    dgv[1, e.RowIndex].Value = "선택";
                    dgv.CurrentRow.DefaultCellStyle.BackColor = Color.White;

                    int DeleteIndex = CheckMaterialList.FindIndex(p => bo.Product_ID == p.Product_ID);

                    CheckMaterialList.RemoveAt(DeleteIndex);
                }
                dgv2.DataBindingComplete -= dgv2_DataBindingComplete;
                dgv2.DataSource = null;
                dgv2.DataSource = CheckMaterialList;


                // 수량 입력할 수 있도록 해줌
                for (int j = 1; j < dgv2.Columns.Count - 1; j++)
                {
                    for (int i = 0; i < dgv2.Rows.Count; i++)
                    {
                        dgv2[j, i].ReadOnly = true;
                        dgv2[4, i].Value = 1;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
                

            if (MessageBox.Show("정말로 등록하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            
            // 이 값을 넘겨주면 제품 관리에 들어감!!!

            // BOM 테이블에 등록
            List<BOMInsertUpdateVO> InsertBOMLists = new List<BOMInsertUpdateVO>();
            
            // dgv2에서 목록 Sorting
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                InsertBOMLists.Add(new BOMInsertUpdateVO
                {
                    Higher_Product_ID = ProductID,
                    Lower_Product_ID = dgv2[0, i].Value.ToInt(),   // 재료들의 ID
                    Bom_Use_Quantity = dgv2[4, i].Value.ToInt(),
                    Final_Regist_Time = DateTime.Now.Date,
                    Final_Regist_Employee = "직원명",                        // 나중에 로그인 완성시 직원 명 넣어줄 것
                    Bom_Use = UseCheck,  // BOM 사용 여부 넣어줄 것
                    Bom_Status = BOMEnrollStatus
                }) ;
            }
            if (bomSv.InsertProducts(InsertBOMLists))
            {
                MessageBox.Show("BOM이 등록되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
                // Insert    =>  InsertBomLists를 매개변수로 넘겨줄 것
                // 등록되면 로그에 추가되도록 설정할 것
            }
        }

        private void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActive.Checked)
                UseCheck = 'Y';
            else if (rdoDeActive.Checked)
                UseCheck = 'N';
        }

        
    }
    
}
