﻿using DevExpress.ClipboardSource.SpreadsheetML;
using MSFactoryDAC;
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
            dgv.ColumnHeadersHeight = 30;

            dgv.AddNewColumns("출고예정 번호", "release_no", 100, true, true, false, DataGridViewContentAlignment.MiddleRight) ;
            dgv.AddNewColumns("고객사", "company_id", 100, false, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv.AddNewColumns("고객사명", "company_name", 250, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("주문일", "release_plan_date", 200, true);            
            
            dgv.DataSource = releaseService.GetReleasePlan();

            dgv2.ColumnHeadersHeight = 30;
            dgv2.AddNewColumns("출고예정 번호", "release_no", 120, false);
            dgv2.AddNewColumns("순번", "release_seq", 80, true, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv2.AddNewColumns("고객사", "company_id", 100, false);
            dgv2.AddNewColumns("품명", "product_id", 80, false);
            dgv2.AddNewColumns("품명", "product_name", 150, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("요청 수량", "order_request_quantity", 80, true, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv2.AddNewColumns("주문일", "release_plan_date", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("출고 요청일", "release_request_date", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("출고 예정일", "release_date", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("출고 상태", "release_status", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("최초등록 시각", "first_regist_time", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("최초등록 사원", "first_regist_employee", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("최종등록 시각", "final_regist_time", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv2.AddNewColumns("최종등록 사원", "final_regist_employee", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);

            btnInsert.Enabled = false;                       
          
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

                    oda.SelectCommand = new OleDbCommand("SELECT * From [" + sheetName + "] where release_seq  > 0 ", conn);
                    conn.Open();

                    oda.Fill(dt);
                    conn.Close();

                    dgv2.DataSource = dt;                    
                }
            }
        }


        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            List<ReleaseVO> rList = new List<ReleaseVO>();
            rList = releaseService.GetReleasePlan();

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {              
                string fromDate = fromToDateControl1.From.ToShortDateString();
                string toDate = fromToDateControl1.To.ToShortDateString();

                rList = releaseService.GetReleasePlanByDate(fromDate, toDate); 
               
                dgv.DataSource = null;
                dgv.DataSource = rList;

            }
        }

        //등록 추가 버튼
        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgv2.SelectedCells.Count == 0)
                {
                    MessageBox.Show("출고 할 목록을 선택하세요");
                    return;
                }
                else
                {
                    ReleaseOutPopUpForm popfrm = new ReleaseOutPopUpForm();
                    popfrm.CompanyID = Convert.ToInt32(dgv2.SelectedRows[0].Cells[2].Value);
                    popfrm.ReleaseNo = Convert.ToInt32(dgv2.SelectedRows[0].Cells[1].Value);

                    popfrm.Show();
                }
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
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("수요계획 할 내역을 선택하세요.");
                return;
            }            
            else
            {
                for (int i = 0; i < dgv2.RowCount; i++)
                {
                    if (dgv2.Rows[i].Cells[9].Value.ToString() == "출고취소")
                    {
                        MessageBox.Show("출고 취소 된 항목이 있습니다. 납기일을 변경 해주세요.");
                        return;
                    }
                    if(dgv2.Rows[i].Cells[9].Value.ToString() == "출고완료")
                    {
                        MessageBox.Show("이미 출고 완료된 항목이 있습니다.");
                        return;
                    }
                    else
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic["PROG_NAME"] = "수요계획";
                        dic["PROG_FORM_NAME"] = "CalculateRatingForm";
                        dic["Search"] = "Y";

                        CalculateRatingForm frm = (CalculateRatingForm)this.GetMdiParent().MdiChildrenShow(dic);
                        frm.Release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                    }
                }

                
            }
        }

        //dgv detail
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int release_no = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            DataTable dt = releaseService.GetReleasePlanDetail(release_no);
            dgv2.DataSource = dt;

            if (dgv2.SelectedRows[0].Cells[9].Value.ToString().Length < 1)
                btnInsert.Enabled = true;
            else
                btnInsert.Enabled = false;

            for (int i = 0; i < dgv2.RowCount; i++)
            {
                if (dgv2.Rows[i].Cells[9].Value.ToString() == "출고취소")
                {
                    dgv2.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }

            dgv2.ClearSelection();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                openFileDialog1.Title = "엑셀 파일 불러오기";
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                    btnInsert.Enabled = true;                
                else
                    btnInsert.Enabled = false;
            }
        }


        /// <summary>
        /// 출고주문 저장하기 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            ReleaseVO release = new ReleaseVO();
            release.company_id = Convert.ToInt32(dgv2.Rows[0].Cells[2].Value);

            DataTable dt = (DataTable)dgv2.DataSource;

            release.company_id = Convert.ToInt32(dgv2.Rows[0].Cells[2].Value);

            //
            if (releaseService.SaveReleasePlan(dt, release))
            {
                MessageBox.Show("출고 요청서를 추가하였습니다.");

                dgv.DataSource = releaseService.GetReleasePlan();
                dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv.Rows[0].Cells[0].Value));
                               
                int release_no = Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value);                

                for (int i = 0; i < dgv2.RowCount; i++)
                {
                    if (Convert.ToDateTime(dgv2.Rows[i].Cells[7].Value) < Convert.ToDateTime(dgv2.Rows[i].Cells[8].Value))
                    {
                        releaseService.UpdateReleaseDateCancel(release_no, Convert.ToInt32(dgv2.Rows[i].Cells[3].Value));                       
                    }                                                                 
                }

                dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv.Rows[0].Cells[0].Value));
                //MessageBox.Show("출고 취소 된 항목이 있습니다. 출고 요청일을 확인해주세요.");
            }
        }

        /// <summary>
        /// 납기일 변경하기 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DueDatePopUpForm frm = new DueDatePopUpForm();
            frm.Order_no = Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value);
            frm.Due_date = Convert.ToDateTime(dgv2.SelectedRows[0].Cells[7].Value);
            frm.Product_no = Convert.ToInt32(dgv2.SelectedRows[0].Cells["product_id"].Value);
            frm.Gubun = "출고";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value));

                DateTime request_date = Convert.ToDateTime(dgv2.SelectedRows[0].Cells[7].Value);
                DateTime release_date = Convert.ToDateTime(dgv2.SelectedRows[0].Cells[8].Value);

                if (request_date < release_date)
                {
                    MessageBox.Show("출고 요청일은 출고 예정일보다 빠르면 안됩니다. 다시 변경해주세요.");
                    dgv2.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightCoral;
                    return;
                }
                else
                {
                    releaseService.UpdateReleaseDate(Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value), Convert.ToInt32(dgv2.SelectedRows[0].Cells[3].Value));
                    dgv2.SelectedRows[0].DefaultCellStyle.BackColor = Color.Transparent;
                    dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value));
                }                 
            }
        }


        /// <summary>
        /// 출고완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgv2.SelectedCells.Count == 0)
                {
                    MessageBox.Show("출고 할 목록을 선택하세요");
                    return;
                }
                else
                {
                    for (int i = 0; i < dgv2.RowCount; i++)
                    {
                        if (dgv2.Rows[i].Cells[9].Value.ToString() == "출고취소")
                        {
                            MessageBox.Show("출고 취소 된 항목입니다. 출고 등록 먼저 해주세요.");
                            return;
                        }
                        else if (dgv2.Rows[i].Cells[9].Value.ToString() == "출고완료")
                        {
                            MessageBox.Show("이미 출고 완료 된 항목입니다.");
                            return;
                        }
                    }

                    ReleaseOutPopUpForm popfrm = new ReleaseOutPopUpForm();
                    popfrm.CompanyID = Convert.ToInt32(dgv2.SelectedRows[0].Cells["company_id"].Value);
                    popfrm.CompanyName = dgv.SelectedRows[0].Cells["company_name"].Value.ToString();
                    popfrm.ProductNo = Convert.ToInt32(dgv2.SelectedRows[0].Cells["product_id"].Value);
                    popfrm.ReleaseNo = Convert.ToInt32(dgv2.SelectedRows[0].Cells["release_no"].Value);
                    popfrm.ReleaseSeq = Convert.ToInt32(dgv2.SelectedRows[0].Cells["release_seq"].Value);
                    popfrm.RequestQuantity = Convert.ToInt32(dgv2.SelectedRows[0].Cells["order_request_quantity"].Value);
                   
                    if(popfrm.ShowDialog() == DialogResult.OK) 
                    {
                        dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value));
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// 출고 삭제하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제 할 목록을 선택하세요");
                return;
            }
            else
            {            
                for (int i = 0; i < dgv2.RowCount; i++)
                {
                    if (dgv2.Rows[i].Cells[9].Value.ToString() == "출고완료")
                    {
                        MessageBox.Show("이미 출고된 항목입니다.");
                        return;
                    }
                }

                if(MessageBox.Show("정말 삭제하시겠습니까?","출고항목 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int release_no = Convert.ToInt32(dgv2.SelectedRows[0].Cells["release_no"].Value);
                    int product_no = Convert.ToInt32(dgv2.SelectedRows[0].Cells["product_id"].Value);

                    if(releaseService.DeleteReleasePlan(release_no, product_no))
                    {
                        MessageBox.Show("해당 항목을 삭제했습니다.");
                        dgv.DataSource = releaseService.GetReleasePlan();
                        dgv2.DataSource = releaseService.GetReleasePlanDetail(Convert.ToInt32(dgv2.SelectedRows[0].Cells[0].Value));
                        return;
                    }
                }            


            }
        }
    }
}
