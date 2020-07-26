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

namespace WinMSFactory.Nam
{
    public partial class ItemDeleteList : Form
    {
        List<ProductVO> HighList;
        List<ProductVO> LowList;
        public ItemDeleteList(List<ProductVO> HighList, List<ProductVO> LowList)
        {
            InitializeComponent();
            this.HighList = HighList;
            this.LowList = LowList;
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemDeleteList_Load(object sender, EventArgs e)
        {
            List<string> High = new List<string>();
            List<string> Low = new List<string>();

            for (int i = 0; i<HighList.Count; i++)
            {
                High.Add(HighList[i].Product_Name);
            }

            for (int i = 0; i < LowList.Count; i++)
            {
                Low.Add(LowList[i].Product_Name);
            }

            UpList.DataSource = High;
            DownList.DataSource = Low;
        }
    }
}
