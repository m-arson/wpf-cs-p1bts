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

namespace p1BTS
{
    public partial class LoginWindow : Window
    {
        private int priv_checked;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void ProcessLogin(Object sender, RoutedEventArgs e)
        {
            var user = (TextBox)this.username;
            var pass = (PasswordBox)this.password;
            var errorMessage = (TextBlock)this.errorMsg;
            if(user.Text.Equals("") || pass.Password.Equals("") || priv_checked == 9) {
                errorMessage.Text = "Field are empty!";
            } else
            {
                Dashboard dashboard= new Dashboard();
                dashboard.Show();
                this.Close();
            }
        }
        protected void setCheckedPrev(object sender, RoutedEventArgs e)
        {
            if(this.owner.IsChecked == true)
            {
                priv_checked = 1;
            } else if(this.staff.IsChecked == true)
            {
                priv_checked = 0;
            } else
            {
                priv_checked = 9;
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
