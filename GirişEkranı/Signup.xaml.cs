using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GirişEkranı
{
    /// <summary>
    /// Signup.xaml etkileşim mantığı
    /// </summary>
    
    public partial class Signup : Window
    {

        

        public Signup()
        {
            InitializeComponent();
            
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnregregister_Click(object sender, RoutedEventArgs e)
        {
            tblKayıt f = new tblKayıt();
            f.UserName = txtregusername.Text;
            f.Password = txtregpassword1.Password;
            f.PasswordCheck = txtregpasswordconfirm.Password;
            f.Name = txtregname.Text;
            f.Surname = txtregsurname.Text;
            f.BirthDate = txtregbirthdate.SelectedDate;

            db dbs = new db();
            
            if (txtregpassword1.Password==txtregpasswordconfirm.Password)
            {
                
                dbs.tblKayıt.Add(f);
                dbs.SaveChanges();
                lblInformation.Content = "User Register Success";

            }

            if (txtregpassword1.Password != txtregpasswordconfirm.Password)
            {
                lblInformation.Content = "Passwords Are Not Same";
            }

            if (txtregpassword1.Password.Length <= 5)
            {
                lblInformation.Content = "Password Must Be 6 Character";
            }




        }

        private void btnBackLogin_Click(object sender, RoutedEventArgs e)
        {
            Signup sign = new Signup();
            sign.Close();
            this.Close();
        }
    }
}
