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
using WinCoffeePrince2nd.Util;
using WinMSFactory.Process;
using WinMSFactory.Services;

namespace WinMSFactory
{
    //법인 관리
    public partial class CorporationForm : ListForm
    {
        List<CorporationVO> search;
        public CorporationForm()
        {
            InitializeComponent();
        }

        private void CorporationForm_Load(object sender, EventArgs e)
        {
            dgvCorporationlist.IsAllCheckColumnHeader = true;

            dgvCorporationlist.AddNewColumns("법인코드", "corporation_id", 100, true);
            dgvCorporationlist.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvCorporationlist.AddNewColumns("법인순번", "corporation_seq", 100, true);
            dgvCorporationlist.AddNewColumns("비고1", "corporation_note1", 100, true);
            dgvCorporationlist.AddNewColumns("비고2", "corporation_note2", 100, true);
            dgvCorporationlist.AddNewColumns("법인 사용여부", "corporation_use", 100, true);
            dgvCorporationlist.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvCorporationlist.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvCorporationlist.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvCorporationlist.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);

            LoadData();

        }

        private void LoadData()
        {
            CorporationService service = new CorporationService();
            search = service.GetSearch(string.Empty);

            dgvCorporationlist.DataSource = search;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (txtNameSearch.Text.Length < 1)
                dgvCorporationlist.DataSource = search;
            else
            {
                var searchlist = (from name in search
                                  where name.corporation_name.Contains(txtNameSearch.Text)
                                  select name).ToList();
                dgvCorporationlist.DataSource = null;
                dgvCorporationlist.DataSource = searchlist;
            }
        }

        private void dgvCorporationlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CorporationVO corporation = new CorporationVO();
            corporation.corporation_id = Convert.ToInt32(dgvCorporationlist.SelectedRows[0].Cells[1].Value); //코드
            corporation.corporation_name = dgvCorporationlist.SelectedRows[0].Cells[2].Value.ToString(); // 이름
            corporation.corporation_seq = Convert.ToInt32(dgvCorporationlist.SelectedRows[0].Cells[3].Value);//순번
            corporation.corporation_note1 = dgvCorporationlist.SelectedRows[0].Cells[4].Value.ToString();
            corporation.corporation_note2 = dgvCorporationlist.SelectedRows[0].Cells[5].Value.ToString();
            corporation.corporation_use = dgvCorporationlist.SelectedRows[0].Cells[6].Value.ToString();
            corporation.first_regist_time = Convert.ToDateTime(dgvCorporationlist.SelectedRows[0].Cells[7].Value);
            corporation.first_regist_employee = dgvCorporationlist.SelectedRows[0].Cells[8].Value.ToString();
            corporation.final_regist_time = Convert.ToDateTime(dgvCorporationlist.SelectedRows[0].Cells[9].Value);
            corporation.final_regist_employee = dgvCorporationlist.SelectedRows[0].Cells[10].Value.ToString();

            CorporationPopupForm cp = new CorporationPopupForm(this, corporation);

            if (cp.ShowDialog() == DialogResult.OK)
            {
                dgvCorporationlist.Columns.Clear();
                CorporationForm_Load(null, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CorporationPopupForm cp = new CorporationPopupForm();

            if (cp.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
            LoadData();
        }

        private void btnDelere_Click(object sender, EventArgs e)
        {
            CorporationService service = new CorporationService();

            if (MessageBox.Show("법인을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                dgvCorporationlist.EndEdit();

                List<int> CheckList = new List<int>(); // 체크한 제품 번호들을 담는다.

                foreach (DataGridViewRow row in dgvCorporationlist.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvCorporationlist[0, row.Index];

                    if (chk.Value == null)
                        continue;

                    else if ((bool)chk.Value == true)
                        CheckList.Add(dgvCorporationlist[1, row.Index].Value.ToInt());

                }

                int corporation_id = Convert.ToInt32(dgvCorporationlist.SelectedRows[0].Cells[1].Value);

                if (CheckList.Count > 0)
                {
                    service.Delete(CheckList);
                 
                    LoadData();
                }
                //else if (CheckList.Count > 1)
                //{
                //    foreach (int item in CheckList)
                //    {
                //        service.Delete(corporation_id);
                //    }
                //}
                else
                {
                    MessageBox.Show("다시 선택해주세요");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
