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

namespace Vagtplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (userNameTxtBox.Text.ToUpper() == "TEST" && passwordBox.Password.ToUpper() == "TEST")
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
                button_Click(sender,e);
            }
        }
    }
}
