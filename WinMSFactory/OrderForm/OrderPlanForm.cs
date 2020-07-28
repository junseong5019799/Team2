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

namespace WinMSFactory.OrderForm
{
    public partial class OrderPlanForm : ListForm
    {
        ReleaseService releaseService = new ReleaseService();
        private int release_no;

        public int Release_no
        {
            get { return release_no; }
            set { release_no = value; }
        }

        public OrderPlanForm()
        {
            InitializeComponent();
        }

        private void OrderPlanForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("출고예정 번호", "release_no", 100, true);
            dgv.AddNewColumns("순서", "release_seq", 100, false);
            dgv.AddNewColumns("품목", "product_id", 100, true);
            dgv.AddNewColumns("품명", "product_name", 100, true);
            dgv.AddNewColumns("카테고리", "category", 100, true);

            cboPlanID.ComboBinding(releaseService.SelectPlanID(), "release_no", "release_no");
            cboPlanID.SelectedValue = release_no;

            DataTable dt = releaseService.GetReleasePlanDetail(release_no);
            dgv.DataSource = dt;

            string d = $@"SELECT release_no, product_id, (SELECT product_name FROM [dbo].[TBL_PRODUCT] WHERE product_id = rd.product_id) AS product_name, '소요량' AS category
                          FROM TBL_RELEASE_DETAIL rd
                          WHERE release_no = 40
                          UNION
                          SELECT release_no, product_id, (SELECT product_name FROM [dbo].[TBL_PRODUCT] WHERE product_id = rd.product_id) AS product_name, 'balanace' AS category
                          FROM TBL_RELEASE_DETAIL rd
                          WHERE release_no = 40
                          UNION
                          SELECT release_no, product_id, (SELECT product_name FROM [dbo].[TBL_PRODUCT] WHERE product_id = rd.product_id) AS product_name, '발주제안' AS category
                          FROM TBL_RELEASE_DETAIL rd
                          WHERE release_no = 40";

        }
    }
}
