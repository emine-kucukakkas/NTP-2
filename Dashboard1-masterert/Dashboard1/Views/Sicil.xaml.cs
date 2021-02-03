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
using Bussiness;
using Bussines;
using System.Data.SqlClient;
using DataCore;
using System.Configuration;
using CrystalDecisions.CrystalReports;
using CrystalDecisions;
namespace Dashboard1.Views
    
{
    /// <summary>
    /// Sicil.xaml etkileşim mantığı
    /// </summary>
    public partial class Sicil : Page
    {
        public Sicil()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            personelHelper p = new personelHelper();
           txbmerkezsayi.Text= p.scalarLokasyon(1).ToString();
            txbaliagasayi.Text = p.scalarLokasyon(2).ToString();
            txbkirikkalesayi.Text = p.scalarLokasyon(3).ToString();
            txbseymensayi.Text = p.scalarLokasyon(4).ToString();
       txbtotal.Text = ((p.scalarLokasyon(1)) + (p.scalarLokasyon(2)) + (p.scalarLokasyon(3)) + (p.scalarLokasyon(4))).ToString();

            yashaddiBO bo = new yashaddiBO();
            dtgyashaddi.ItemsSource = bo.yashaddi();
            dtgasalet.ItemsSource = bo.asaletTasdiki();

            if (dtgasalet.ItemsSource==null)
            {
                recasalaet.Visibility = Visibility.Hidden;
                dtgasalet.Visibility = Visibility.Hidden;
                txbasalet.Visibility = Visibility.Hidden;
            }
            if (dtgasalet.ItemsSource == null)
            {
                recyas.Visibility = Visibility.Hidden;
                dtgyashaddi.Visibility = Visibility.Hidden;
                txbyas.Visibility = Visibility.Hidden;
            }





        }

       

        
    }
}
