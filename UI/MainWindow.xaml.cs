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
using UI.Views;
using Application;
using Application.DatabaseControllers;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBRosterController.LoadRosters();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userNameTxtBox.Text.ToUpper() == "USER" && passwordBox.Password.ToUpper() == "USER")
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                menuWindow.AddShiftsBtn.IsEnabled = false;
                menuWindow.CreateRosterBtn.IsEnabled = false;
                this.Hide();
            }
           else if (userNameTxtBox.Text.ToUpper() == "ADMIN" && passwordBox.Password.ToUpper() == "ADMIN")
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Forkert Brugernavn eller Password");
            }

        }
        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.SelectAll(); 
            }
        }
        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = sender as PasswordBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }
    }
}
