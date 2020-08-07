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
    public partial class DefectiveTypeSettingForm : BasicForm
    {
        public DefectiveTypeSettingForm()
        {
            InitializeComponent();
        }

        private void DefectiveTypeSettingForm_Load(object sender, EventArgs e)
        {
            // 불량 유형 CRUD

            dgv.AddNewCol("비가동 코드", "", true, 100);
            dgv.AddNewCol("비가동 명칭", "", true, 100);
            dgv.AddNewCol("시간 계산 적용 여부", "", true, 100);
            dgv.AddNewCol("비가동 순번", "", true, 100);
            dgv.AddNewCol("비가동 사용여부", "", true, 100);
            dgv.AddNewCol("최초등록시간", "", true, 100);
            dgv.AddNewCol("최초등록사원", "", true, 100);
            dgv.AddNewCol("최종등록시간", "", true, 100);
            dgv.AddNewCol("최종등록사원", "", true, 100);
        }
    }
}
