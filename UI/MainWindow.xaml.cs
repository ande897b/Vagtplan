using Application.DatabaseControllers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Views;

namespace UI
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            DBDateController.LoadDates();
            DBRosterController.LoadRosters();
            DBEmployeeController.LoadEmployees();
            DBWishForDayOffController.LoadWishForDayOffs();
            DBDutyController.LoadDuties();
            DBDutyExchangeController.LoadDutyExchanges();
        }

		private void LoginBtn_Click(object sender, RoutedEventArgs e)
		{
			if (userNameTxtBox.Text.ToUpper() == "USER" && passwordBox.Password.ToUpper() == "USER")
			{
				MenuWindow menuWindow = new MenuWindow();
				menuWindow.Show();
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
		private void Textbox_GetFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb != null)
			{
				tb.SelectAll(); 
			}
		}
		private void Password_GetFocus(object sender, RoutedEventArgs e)
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
