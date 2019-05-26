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
        DutyListView DutyExchangeListView { get; set; }
        public static PopupExchangeDutyWindow PopupExchangeDutyWindowInstance { get; set; }

        public PopupExchangeDutyWindow(List<string> employeeList, DutyListView dutyListView)
        {
            InitializeComponent();
            PopupExchangeDutyWindowInstance = this;
            DutyExchangeListView = dutyListView;
            EmployeeCB.ItemsSource = employeeList;
            DutyIDLabel.Content = DutyExchangeListView.Duty.DutyID;
            EmployeeLabel.Content = EmployeeRepository.GetEmployeeName(DutyExchangeListView.Duty.EmployeeID);
            StartTimeLabel.Content = DutyExchangeListView.Duty.StartTime;
            EndTimeLabel.Content = DutyExchangeListView.Duty.EndTime;
            this.Closing += WindowClosed;

            if(EmployeeCB.SelectedIndex == -1)
            {
                Confirm_Btn.IsEnabled = false;
            }
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
            ExchangeDutyWindow.ExchangeDutyWindowInstance.UpdateDutyList();
            ExchangeDutyWindow.ExchangeDutyWindowInstance.Show();
            this.Close();
        }

        private void Regret_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ExchangeDutyWindow.ExchangeDutyWindowInstance.DutyExchangeListView.SelectedIndex = -1;
            ExchangeDutyWindow.ExchangeDutyWindowInstance.DutyListView.SelectedIndex = -1;
            ExchangeDutyWindow.ExchangeDutyWindowInstance.Show();
        }

        private void EmployeeCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Confirm_Btn.IsEnabled = true;
        }
    }
}
