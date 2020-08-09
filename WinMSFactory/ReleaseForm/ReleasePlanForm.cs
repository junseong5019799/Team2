﻿using MSFactoryDAC;
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
            dgv.AddNewColumns("출고예정 번호", "release_no", 100, true, true, false, DataGridViewContentAlignment.MiddleRight) ;
            dgv.AddNewColumns("고객사", "company_id", 100, false, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv.AddNewColumns("고객사명", "company_name", 200, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("출고 요청일", "release_plan_date", 150, true);
            dgv.AddNewColumns("출고 상태", "release_status", 100, true);
            
            dgv.DataSource = releaseService.GetReleasePlan();

            dgv2.AddNewColumns("출고예정 번호", "release_no", 120, false);
            dgv2.AddNewColumns("순번", "release_seq", 80, true);
            dgv2.AddNewColumns("고객사", "company_id", 100, false);
            dgv2.AddNewColumns("품명", "product_id", 150, false);
            dgv2.AddNewColumns("품명", "product_name", 150, true);
            dgv2.AddNewColumns("요청 수량", "order_request_quantity", 80, true);
            dgv2.AddNewColumns("출고 요청일", "release_plan_date", 100, true);
            dgv2.AddNewColumns("출고일", "release_date", 100, true);
            dgv2.AddNewColumns("출고 상태", "release_status", 100, true);
            dgv2.AddNewColumns("최초등록 시각", "first_regist_time", 100, true);
            dgv2.AddNewColumns("최초등록 사원", "first_regist_employee", 100, true);
            dgv2.AddNewColumns("최종등록 시각", "final_regist_time", 100, true);
            dgv2.AddNewColumns("최종등록 사원", "final_regist_employee", 100, true);

            //cboProduct.ComboBinding(releaseService.SelectProductGroup(), "product_id", "product_name", "전체"); 
                        
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
                popfrm.CompanyID = Convert.ToInt32(dgv2.SelectedRows[0].Cells[2].Value);
                popfrm.ReleaseNo = Convert.ToInt32(dgv2.SelectedRows[0].Cells[1].Value);
                
                popfrm.Show();
            }
        }

        //엑셀 불러오기
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
                case ".xls":    
                    connectionString = string.Format(Excel03ConString, filePath, "Yes");//header 포함여부
                    break;
                case ".xlsx": 
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

            // 첫 번째 시트의 데이타를 읽어서 datagridview 에 보이게 함.
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
            rList = releaseService.GetReleasePlan();

            //int searchProduct = Convert.ToInt32(cboProduct.SelectedValue);

            //if (!string.IsNullOrEmpty(searchProduct.ToString()))
            //{
            //    rList = (from item in rList
            //             where item.product_id.Equals(searchProduct)
            //             select item).ToList();
            //}
            //dgv.DataSource = null;
            //dgv.DataSource = rList;
        }

        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
               
            }
        }


        //새로 고침
        private void btnNew_Click(object sender, EventArgs e)
        {
            dgv.DataSource = releaseService.GetReleasePlan();
        }


        //수요 계획
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateRatingForm frm = new CalculateRatingForm();
            frm.Release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            frm.Show();
        }


        //dgv detail
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            DataTable dt = releaseService.GetReleasePlanDetail(release_no);
            dgv2.DataSource = dt;

        }

        //저장 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            ReleaseVO release = new ReleaseVO();
            release.company_id = Convert.ToInt32(dgv2.Rows[0].Cells[2].Value);

            DataTable dt = (DataTable)dgv2.DataSource;

            release.company_id = Convert.ToInt32(dgv2.Rows[0].Cells[2].Value);
            if(releaseService.SaveReleasePlan(dt, release))
            {
                MessageBox.Show("성공");
                dgv.DataSource = releaseService.GetReleasePlan();
                return;
            }
            
        }
    }
}
