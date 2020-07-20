using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class BOMForm : ListDetailForm
    {
        public BOMForm()
        {
            InitializeComponent();
        }

        private void BOMForm_Load(object sender, EventArgs e)
        {
            dataGridViewControl1.AddNewColumns("상위 품목 코드", "", 100, true);
            dataGridViewControl1.AddNewColumns("상위 품목 명칭", "", 100, true);
            dataGridViewControl1.AddNewColumns("하위 품목 코드", "", 100, true);
            dataGridViewControl1.AddNewColumns("하위 품목 명칭", "", 100, true);
            dataGridViewControl1.AddNewColumns("필요 수량", "", 100, true);
            dataGridViewControl1.AddNewColumns("순번", "", 100, true);
            dataGridViewControl1.AddNewColumns("인터페이스 여부", "", 100, true);
            dataGridViewControl1.AddNewColumns("사용 여부", "", 100, true);
            dataGridViewControl1.AddNewColumns("최초등록시각", "", 100, true);
            dataGridViewControl1.AddNewColumns("최초등록사원", "", 100, true);
            dataGridViewControl1.AddNewColumns("최종등록사원", "", 100, true);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
