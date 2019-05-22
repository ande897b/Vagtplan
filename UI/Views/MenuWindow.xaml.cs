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
using Application.DatabaseControllers;
using Application.Repositories;
using Controller.DatabaseControllers;
using Domain.Models;
using Microsoft.VisualBasic;
using Vagtplan.Views;

namespace UI.Views
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            DBRosterController.LoadRosters();
            DBEmployeeController.LoadEmployees();
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

        private void WishForDayOff_Click(object sender, RoutedEventArgs e)
        {
            WishForDayOffWindow dayOff = new WishForDayOffWindow();
            List<Employee> employees = EmployeeRepository.GetEmployees();
            List<string> newEmployees = new List<string>();
            foreach (Employee employee in employees)
            {
                string newEmployee = employee.FirstName;
                newEmployees.Add(newEmployee);
            }
            dayOff.WishForDayOffCB.ItemsSource = newEmployees;
            dayOff.Show();
        }
    }
}
