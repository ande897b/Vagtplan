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
            string result = Interaction.InputBox("Write shop name", "", "shop");

            if(result != "shop")
            {
                ShowRosterWindow showRosterWindow = new ShowRosterWindow(result);
                showRosterWindow.Show();
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
                this.Close();
        }
    }
}
