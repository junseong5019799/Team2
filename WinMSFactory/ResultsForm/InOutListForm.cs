﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory.StockForm
{
    public partial class InOutListForm : ListForm
    {
        public InOutListForm()
        {
            InitializeComponent();
        }

        private void InOutListForm_Load(object sender, EventArgs e)
        {
            dgv.AddNewColumns("입출고", "gubun", 100, true);
            dgv.AddNewColumns("번호", "release_no", 100, true);
            dgv.AddNewColumns("창고ID", "storage_id", 100, false);
            dgv.AddNewColumns("창고", "storage_name", 100, true);
            dgv.AddNewColumns("품목", "product_id", 100, false);
            dgv.AddNewColumns("품목유형", "product_type", 100, true);
            dgv.AddNewColumns("품명", "product_name", 100, true);
            dgv.AddNewColumns("수량", "release_quantity", 100, true);
            dgv.AddNewColumns("입출고일", "release_date", 100, true);
            
            OrderService orderService = new OrderService();
            DataTable dt = orderService.GetInOutList();
            dgv.DataSource = dt;

            ReleaseService releaseService = new ReleaseService();
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name", "전체");

            
            
        }
    }
}
