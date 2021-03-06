﻿using MSFactoryVO;
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
    public partial class DownTimeSelectForm : BasicForm
    {
        // 비가동 현황

        DownTimeService service = new DownTimeService();
        List<DownTimeVO> SelectDownTimeAll;
        public DownTimeSelectForm()
        {
            InitializeComponent();
        }

        private void frmAStop_Load(object sender, EventArgs e)
        {
            FromToDate.To = DateTime.Now;
            FromToDate.From = FromToDate.To.AddDays(-7);


            dgv.AddNewColumns("비가동 명칭", "downtime_type_name", 150, true);
            dgv.AddNewColumns("작업자 이름", "employee_name", 100, true); // 비가동 - 작업지시번호 - 작업자 코드 - 사번 - 사원이름
            dgv.AddNewColumns("제품명", "product_name", 150, true); // 비가동 - 작업지시번호 - 품목 코드 - 제품명
            dgv.AddNewColumns("비가동 시작 시간", "downtime_start_time", 150, true);
            dgv.AddNewColumns("비가동 종료 시각", "downtime_finish_time", 150, true);
            dgv.AddNewColumns("비가동 총 시간", "downtime_type_calculation", 130, true); // 비가동 - 비가동 코드 - 시간계산 적용
            dgv.AddNewColumns("비가동 사용 여부", "downtime_type_use", 100, true);
            dgv.AddNewColumns("최초등록시각", "final_regist_time", 140, true);
            dgv.AddNewColumns("최초등록사원", "final_regist_employee", 110, true);
            dgv.AddNewColumns("최종등록시각", "final_regist_time", 140, true);
            dgv.AddNewColumns("최종등록사원", "final_regist_employee", 110, true);


            SelectDownTimeAll = service.SelectAllDownTime();
            dgv.DataSource = SelectDownTimeAll;

        }

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                txtProductName.Text = "";
                dgv.DataSource = null;
                dgv.DataSource = SelectDownTimeAll;
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (txtProductName.TextLength > 1)
                {
                    var SortedData = (from sortedList in SelectDownTimeAll
                                      where sortedList.Downtime_Start_Time >= FromToDate.From.AddDays(-1) && sortedList.Downtime_Start_Time <= FromToDate.To
                                            && sortedList.Product_Name.Contains(txtProductName.Text)
                                      select sortedList).ToList();

                    dgv.DataSource = SortedData;
                }

                else
                {
                    var SortedData = (from sortedList in SelectDownTimeAll
                                      where sortedList.Downtime_Start_Time >= FromToDate.From.AddDays(-1) && sortedList.Downtime_Start_Time <= FromToDate.To
                                      select sortedList).ToList();

                    dgv.DataSource = SortedData;
                }
            }

        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(null, null);
        }
    }
}