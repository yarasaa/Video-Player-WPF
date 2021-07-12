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

namespace GirişEkranı
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Signup win = new Signup();
            win.Show();
        }

        private void txtusername_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtusername.Clear();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtusername.Text = "Username";
        }

        private void btnkayıtsız_Click(object sender, RoutedEventArgs e)
        {
            AnaEkran ana = new AnaEkran();
            ana.Show();
            this.Close();

        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            tblKayıt kayıt = new tblKayıt();
            AnaEkran ana = new AnaEkran();
            db dbs = new db();
            tblKayıt user = dbs.tblKayıt.SingleOrDefault(
                x => x.UserName == txtusername.Text && x.Password
                == txtpassword.Password);
            if (user==null)
            {
                MessageBox.Show("Login Failed");
            }
            else
            {
                this.Close();
                ana.Show();
            }

            if (CheckBoxRemember.IsChecked==true)
            {
                Properties.Settings.Default.UserName = txtusername.Text;
                Properties.Settings.Default.Password = txtpassword.Password;
                Properties.Settings.Default.Save();
            }
            if (CheckBoxRemember.IsChecked==false)
            {
                Properties.Settings.Default.UserName ="";
                Properties.Settings.Default.Password ="";
                Properties.Settings.Default.Save();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.UserName!=string.Empty)
            {
                txtusername.Text = Properties.Settings.Default.UserName;
                txtpassword.Password = Properties.Settings.Default.Password;
            }
        }
    }
}
