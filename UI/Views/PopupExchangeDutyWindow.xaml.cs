using Application.DatabaseControllers;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace UI.Views
{
    public partial class PopupExchangeDutyWindow : Window
    {
        ExchangeDutyWindow ExchangeDutyWindow { get; set; }
        public int DutyID { get; set; }

        public PopupExchangeDutyWindow(List<string> employeeList, string exchange, int dutyID, ExchangeDutyWindow exchangeDutyWindow)
        {
            InitializeComponent();
            DutyID = dutyID;
            EmployeeCB.ItemsSource = employeeList;
            DutyLabel.Content = exchange;
            ExchangeDutyWindow = exchangeDutyWindow;
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBDateController.LoadDates();
            DBRosterController.LoadRosters();
            DBEmployeeController.LoadEmployees();
            DBWishForDayOffController.LoadWishForDayOffs();
            DBDutyController.LoadDuties();
            DBDutyExchangeController.LoadDutyExchanges();
            e.Cancel = false;
        }
        
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int newEmployeeID = EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString());
            int oldEmployeeID = EmployeeRepository.GetEmployeeID(DutyLabel.Content.ToString().Substring(16));
            int dutyID = DutyRepository.GetDuty(DutyLabel.Content.ToString().Substring(0, 10), DutyLabel.Content.ToString().Substring(16)).DutyID;
            DBDutyController.UpdateDuty(newEmployeeID, DutyID);
            DBDutyExchangeController.DeleteDutyExchange(dutyID, oldEmployeeID);
            DutyExchangeRepository.RemoveDutyExchange(dutyID, oldEmployeeID);
            ExchangeDutyWindow.Close();
            this.Close();
        }
    }
}
