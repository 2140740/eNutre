﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCode
{

    using Excel = Microsoft.Office.Interop.Excel;

    public class ExcelHandler
    {
        public static List<string> Restaurante = new List<string>();
        public static List<string> Item = new List<string>();
        public static List<string> Quantidade = new List<string>();
        public static List<string> Calorias = new List<string>();
        public static String varerror;

        public static void ReadExcel(string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

/*
Filename, UpdateLinks, ReadOnly, Format, Password, 
WriteResPassword, IgnoreReadOnlyRecommended, Origin, 
Delimiter, Editable, Notify, Converter, AddToMru, Local, CorruptLoad
*/
        
        range = xlWorkSheet.UsedRange; //representa as celulas que têm valores

            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                    {
                        if (cCnt == 1)
                        {
                            Restaurante.Add(str);
                        }
                        if (cCnt == 2)
                        {
                            Item.Add(str);
                        }
                        if (cCnt == 3)
                        {
                            Quantidade.Add(str);
                        }
                        if (cCnt == 4)
                        {
                            Calorias.Add(str);
                        }
                    }


                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }


        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                varerror = ("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
