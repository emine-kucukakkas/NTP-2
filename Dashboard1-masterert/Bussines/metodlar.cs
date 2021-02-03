using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;

using System.Data;
using Bussiness;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;

using MODEL;
using System.Data.SqlClient;
using DataCore;
using Bussines;
using Microsoft.Office;
using Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bussines
{
    public class metodlar
    {

        public void ExportToPdf(DataTable dt, string strFilePath)
        {
            
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                widths[i] = 4f;

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), font5));
                    }
                }
            }
            document.Add(table);

            document.Close();
        }


        

        public int[] ikiTarihFarki(DateTime sonTarih, DateTime ilkTarih)

        {

            int ilkGun, ilkAy, ilkYil;

            int sonGun, sonAy, sonYil;

            int farkYil, farkAy, farkGun;

            farkYil = 0; farkAy = 0; farkGun = 0;



            ilkYil = ilkTarih.Year;

            ilkAy = ilkTarih.Month;

            ilkGun = ilkTarih.Day;



            sonGun = sonTarih.Day;

            sonAy = sonTarih.Month;

            sonYil = sonTarih.Year;



            if (sonGun < ilkGun)

            {

                sonGun += DateTime.DaysInMonth(sonYil, sonAy);

                farkGun = sonGun - ilkGun;

                sonAy--;

                if (sonAy < ilkAy)

                {

                    sonAy += 12;

                    sonYil--;

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

                else

                {

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

            }

            else

            {

                farkGun = sonGun - ilkGun;

                if (sonAy < ilkAy)

                {

                    sonAy += 12;

                    sonYil--;

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

                else

                {

                    farkAy = sonAy - ilkAy;

                    farkYil = sonYil - ilkYil;

                }

            }



            int[] sonuc = new int[3];

            sonuc[0] = farkYil;

            sonuc[1] = farkAy;

            sonuc[2] = farkGun;

            return sonuc;
        }
        public void exceleyolla(int[] satir, int[] sutun, string[] veri1, string[] veri2,string yol)
        {
            
            try
            {
              
                Excel.Application Excele_Gonder = new Excel.Application();
                Excel.Workbook Excel_Kitab;
                Excel_Kitab = Excele_Gonder.Workbooks.Open(yol);
                Excel.Worksheet Excel_Sayfa;
                Excel_Sayfa = Excele_Gonder.ActiveWorkbook.ActiveSheet;
                Excele_Gonder.Visible = true;
                for (int i = 0; i < 6; i++)
                {
                    Excel_Sayfa.Cells[satir[i], sutun] = veri1[i];
                    Excel_Sayfa.Cells[satir[i], sutun] = veri2[i];

                }
               
               // Excel_Kitab.Save();
                //Excel_Kitab.Close();
            }
            catch (Exception)
            {

                throw;
            }
          

        }
       


    }
}
