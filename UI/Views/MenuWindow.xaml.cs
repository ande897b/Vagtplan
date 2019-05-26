using System;
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
            DateTime now = DateTime.Now;
            int month = now.Month;
            int week = 0;
            int day = now.Day;
            if (day >= 1)
                week = 0;
            if (day >= 8)
                week = 1;
            if (day >= 15)
                week = 2;
            if (day >= 22)
                week = 3;
            if (day >= 29)
                week = 4;
            ShowRosterWindow showRosterWindow = new ShowRosterWindow(departmentcombobox.Text);
            showRosterWindow.tabControl.SelectedIndex = month - 1;
            switch (month)
            {
                case 1:
                    showRosterWindow.JanuaryTabControl.SelectedIndex = week;
                    break;
                case 2:
                    showRosterWindow.FebruaryTabControl.SelectedIndex = week;
                    break;
                case 3:
                    showRosterWindow.MarchTabControl.SelectedIndex = week;
                    break;
                case 4:
                    showRosterWindow.AprilTabControl.SelectedIndex = week;
                    break;
                case 5:
                    showRosterWindow.MayTabControl.SelectedIndex = week;
                    break;
                case 6:
                    showRosterWindow.JuneTabControl.SelectedIndex = week;
                    break;
                case 7:
                    showRosterWindow.JulyTabControl.SelectedIndex = week;
                    break;
                case 8:
                    showRosterWindow.AugustTabControl.SelectedIndex = week;
                    break;
                case 9:
                    showRosterWindow.SeptemberTabControl.SelectedIndex = week;
                    break;
                case 10:
                    showRosterWindow.OctoberTabControl.SelectedIndex = week;
                    break;
                case 11:
                    showRosterWindow.NovemberTabControl.SelectedIndex = week;
                    break;
                case 12:
                    showRosterWindow.DecemberTabControl.SelectedIndex = week;
                    break;
            }
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
