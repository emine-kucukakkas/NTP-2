using Bussines;
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
using DataCore;
using System.Windows.Forms;
using Bussiness;
using MODEL;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office;
using Paragraph = iTextSharp.text.Paragraph;
using Model;
using Syncfusion.ComponentModel;

namespace Dashboard1.Views
{
    /// <summary>
    /// Page4.xaml etkileşim mantığı
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void btnolustur_Click(object sender, RoutedEventArgs e)
        {
            cv cvpage = new cv();
            raporlarBO bo = new raporlarBO();
            raporlar r = new raporlar();
            r=bo.getir(Convert.ToInt32(txbsicilno.Text));
            cvpage.lblAd.Text = (r.adSoyad);
          
            cvpage.txtckimlk.Text = (r.tcKimlikNo);
            cvpage.txdogumyer.Text =  Convert.ToString(r.dogumYeri);
            cvpage.txdogumtar.Text = (r.dogumTarihi).ToShortDateString();
            cvpage.txasker.Text = (r.askerlikDurumu);
            cvpage.txkan.Text = Convert.ToString(r.kanGrubu);
            cvpage.txbolum.Text = (r.Lokasyon);
            cvpage.txbirim.Text = (r.Birim);
            cvpage.txisbasi.Text = (r.kurumaBaslamaTarihi).ToShortDateString();
            //cvpage.txhizmetyil.Text
            cvpage.txegitim.Text = (r.egitimDurumu);
            cvpage.txokul.Text = (r.okulAdi);
            cvpage.txokbolum.Text=(r.Bolumu);
            cvpage.txbitirme.Text =(r.bitirdigiTarih).ToShortDateString();
            cvpage.istel.Text = Convert.ToString(r.isTel);
            cvpage.adres.Text = (r.adres);
            cvpage.ceptel.Text = (r.cepTel);

            DateTime sontarih = DateTime.Now;
            DateTime ilktarih = r.kurumaBaslamaTarihi;

            ikitarihfark a = new ikitarihfark();

            int[] sonuc = (a.ikiTarihFarki(sontarih, ilktarih));
            cvpage.txhizmetyil.Text = sonuc[0] + " YIL " + sonuc[1] + " Ay " + sonuc[2] + " Gün";

          int uzunluk= (r.Unvan).Length;

            if (uzunluk > 10)
            {
                cvpage.lblUnvan.FontSize = 18;
            }
            

                cvpage.lblUnvan.Text = r.Unvan;


            try
            {
                                                                          cvpage.IsEnabled = false;
                System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    pd.PrintVisual(cvpage, "aaaa");
                }


            }
            finally
            {
                cvpage.IsEnabled = true;

            }
        }

        
    }
}
