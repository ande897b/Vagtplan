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
using Microsoft.VisualBasic;

namespace UI.Views
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            if (departmentcombobox.SelectedIndex == -1)
            {
                ShowRostersBtn.IsEnabled = false;
            }
        }
        private void CreateRosterBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateRosterWindow createRosterWindow = new CreateRosterWindow();
            createRosterWindow.Show();
        }

        private void AddShiftsBtn_Click(object sender, RoutedEventArgs e)
        {
            AddShiftsWindow addShiftsWindow = new AddShiftsWindow();
            addShiftsWindow.Show();
        }

        private void ShowRostersBtn_Click(object sender, RoutedEventArgs e)
        {
            
                ShowRosterWindow showRosterWindow = new ShowRosterWindow(departmentcombobox.Text);
                showRosterWindow.Show();
            
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
                this.Close();
        }

        private void departmentcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentcombobox.SelectedIndex != -1)
            {
                ShowRostersBtn.IsEnabled = true;
            }
        }
    }
}
