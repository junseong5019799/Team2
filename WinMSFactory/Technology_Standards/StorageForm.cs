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
        int CorpValue;
        int FacValue;
        int StoValue;
        public StorageForm()
        {
            InitializeComponent();
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            dgv.IsAllCheckColumnHeader = true;

            dgv.AddNewColumns("창고 ID", "storage_id", 150, true);
            dgv.AddNewColumns("공장 이름", "Storage_name", 150, true);
            dgv.AddNewColumns("공장 순번", "storage_seq", 150, true);
            dgv.AddNewBtnCol("사용 여부","",new Padding(1,1,1,1));
            dgv.AddNewColumns("최초등록시간", "first_regist_time", 150, true);
            dgv.AddNewColumns("최초등록직원", "first_regist_employee", 150, true);
            dgv.AddNewColumns("최종등록시간", "final_regist_time", 150, true);
            dgv.AddNewColumns("최종등록직원", "final_regist_employee", 150, true);
            dgv.AddNewColumns("사용 여부", "storage_use", 150, true);

            dgv.DataSource = ss.SelectStorage();
            List<CorporationVO> corpInfo = cs.CorporationComboBinding();
            corpInfo.Insert(0, new CorporationVO
            {
                corporation_id = 0,
                corporation_name = "전체"
            });
            cboCorporation.ComboBinding(corpInfo, "corporation_id","corporation_name");

            cboCorporation.SelectedIndexChanged += corporationChange;

            corporationChange(null, null);
        }

        private void corporationChange(object sender, EventArgs e)
        {
            list = (List<StorageVO>)dgv.DataSource;
            CorpValue = cboCorporation.SelectedValue.ToInt();
            List<FactoryVO> factoryInfo = fs.FactoryComboBindings(CorpValue) ;
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
        

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (dgv[9, row.Index].Value.ToString() == "Y")
                    dgv[4, row.Index].Value = "사용";
                else
                    dgv[4, row.Index].Value = "미사용";
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int Storage_ID = dgv[1, e.RowIndex].Value.ToInt();

            string Storage_Status = dgv[9, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == 4)
            {
                if (dgv[4, e.RowIndex].Value.ToString() == "미사용")
                {
                    ss.UpdateStatus(Storage_ID, Storage_Status);
                    dgv[4, e.RowIndex].Value = "사용";
                }


                else
                {
                    ss.UpdateStatus(Storage_ID, Storage_Status);
                    dgv[4, e.RowIndex].Value = "미사용";
                }
                ReviewDGV();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 4)
                return;

            EmployeeVO employee = this.GetEmployee();
            StorageVO vo = new StorageVO
            {
                Storage_Id = dgv[1, e.RowIndex].Value.ToInt(),
                Storage_Name = dgv[2, e.RowIndex].Value.ToString(),
                Factory_id = dgv[3, e.RowIndex].Value.ToInt(),
                Corporation_Name = cboCorporation.Text,
                Factory_Name = cboFactoryName.Text,
                Storage_Use = dgv[4, e.RowIndex].Value.ToString(),
                Final_regist_time = DateTime.Now,
                Final_regist_employee = employee.Employee_name
            };

            StorageInfoForm frm = new StorageInfoForm(true, vo);
            if (frm.ShowDialog() == DialogResult.OK)
                ReviewDGV();
        }

        private void buttonControl4_Click(object sender, EventArgs e)
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
}
