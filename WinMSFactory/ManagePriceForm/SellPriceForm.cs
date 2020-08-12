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
using WinMSFactory.ManagePriceForm;

namespace WinMSFactory
{
    public partial class SellPriceForm : ListForm
    {
        ProductService service = new ProductService();

        List<SellPriceManageVO> SelectList;
        List<SellPriceManageVO> dgvList;
        public SellPriceForm()
        {
            InitializeComponent();
        }

        private void SellPriceForm_Load(object sender, EventArgs e)
        {
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            Columns(RightAlign);

            SelectList = service.SelectAllPriceProducts();
            dgv.DataSource = SelectList;
            FromToDate.From = DateTime.Now.AddDays(-60);
            FromToDate.To = DateTime.Now.AddDays(60);
        }

        private void Columns(DataGridViewContentAlignment RightAlign)
        {
            dgv.AddNewColumns("품목코드", "product_id", 150, false);
            dgv.AddNewColumns("그룹명", "product_group_name", 200, true);
            dgv.AddNewColumns("품목명", "product_name", 200, true);
            dgv.AddNewColumns("품목 스펙(규격)", "product_information", 200, true);
            dgv.AddNewColumns("품목 단위", "product_unit", 80, true);
            dgv.AddNewColumns("현재 단가", "sell_current_price_string", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("이전 단가", "sell_previous_price_string", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("시작일", "start_date", 80, true);
            dgv.AddNewColumns("종료일", "end_date", 80, true);
            dgv.AddNewColumns("비고", "note", 300, true);
            dgv.AddNewColumns("코드번호", "sellprice_code", 150, true);
            dgv.AddNewColumns("Rank", "RankNum", 150, true);
        }

        private void ReviewDGV()
        {
            SelectList = service.SelectAllPriceProducts();
            dgv.DataSource = SelectList;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)    //수정
        {
            if (e.RowIndex < 0)
                return;
            else if (IsLastInsert("수정", e.RowIndex) == false)
                return;

            

            SellPriceManageVO ManageVO = new SellPriceManageVO
            {
                Sellprice_Code = dgv[10, e.RowIndex].Value.ToInt(),
                Product_Group_Name = dgv[1, e.RowIndex].Value.ToString(),
                Product_Name = dgv[2, e.RowIndex].Value.ToString(),
                Sell_Current_Price_String = dgv[5, e.RowIndex].Value.ToString().Replace(" 원", "").Replace(",", ""),
                Sell_Previous_Price_String = dgv[6, e.RowIndex].Value.ToString().Replace(" 원", "").Replace(",", ""),
                Start_Date = Convert.ToDateTime(dgv[7, e.RowIndex].Value),
                End_Date = Convert.ToDateTime(dgv[8,e.RowIndex].Value),
                Note = dgv[9, e.RowIndex].Value.ToString(),
                RankNum = dgv[11, e.RowIndex].Value.ToInt()
            };
            SettingFormOpen(false, ManageVO);
        }

        private bool IsLastInsert(string Status, int SelectedRow)
        {
            dgvList = (List<SellPriceManageVO>)dgv.DataSource;

            int SelectNum = dgvList.FindAll(p => p.Product_Group_Name == dgv[1, SelectedRow].Value.ToString()
                                                    && p.Product_Name == dgv[2, SelectedRow].Value.ToString()).Max(p => p.RankNum);

            if (SelectNum != dgv[11, SelectedRow].Value.ToInt())
            {
                MessageBox.Show($"가장 최근에 생성된 {Status}만 변경이 가능합니다.");
                return false;
            }
            return true;
        }

        private void SettingFormOpen(bool IsInsert, SellPriceManageVO ManageVO = null) // 등록 / 수정에 따른 폼 open
        {
            SellPriceDialogForm frm = new SellPriceDialogForm(IsInsert, ManageVO, dgvList);

            if (frm.ShowDialog() == DialogResult.Yes) // 정상적으로 실행 후 종료된 경우
                ReviewDGV(); // 데이터 갱신!!
        }
        //찾기 버튼
        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                SearchMethod();
            }
        }
        private void SearchMethod()
        {
            if (txtProduct.TextLength < 1)
            {
                var SortedList = (from item in SelectList
                                  where item.Start_Date >= FromToDate.From.AddDays(-1) && item.Start_Date <= FromToDate.To
                                  select item).ToList();

                dgv.DataSource = SortedList;
            }
            else
            {
                var SortedList = (from item in SelectList
                                  where item.Start_Date >= FromToDate.From.AddDays(-1) && item.Start_Date <= FromToDate.To 
                                  && item.Product_Name.Contains(txtProduct.Text)
                                  select item).ToList();

                dgv.DataSource = SortedList;
            }
        }
        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                SettingFormOpen(true, null);
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    int SelectedRow = dgv.SelectedRows[0].Index;

                    if (IsLastInsert("삭제", SelectedRow) == false)
                    {
                        MessageBox.Show("최근에 생성된 내용만 삭제가 가능합니다.");
                        return;
                    }
                        
                    else if (MessageBox.Show("정말로 삭제하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int value = dgv.SelectedRows[0].Cells[10].Value.ToInt();
                        if (service.DeleteSellPrice(value))
                        {
                            MessageBox.Show("삭제를 완료하였습니다.");
                            ReviewDGV();
                        }
                    }
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            if(((MainForm)this.MdiParent).ActiveMdiChild == this)
                ReviewDGV();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchMethod();
        }
    }
}
