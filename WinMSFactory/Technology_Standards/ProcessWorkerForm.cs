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
    public partial class ProcessWorkerForm : ListDetailForm
    {
        public ProcessWorkerForm()
        {
            InitializeComponent();
        }

        private void ProcessWorkerForm_Load(object sender, EventArgs e)
        {
            dgvProcess.IsAllCheckColumnHeader = true;

            dgvProcess.AddNewColumns("법인", "", 100, true);
            dgvProcess.AddNewColumns("공장", "", 100, true);
            dgvProcess.AddNewColumns("라인", "", 100, true); // 3 // 버튼 부분은 false
            dgvProcess.AddNewColumns("공정", "", 100, true); //4

            dgvWorker.IsAllCheckColumnHeader = true;

            dgvWorker.AddNewColumns("작업자코드", "", 100, true);
            dgvWorker.AddNewColumns("작업자", "", 100, true);


            LoadData();
        }

        private void LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
