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
using WinMSFactory.Services;

namespace WinMSFactory.BOM
{
    
    public partial class BomForm : BasicForm
    {
        BomService service = new BomService();
        List<BomVO> SelectedAllMaterial;
        List<BomVO> CheckMaterialList;

        public ProductInsertVO ProductInfo { get; set; }

        // BOM 등록 및 수정
        public BomForm()
        {
            InitializeComponent();
            CheckMaterialList = new List<BomVO>();
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            // 왼쪽 그리드 뷰에는 반제품, 재료 만 조회 가능
            cboSearch.ComboBinding(BomService.CboProductType(), "Member", "");
            cboType.ComboBinding(service.SelectAllGroup(),"Product_Group_ID", "Product_Group_Name");

            rdoActive.Checked = true;
            btnSubmit.Enabled = false;
            dgv.ReadOnly = true;
            
            MaterialColumns();
            SelectedAllMaterial = service.SelectMaterialSettings("반제품", "재료");
            dgv.DataSource = SelectedAllMaterial; // 반제품, 재료만 조회

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

            dgv2.AddNewColumns("번호", "Product_ID", 100, false);
            dgv2.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv2.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv2.AddNewColumns("품명 스펙", "Product_Information", 100, true);
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

            for(int i = 0; i<dgv.Rows.Count; i++)
            {
                int dgvNum = dgv[0, i].Value.ToInt();
                List<BomVO> slist = (List<BomVO>)dgv2.DataSource;
                if(slist != null)
                {
                    if (slist.FindAll(p => p.Product_ID == dgvNum).Count > 0)
                    {
                        dgv[1, i].Value = "선택 취소";
                        continue; 
                    }
                }
                break; // slist가 null일때 중단 ,slist가 존재하나, 데이터가 존재하지 않은 경우
            }
           
        }
        //int SelectedIndex = 0;

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in dgv.Rows)
                dgv[1, row.Index].Value = "선택";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1)
            {
                NumericControl num = new NumericControl();
                num.Location = new Point(0, 21 * pnlNumeric.Controls.Count);
               
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

                    CheckMaterialList.Add(bo);

                    pnlNumeric.Controls.Add(num);
                }
                else 
                {
                    dgv[1, e.RowIndex].Value = "선택";

                    int DeleteIndex = CheckMaterialList.FindIndex(p => bo.Product_ID == p.Product_ID);

                    CheckMaterialList.RemoveAt(DeleteIndex);

                    pnlNumeric.Controls.RemoveAt(dgv2.Rows.Count-1);
                }

                dgv2.DataSource = null;
                dgv2.DataSource = CheckMaterialList;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 초기화 진행 시
            cboSearch.SelectedIndex = 0;
            dgv.DataSource = SelectedAllMaterial;

            // 선택된 모든것들을 선택안한 상태로 바꿔줌
            for(int i = 0; i<dgv2.Rows.Count; i++)
            {
                dgv[1, i].Value = "선택"; // 선택이 안되어있는 상태로 바꿔줌
            }

            CheckMaterialList.Clear();
            dgv2.DataSource = null;

            pnlNumeric.Controls.Clear();
            txtProductName.Clear();
            groupBox1.Enabled = groupBox2.Enabled = true;
            lblMessage.Text = "제품 정보 등록을 진행해주시기 바랍니다.";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtProductName.TextLength < 1)
            {
                MessageBox.Show("등록할 제품명을 입력해주세요");
                return;
            }
            // 제품 관리에 등록
            ProductInsertVO ProductInsertInfo = ProductInfo;

            ProductInsertInfo.First_Regist_Time = ProductInsertInfo.Final_Regist_Time = DateTime.Now;
            ProductInsertInfo.First_Regist_Employee = ProductInsertInfo.Final_Regist_Employee = "직원명";     // 나중에 여기에 직원명 써줄 것
            // 이 값을 넘겨주면 제품 관리에 들어감!!!

            // BOM 테이블에 등록
            List<BOMInsertVO> InsertBOMLists = new List<BOMInsertVO>();
            
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                NumericUpDown ctrl = (NumericUpDown)pnlNumeric.Controls[i];
                InsertBOMLists.Add(new BOMInsertVO
                {
                    Product_ID = dgv2[i, 0].Value.ToInt(),   // 재료들의 ID
                    Bom_Use_Quantity = ctrl.Value.ToInt(),
                    // Bom_Seq =          ??
                    // Bom_Use = UseCheck  ??
                });
            }
            //if (service.InsertProducts(ProductInsertInfo, InsertBomLists))
            {
                // Insert, ProductInsertInfo, InsertBomLists를 매개변수로 넘겨줄 것
                // 등록되면 로그에 추가되도록 설정할 것
            }
        }

        

        private void buttonControl2_Click(object sender, EventArgs e)
        {
            if(txtProductName.TextLength<1)
            {
                MessageBox.Show("제품명을 등록해주시기 바랍니다.");
                return;
            }
            if(dgv2.Rows.Count<1)
            {
                MessageBox.Show("조합할 재료를 등록해주시기 바랍니다.");
                return;
            }
            SendInfoVO send = new SendInfoVO
            {
                UseCheck = rdoActive.Checked,
                ProductName = txtProductName.Text,
                ProductGroup = cboType.Text,
                ProductGroupNum = cboType.SelectedValue.ToInt()
            };

            ProductInfoForm frm = new ProductInfoForm(this, send);

            if(frm.ShowDialog() == DialogResult.OK)
            {
                btnSubmit.Enabled = true;
                btnInsertInfo.Visible = false;
                groupBox1.Enabled = groupBox2.Enabled = false;
                lblMessage.Text = "등록을 진행해주세요";
            }
        }
    }
    
}
