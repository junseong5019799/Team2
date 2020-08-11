using MSFactoryDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace WinMSFactory.Util
{
    public class ExcelUtil
    {
        public ExcelUtil() 
        {
        }
        public static void ListToExcel<T>(string[] ColumnList, List<T> dataList) // string[] Columns
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Excel 파일(*.xlsx)|*.xlsx";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                    Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                    xlApp.Visible = true;

                    for(int i = 1; i<ColumnList.Length; i++)
                        xlWorksheet.Cells[0,i] = ColumnList[i].ToString();


                    for (int i = 1; i< dataList.Count; i++)// row
                    {
                        for(int j = 1; j<ColumnList.Length; j++) // column
                        {
                            xlWorksheet.Cells[i, j] = ColumnList[i][j].ToString();
                        }
                    }

                    xlWorkbook.SaveAs(dialog.FileName);
                    xlWorkbook.Close(true);
                    xlApp.Quit();

                    MessageBox.Show("엑셀이 생성되었습니다.");
                }
                catch
                {
                    MessageBox.Show("오류가 발생하였습니다. 다시 시도하여 주세요");
                }
            }
           

        }
        public static void DataTableToExcel(DataTable dt)
        {

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "Excel 파일(*.xlsx)|*.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                    Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                    xlApp.Visible = true;

                    for (int i = 1; i < dt.Columns.Count; i++)
                        xlWorksheet.Cells[1, i] = dt.Rows[0][i].ToString();

                    for(int i = 2; i<=dt.Rows.Count; i++)
                    {
                        for(int j = 1; j<=dt.Columns.Count; j++)
                            xlWorksheet.Cells[j, i] = dt.Rows[i][j].ToString();
                    }

                    xlWorkbook.SaveAs(dialog.FileName);
                    xlWorkbook.Close(true);
                    xlApp.Quit();

                    MessageBox.Show("엑셀이 생성되었습니다.");
                }
            }
            catch
            {
                MessageBox.Show("오류가 발생하였습니다. 다시 시도하여 주세요");
            }
        }
    }
}
