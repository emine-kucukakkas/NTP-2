using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
using Dashboard1.Views;

namespace Dashboard1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




            Sicil s = new Sicil();
            frame1.Navigate(s);

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

       

       

        private void btnSicil_Click(object sender, RoutedEventArgs e)
        {
            Views.Sicil1 s = new Views.Sicil1();
            frame1.Navigate(s);

            lokasyonBO bo2 = new lokasyonBO();
            s.cmblokas.ItemsSource = bo2.ListeyiGetir();
            s.cmblokas.DisplayMemberPath = "Lokasyon";
            s.cmblokas.SelectedValuePath = "id";

            birimBO bo3 = new birimBO();

            s.cmbbirim.ItemsSource = bo3.ListeyiGetir();
            s.cmbbirim.DisplayMemberPath = "Birim";
            s.cmbbirim.SelectedValuePath = "id";

            unvanBO bo4 = new unvanBO();
            s.cmbunvan.ItemsSource = bo4.ListeyiGetir();
            s.cmbunvan.DisplayMemberPath = "Unvan";
            s.cmbunvan.SelectedValuePath = "id";

            s.chberkek.IsChecked = true;
            s.chbkadin.IsChecked = true;

            egitimDurumuBO bo5 = new egitimDurumuBO();

            s.cmbegitim.ItemsSource = bo5.ListeyiGetir();

            s.cmbegitim.DisplayMemberPath = "egitim";
            s.cmbegitim.SelectedValuePath = "id";


            askerlikBO bo6 = new askerlikBO();
            s.cmbasker.ItemsSource = bo6.ListeyiGetir();
            s.cmbasker.DisplayMemberPath = "durumu";
            s.cmbasker.SelectedValuePath = "id";

            kanGrubuBO bo7 = new kanGrubuBO();
            s.cmbkan.ItemsSource = bo7.ListeyiGetir();
            s.cmbkan.DisplayMemberPath = "kangrup";
            s.cmbkan.SelectedValuePath = "id";



              


        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            Views.Sicil s = new Views.Sicil();
            frame1.Navigate(s);
        }

       

       

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Views.Page3 s = new Views.Page3();
            frame1.Navigate(s);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Page4 s = new Page4();
            frame1.Navigate(s);
        }

        
    }

    
      
    }

