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
    public partial class FactoryForm : ListForm
    {
        DataTable dtDgv;
        FactoryService service = new FactoryService();
        List<FactoryForm> flist;
        //FactoryVO vo = new FactoryVO();

        public FactoryForm()
        {
            InitializeComponent();
        }

        private void FactoryForm_Load(object sender, EventArgs e)
        {
            dgvFactorylist.IsAllCheckColumnHeader = true;

            dgvFactorylist.AddNewColumns("법인명", "corporation_name", 100, true);
            dgvFactorylist.AddNewColumns("공장코드", "factory_id", 100, true);
            dgvFactorylist.AddNewColumns("공장명", "factory_name", 100, true);
            dgvFactorylist.AddNewColumns("공장순번", "factory_seq", 100, true);
            dgvFactorylist.AddNewColumns("공장비고1", "factory_note1", 100, true);
            dgvFactorylist.AddNewColumns("공장비고2", "factory_note2", 100, true);
            dgvFactorylist.AddNewColumns("사용여부", "factory_use", 100, true);
            dgvFactorylist.AddNewColumns("최초등록시각", "first_regist_time", 100, true);
            dgvFactorylist.AddNewColumns("최초등록사원", "first_regist_employee", 100, true);
            dgvFactorylist.AddNewColumns("최종등록시각", "final_regist_time", 100, true);
            dgvFactorylist.AddNewColumns("최종등록사원", "final_regist_employee", 100, true);

            LoadData();

            //cboCorporationName.ComboBinding(service.ComboGet(), "corporation_id", "corporation_name", "선택", 0);
        }

        private void LoadData()
        {

           //dtDgv= service.SelectFactory();

           DataView dv = new DataView(dtDgv);
           dgvFactorylist.DataSource = dv;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //vo = (FactoryVO)(cboCorporationName.SelectedValue);

            //dtDgv = service.SearchName(vo);

            //DataView dv = new DataView(dtDgv);    
            //dgvFactorylist.DataSource = dv;
            //DataTable dt = dv.ToTable();
            //List<FactoryVO> sortedData = SqlHelper.ConvertDataTableToList<FactoryVO>(dt);
        }
    }
}
