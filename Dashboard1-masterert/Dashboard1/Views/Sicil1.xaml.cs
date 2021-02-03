using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Bussiness;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;
using Dashboard1;
using CrystalDecisions.CrystalReports.Engine;
using MODEL;
using System.Data.SqlClient;
using DataCore;
using Bussines;
using CrystalDecisions.Shared;
using Microsoft.Office;
using Model;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using Microsoft.Win32;

namespace Dashboard1.Views
{
    /// <summary>
    /// </summary>
    public partial class Sicil1 : Page
    {
        public Sicil1()
        {
            InitializeComponent();
        }

        

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
           
        }
       
        private void btnEgitimler_Click(object sender, RoutedEventArgs e)
        {
          

        }



      

   
        public void export(DataGrid dg, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dg.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog()==true)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {

                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();

                }
            }


        }

        private void btndok_Click(object sender, RoutedEventArgs e)
        {

            export(dataGrid33, "test");
                                                     
        }
        
        private void btnolustur_Click(object sender, RoutedEventArgs e)
        {
            raporlarBO bo = new raporlarBO();
            

            if (cmblokas.SelectedValue==null && cmbbirim.SelectedValue==null && cmbunvan.SelectedValue==null && cmbkan.SelectedValue==null && cmbasker.SelectedValue==null && cmbegitim.SelectedValue==null)
            {
                
                if (chberkek.IsChecked==true && chbkadin.IsChecked==false)
                {
                    dataGrid33.ItemsSource = bo.sadeceCinsiyet("Erkek");
                }
                else if (chberkek.IsChecked == false && chbkadin.IsChecked == true)
                {
                    dataGrid33.ItemsSource = bo.sadeceCinsiyet("Kadın");
                }
                else if (chberkek.IsChecked == false && chbkadin.IsChecked == false)
                {
                    MessageBox.Show("Cinsiyet belirtiniz");
                    dataGrid33.ItemsSource = null;
                }
                else
                {
                    dataGrid33.ItemsSource = bo.ListeyiGetir();
                }

                
            }

           

            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.sadecelokasyon(Convert.ToString(cmblokas.Text));
            }

            

            if (cmblokas.SelectedValue == null && !(cmbbirim.SelectedValue == null) && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.sadecebirim(Convert.ToString(cmbbirim.Text));
            }

            

            if (cmblokas.SelectedValue == null && cmbbirim.SelectedValue == null && !(cmbunvan.SelectedValue == null) && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.sadeceUnvan(Convert.ToString(cmbunvan.Text));
            }

            

            if (cmblokas.SelectedValue == null && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && !(cmbegitim.SelectedValue == null) && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.sadeceegitim(Convert.ToString(cmbegitim.Text));
            }
            

            if (cmblokas.SelectedValue == null && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && !(cmbasker.SelectedValue == null) && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
              

                dataGrid33.ItemsSource = bo.sadeceasker(Convert.ToString(cmbasker.Text));
            }

            

            if (cmblokas.SelectedValue == null && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && !(cmbkan.SelectedValue == null) && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.sadecekan(Convert.ToString(cmbkan.Text));
            }
          

            if (!(cmblokas.SelectedValue == null) && !(cmbbirim.SelectedValue == null) && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokasbirim(Convert.ToString(cmblokas.Text), Convert.ToString(cmbbirim.Text));
            }

           

            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && !(cmbunvan.SelectedValue == null) && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokasunvan(Convert.ToString(cmblokas.Text), Convert.ToString(cmbunvan.Text));
            }

            

            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null)
            {

                if (chberkek.IsChecked == true && chbkadin.IsChecked == false)
                {
                    dataGrid33.ItemsSource = bo.lokacinsiyet(Convert.ToString(cmblokas.Text),"Erkek");
                }
                else if (chberkek.IsChecked == false && chbkadin.IsChecked == true)
                {
                    dataGrid33.ItemsSource = bo.lokacinsiyet(Convert.ToString(cmblokas.Text), "Kadın");
                }
                else if (chberkek.IsChecked == false && chbkadin.IsChecked == false)
                {
                    MessageBox.Show("Cinsiyet belirtiniz");
                    dataGrid33.ItemsSource = null;
                }
                else
                {
                    dataGrid33.ItemsSource = bo.sadecelokasyon(cmblokas.Text);
                }

               



            }
            

            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && !(cmbegitim.SelectedValue == null) && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokaegitim(Convert.ToString(cmblokas.Text), Convert.ToString(cmbegitim.Text));
            }


            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && !(cmbasker.SelectedValue == null) && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokaeasker(Convert.ToString(cmblokas.Text), Convert.ToString(cmbasker.Text));
            }

            

            if (!(cmblokas.SelectedValue == null) && cmbbirim.SelectedValue == null && cmbunvan.SelectedValue == null && !(cmbkan.SelectedValue == null) && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokakan(Convert.ToString(cmblokas.Text), Convert.ToString(cmbkan.Text));
            }

            

            if (!(cmblokas.SelectedValue == null) && !(cmbbirim.SelectedValue == null) && !(cmbunvan.SelectedValue == null) && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokabirimunvan(Convert.ToString(cmblokas.Text), Convert.ToString(cmbbirim.Text), Convert.ToString(cmbunvan.Text));
            }
            

            if (!(cmblokas.SelectedValue == null) && !(cmbbirim.SelectedValue == null) && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && cmbasker.SelectedValue == null && !(cmbegitim.SelectedValue == null) && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokabirimegitim(Convert.ToString(cmblokas.Text), Convert.ToString(cmbbirim.Text), Convert.ToString(cmbegitim.Text));
            }
           

            if (!(cmblokas.SelectedValue == null) && !(cmbbirim.SelectedValue == null) && cmbunvan.SelectedValue == null && cmbkan.SelectedValue == null && !(cmbasker.SelectedValue == null) && cmbegitim.SelectedValue == null && chberkek.IsChecked == true && chbkadin.IsChecked == true)
            {
                dataGrid33.ItemsSource = bo.lokabirimasker(Convert.ToString(cmblokas.Text), Convert.ToString(cmbbirim.Text), Convert.ToString(cmbasker.Text));
            }
        }

        
    }
}
