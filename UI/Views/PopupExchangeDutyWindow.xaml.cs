using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Vagtplan.Views
{

    public partial class PopupExchangeDutyWindow : Window
    {
        public int DutyID { get; set; }
        public PopupExchangeDutyWindow(List<string> employeeList, string exchange,int dutyID)
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
            DBDutyExchangeController.DeleteDutyExchange(DutyRepository.GetDuty(DutyLabel.Content.ToString().Substring(0, 10), DutyLabel.Content.ToString().Substring(16)).DutyID, EmployeeRepository.GetEmployeeID(DutyLabel.Content.ToString().Substring(16)));
            DBDutyController.UpdateDuty(EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString()), DutyID);
            this.Close();
        }
    }
}
