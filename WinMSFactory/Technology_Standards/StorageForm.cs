using DevExpress.Utils.Behaviors.Common;
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
    public partial class StorageForm : ListForm
    {
        StorageService ss = new StorageService();
        FactoryService fs = new FactoryService();
        CorporationService cs = new CorporationService();
        List<StorageVO> list;
        EmployeeVO emp;

        int CorpValue;
        int FacValue;

        // 창고 진행중...

        public StorageForm()
        {
            InitializeComponent();
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            dgv.IsAllCheckColumnHeader = true;

            dgv.AddNewColumns("창고 ID", "storage_id", 150, true);
            dgv.AddNewColumns("법인명", "corporation_name", 150, true);
            dgv.AddNewColumns("공장명", "factory_name", 150, true);
            dgv.AddNewColumns("창고명", "storage_name", 150, true);
            dgv.AddNewColumns("사용 여부", "storage_use", 150, true);
            dgv.AddNewColumns("창고 순번", "storage_seq", 150, true);
            dgv.AddNewColumns("최초등록시간", "first_regist_time", 150, true);
            dgv.AddNewColumns("최초등록직원", "first_regist_employee", 150, true);
            dgv.AddNewColumns("최종등록시간", "final_regist_time", 150, true);
            dgv.AddNewColumns("최종등록직원", "final_regist_employee", 150, true);

            emp = this.GetEmployee();


            dgv.DataSource = ss.SelectStorage();
            List<CorporationVO> corpInfo = cs.CorporationComboBinding();
            //corpInfo.Insert(0, new CorporationVO
            //{
            //    corporation_id = 0,
            //    corporation_name = "전체"
            //});

            cboCorporation.SelectedIndexChanged += CorporationChange;
            cboCorporation.ComboBinding(corpInfo, "corporation_id", "corporation_name", "전체", 0);
        }

        private void CorporationChange(object sender, EventArgs e)
        {
            list = (List<StorageVO>)dgv.DataSource;
            CorpValue = cboCorporation.SelectedValue.ToInt();
            List<FactoryVO> factoryInfo = fs.FactoryComboBindings(CorpValue);
            factoryInfo.Insert(0, new FactoryVO
            {
                factory_id = 0,
                factory_name = "전체"
            });

            cboFactoryName.ComboBinding(factoryInfo, "factory_id", "factory_name");

            dgv.DataSource = ss.SelectStorage(CorpValue);
            cboFactoryName.SelectedIndexChanged += FactoryChange;
        }

        private void FactoryChange(object sender, EventArgs e)
        {
            list = (List<StorageVO>)dgv.DataSource;
            FacValue = cboFactoryName.SelectedValue.ToInt();
            List<StorageVO> storageInfo = ss.StorageComboBindings(CorpValue, FacValue);

            storageInfo.Insert(0, new StorageVO
            {
                Storage_Id = 0,
                Storage_Name = "전체"
            });

            dgv.DataSource = ss.SelectStorage(CorpValue, FacValue);
        }

        private void ReviewDGV()
        {
            dgv.DataSource = null;
            dgv.DataSource = ss.SelectStorage();
        }


        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            StorageVO updatevo = new StorageVO
            {
                Storage_Id = dgv[1, e.RowIndex].Value.ToInt(),
                Corporation_Name = dgv[2, e.RowIndex].Value.ToString(),
                Factory_Name = dgv[3, e.RowIndex].Value.ToString(),
                Storage_Name = dgv[4, e.RowIndex].Value.ToString(),
                Storage_Use = dgv[5, e.RowIndex].Value.ToString(),
                Storage_Seq = dgv[6, e.RowIndex].Value.ToInt()
                //Final_regist_time = DateTime.Now,
                //Final_regist_employee = employee.Employee_name
            };

            OpenPopup(true, updatevo);
        }

        private void OpenPopup(bool IsUpdate, StorageVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                StoragePopupForm frm = new StoragePopupForm(emp.Employee_name, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    ReviewDGV();
            }
        }
        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                StoragePopupForm frm = new StoragePopupForm(emp.Employee_name, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    ReviewDGV();
            }

        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (txtStorage.TextLength > 0)
                {
                    var Searchlist = (from items in list
                                      where items.Storage_Name.Contains(txtStorage.Text)
                                      select items).ToList();

                    dgv.DataSource = Searchlist;
                }
                else
                    dgv.DataSource = list;
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("창고정보을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgv.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgv[1, row.Index].Value.ToInt());

                    }

                    int storage_id = Convert.ToInt32(dgv.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        ss.StorageDelete(CheckList);

                        ReviewDGV();
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
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboCorporation.SelectedIndex = 0;
                cboFactoryName.SelectedIndex = 0;
                txtStorage.Text = "";
                ReviewDGV();
            }
        }
    }
}
