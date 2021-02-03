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
using Bussines;
using Bussiness;
using Model;

namespace Dashboard1.Views
{
    /// <summary>
    /// Page3.xaml etkileşim mantığı
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            raporlarBO bo = new raporlarBO();
            dtg_seyahat.ItemsSource = bo.DataGridDoldur();
        }

        private void dtg_seyahat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dtg_seyahat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
