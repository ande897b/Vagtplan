using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Application.Repositories;
using Domain.Models;

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

        private void ExchangeDuty_Click(object sender, RoutedEventArgs e)
        {
            ExchangeDutyWindow exchangeDutyWindow = new ExchangeDutyWindow();
            exchangeDutyWindow.Show();
        }
    }
}
