using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace UI.Views
{
    public partial class PopupExchangeDutyWindow : Window
    {
        DutyExchangeListView DutyExchangeListView { get; set; }
        public static PopupExchangeDutyWindow PopupExchangeDutyWindowInstance { get; set; }

        public PopupExchangeDutyWindow(List<string> employeeList, DutyExchangeListView dutyExchangeListView)
        {
            InitializeComponent();
            PopupExchangeDutyWindowInstance = this;
            DutyExchangeListView = dutyExchangeListView;
            EmployeeCB.ItemsSource = employeeList;
            DutyIDLabel.Content = DutyExchangeListView.Duty.DutyID;
            EmployeeLabel.Content = EmployeeRepository.GetEmployeeName(DutyExchangeListView.Duty.EmployeeID);
            StartTimeLabel.Content = DutyExchangeListView.Duty.StartTime;
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBDutyController.LoadDuties();
            DBDutyExchangeController.LoadDutyExchanges();
            e.Cancel = false;
        }
        
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int newEmployeeID = EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString());
            int oldEmployeeID = EmployeeRepository.GetEmployeeID(EmployeeRepository.GetEmployeeName(DutyExchangeListView.Duty.EmployeeID));

            try
            {
                DBDutyController.UpdateDuty(newEmployeeID, DutyExchangeListView.Duty.DutyID);
                MessageBox.Show("Vagt er opdateret");
            }
            catch(Exception t)
            {
                MessageBox.Show(t.Message);
            }

            DBDutyExchangeController.DeleteDutyExchange(DutyExchangeListView.Duty.DutyID, oldEmployeeID);
            DutyExchangeRepository.RemoveDutyExchange(DutyExchangeListView.Duty.DutyID, oldEmployeeID);
            ExchangeDutyWindow.ExchangeDutyWindowInstance.UpdateDutyList2();
            ExchangeDutyWindow.ExchangeDutyWindowInstance.Show();
            this.Close();
        }

        private void Regret_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ExchangeDutyWindow.ExchangeDutyWindowInstance.Show();
        }
    }
}
