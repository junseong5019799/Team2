using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.ReleaseForm;

namespace WinMSFactory
{
    public partial class ReleasePlanForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();       
        
        public ReleasePlanForm()
        {
            InitializeComponent();
        }

        private void ReleasePlanForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "", 100, true);
            dgv.AddNewColumns("거래처", "", 100, true);
            dgv.AddNewColumns("거래처명", "", 100, true);
            dgv.AddNewColumns("출고 요청일", "", 100, true);
            dgv.AddNewColumns("품목 코드", "", 100, true);
            dgv.AddNewColumns("요청 수량", "", 100, true);
            dgv.AddNewColumns("출고 상태", "", 100, true);
            dgv.AddNewColumns("출고일", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 시각", "", 100, true);
            dgv.AddNewColumns("최초등록 시각", "", 100, true);
            dgv.AddNewColumns("최종등록 사원", "", 100, true);

            dgv.DataSource = releaseService.GetReleasePlan();

            dgv2.AddNewColumns("순번", "", 80, true);
            dgv2.AddNewColumns("출고예정 번호", "", 150, true);
            dgv2.AddNewColumns("거래처", "", 150, true);
            dgv2.AddNewColumns("품명", "", 150, true);
            dgv2.AddNewColumns("요청 수량", "", 150, true);
            dgv2.AddNewColumns("납기일", "", 200, true);

            cboProduct.ComboBinding(releaseService.SelectProductGroup(), "Product_Group_ID", "Product_Group_Name"); 
                        
        }


        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        /// <summary>
        /// 등록하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedCells.Count == 0)
            {
                MessageBox.Show("출고 할 목록을 선택하세요");
                return;
            }
            else
            {
                ReleaseExcelPopUpForm popfrm = new ReleaseExcelPopUpForm();
                //popfrm.CompanyName = dgv2.SelectedRows[0].Cells[2].Value.ToString();
                //popfrm.PlanID = Convert.ToInt32(dgv2.SelectedRows[0].Cells[1].Value);
                popfrm.Show();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "엑셀 파일 불러오기";
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog1.ShowDialog();
            
            
        }

        /// <summary>
        /// Import 엑셀 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //두가지 엑셀 엔진종류
            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";


            string filePath = openFileDialog1.FileName;
            string fileExtension = System.IO.Path.GetExtension(filePath);
            string connectionString = string.Empty;
            string sheetName = string.Empty;

            // 확장자로 구분하여 커넥션 스트링을 가져옮
            switch (fileExtension)
            {
                case ".xls":    //Excel 97-03
                    connectionString = string.Format(Excel03ConString, filePath, "Yes");//header 포함여부
                    break;
                case ".xlsx":  //Excel 07
                    connectionString = string.Format(Excel07ConString, filePath, "Yes");
                    break;
            }

            // 첫 번째 시트의 이름을 가져옮
            // 이름을 아는 경우에는 [Sheet$] 으로 한다.  이름을 모를 경우에 이 부분을 추가.
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    DataTable dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    conn.Close();
                }
            }

            // 첫 번째 쉬트의 데이타를 읽어서 datagridview 에 보이게 함.
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter oda = new OleDbDataAdapter())
                {
                    DataTable dt = new DataTable();
                    oda.SelectCommand = new OleDbCommand("SELECT * From [" + sheetName + "]", conn);
                    conn.Open();
                    oda.Fill(dt);
                    conn.Close();

                    dgv2.DataSource = dt;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ReleaseVO> rList = new List<ReleaseVO>();

            string searchType = Convert.ToString(cboProduct.SelectedValue);

            if (!string.IsNullOrEmpty(searchType))
            {
                rList = (from item in rList
                         where item.product_id.Equals(searchType)
                         select item).ToList();
            }
            dgv2.DataSource = null;
            dgv2.DataSource = rList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            releaseService.GetReleasePlan();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateRatingForm frm = new CalculateRatingForm();
            frm.Show();
        }
    }
}
