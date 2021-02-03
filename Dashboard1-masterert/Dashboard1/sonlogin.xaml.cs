using Bussiness;
using MODEL;
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
using System.Windows.Shapes;

namespace Dashboard1
{
    /// <summary>
    /// sonlogin.xaml etkileşim mantığı
    /// </summary>
    public partial class sonlogin : Window
    {
        public sonlogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginBO bo = new LoginBO();

            if (bo.login(txbkullaniciadi.Text,txbsifre.Text))
            {
                Login l = new Login();
             l= bo.getir2(txbkullaniciadi.Text);
                if (l.yetki==1)
                {
                    MainWindow m = new MainWindow();

                    m.Show();
                    this.Hide();
                }
                else
                {
                    egitimMain egitim = new egitimMain();
                    egitim.Show();
                    
                }

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
           
        }
    }
}
