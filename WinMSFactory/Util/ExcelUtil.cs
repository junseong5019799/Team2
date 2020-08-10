using DevExpress.Data.Access;
using DevExpress.DataAccess.Native.Data;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinMSFactory.Util
{
    public class ExcelUtil
    {
        
        public static void ListToExcel<T>(List<T> dataList) // string[] Columns
        {
            List<string> ColumnList = new List<string>(); // 컬럼 리스트

            SaveFileDialog dialog = new SaveFileDialog();

            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties())
                ColumnList.Add(property.Name);

            try
            {
                dialog.Filter = "Excel 파일(*.xlsx)|*.xlsx";
                

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Excel.Application xlApp = new Excel.Application();
                        Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                        Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                        xlApp.Visible = true;

                        for(int i = 1; i< dataList.Count; i++)// row
                        {
                            for(int j = 1; j<ColumnList.Count; j++) // column
                            {
                                if (i == 1)
                                    xlWorksheet.Cells[i, j] = ColumnList[j].ToString();

                                else
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
            catch
            {

            }

        }
        public static void DataTableToExcel(DataTable dt)
        {

            try
            {

            }
            catch
            {

            }
        }
    }
}
