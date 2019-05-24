using Application.DatabaseControllers;
using Application.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace UI.Views
{

    public partial class PopupExchangeDutyWindow : Window
    {
        public int DutyID { get; set; }
        public PopupExchangeDutyWindow(List<string> employeeList, string exchange, int dutyID)
        {
            InitializeComponent();

            DutyID = dutyID;
            EmployeeCB.ItemsSource = employeeList;
            DutyLabel.Content = exchange;

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
            this.Visibility = Visibility.Hidden;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DBDutyController.UpdateDuty(EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString()), DutyID);
            DBDutyExchangeController.DeleteDutyExchange(DutyRepository.GetDuty(DutyLabel.Content.ToString().Substring(0, 10), DutyLabel.Content.ToString().Substring(16)).DutyID, EmployeeRepository.GetEmployeeID(DutyLabel.Content.ToString().Substring(16)));
            this.Close();
        }
    }
}
