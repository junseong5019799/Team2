using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class DowntimeTypeForm : ListForm
    {
        DataTable dtDgv;
        DowntimeTypeService service = new DowntimeTypeService();


        public DowntimeTypeForm()
        {
            InitializeComponent();
        }

        private void DowntimeTyreForm_Load(object sender, EventArgs e)
        {
            dgvDowntimeType.IsAllCheckColumnHeader = true;

            dgvDowntimeType.AddNewColumns("비가동코드", "downtime_type_id", 100, true);
            dgvDowntimeType.AddNewColumns("비가동 명", "downtime_type_name", 100, true);
            dgvDowntimeType.AddNewBtnCol("시간계산여부", "", new Padding(1, 1, 1, 1), false); // 3 // 버튼 부분은 false
            dgvDowntimeType.AddNewColumns("시간계산여부", "downtime_type_calculation", 100, true); //4
            dgvDowntimeType.AddNewColumns("비가동순번", "downtime_type_seq", 100, true);
            dgvDowntimeType.AddNewBtnCol("사용여부", "", new Padding(1, 1, 1, 1), false); // 6 버튼 // 버튼 부분은 false
            dgvDowntimeType.AddNewColumns("비가동사용여부", "downtime_type_use", 100, true); //7
            dgvDowntimeType.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvDowntimeType.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvDowntimeType.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvDowntimeType.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);

            LoadData();
        }

        private void LoadData()
        {

            dtDgv = service.GetAll();

            dgvDowntimeType.DataSource = null;
            dgvDowntimeType.DataSource = dtDgv;

        }

        private void dgvDowntimeType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 여기 부분은 버튼 사용 부분입니다. 참고용으로 적어놓았고, 실제 작동은 되지 않습니다.!!
            // 작동 시키려면 버튼 컬럼의 Visible를 true로 바꾼 후 사용 바랍니다.!!

            //if (e.RowIndex < 0 || e.ColumnIndex == 3 || e.ColumnIndex == 6)
            //    return;

            if (e.RowIndex < 0)
                return;

            DowntimeTypeVO updatevo = new DowntimeTypeVO
            {
                downtime_type_id = dgvDowntimeType[1, e.RowIndex].Value.ToInt(),
                downtime_type_name = dgvDowntimeType[2, e.RowIndex].Value.ToString(),
                downtime_type_calculation = dgvDowntimeType[4, e.RowIndex].Value.ToString(),
                downtime_type_seq = dgvDowntimeType[5, e.RowIndex].Value.ToInt(),
                downtime_type_use = dgvDowntimeType[7, e.RowIndex].Value.ToString(),
            };
            OpenPopup(true, updatevo);
        }

        private void OpenPopup(bool IsUpdate, DowntimeTypeVO vo = null)
        {
            DowntimeTypePopupForm frm = new DowntimeTypePopupForm(IsUpdate, vo);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        // 여기 부분은 버튼 사용 부분입니다. 참고용으로 적어놓았고, 실제 작동은 되지 않습니다.!!
        // 작동 시키려면 버튼 컬럼의 Visible를 true로 바꾼 후 사용 바랍니다.!!
        private void dgvDowntimeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int downtime_type_id = dgvDowntimeType[1, e.RowIndex].Value.ToInt();
            string downtime_type_calculation = dgvDowntimeType[3, e.RowIndex].Value.ToString();
            string downtime_type_use = dgvDowntimeType[6, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == 6)
            {

                if (dgvDowntimeType[6, e.RowIndex].Value.ToString() == "사용")
                {
                    if (service.UseTypeChange(downtime_type_id, "N"))
                        dgvDowntimeType[6, e.RowIndex].Value = "미사용";
                }
                else if (dgvDowntimeType[6, e.RowIndex].Value.ToString() == "미사용")
                {
                    if (service.UseTypeChange(downtime_type_id, "Y"))
                        dgvDowntimeType[6, e.RowIndex].Value = "사용";
                }

                LoadData();
                dgvDowntimeType.ClearSelection();

            }
          
            if (e.ColumnIndex == 3)
            {

                if (dgvDowntimeType[3, e.RowIndex].Value.ToString() == "적용")
                {
                    if (service.UseTypeChange(downtime_type_id, null, "N"))
                        dgvDowntimeType[3, e.RowIndex].Value = "미적용";
                }
                else if (dgvDowntimeType[3, e.RowIndex].Value.ToString() == "미적용")
                {
                    if (service.UseTypeChange(downtime_type_id, null, "Y"))
                        dgvDowntimeType[3, e.RowIndex].Value = "적용";
                }
                LoadData();
                dgvDowntimeType.ClearSelection();

            }
        }
        // 여기 부분은 버튼 사용 부분입니다. 참고용으로 적어놓았고, 실제 작동은 되지 않습니다.!!
        // 작동 시키려면 버튼 컬럼의 Visible를 true로 바꾼 후 사용 바랍니다.!!
        private void dgvDowntimeType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDowntimeType.Rows)
            {
                if (dgvDowntimeType[7, row.Index].Value.ToString() == "Y")
                    dgvDowntimeType[6, row.Index].Value = "사용";
                else if (dgvDowntimeType[7, row.Index].Value.ToString() == "N")
                    dgvDowntimeType[6, row.Index].Value = "미사용";
            }

            foreach (DataGridViewRow row in dgvDowntimeType.Rows)
            {
                if (dgvDowntimeType[4, row.Index].Value.ToString() == "Y")
                    dgvDowntimeType[3, row.Index].Value = "적용";
                else if (dgvDowntimeType[4, row.Index].Value.ToString() == "N")
                    dgvDowntimeType[3, row.Index].Value = "미적용";
            }
        }

        private void Search(object sender, EventArgs e)
        {
            dgvDowntimeType.EndEdit();
         
           
            string fname = txtName.Text.Trim();

            dtDgv = service.GetAll();

            DataView dv = dtDgv.DefaultView;
            if (fname.Length > 0)
            {
                dv.RowFilter = $"downtime_type_name like '%{fname}%'";
            }
            dgvDowntimeType.DataSource = dv;
            DataTable dt = dv.ToTable();
            List<DowntimeTypeVO> sortedData = SqlHelper.ConvertDataTableToList<DowntimeTypeVO>(dt);

            dgvDowntimeType.DataSource = sortedData;
        }

        private void Add(object sender, EventArgs e)
        {
            if(((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                DowntimeTypePopupForm frm = new DowntimeTypePopupForm(false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if(MessageBox.Show("비가동명을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

                try
                {
                    dgvDowntimeType.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvDowntimeType.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDowntimeType[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvDowntimeType[1, row.Index].Value.ToInt());

                    }

                    int downtime_type_id = Convert.ToInt32(dgvDowntimeType.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        service.DowntimeTypeDelete(CheckList);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("다시 선택해주세요");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            txtName.Text = "";
            LoadData();
        }
    }
}
