﻿using Application.DatabaseControllers;
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
        private readonly object thisLock = new object();
        public int DutyID { get; set; }
        public PopupExchangeDutyWindow(List<string> employeeList, string exchange, int dutyID, ExchangeDutyWindow exchangeWindow)
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
            e.Cancel = false;
        }
        
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            lock (thisLock)
            {
                int newEmployeeID = EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString());
                int oldEmployeeID = EmployeeRepository.GetEmployeeID(DutyLabel.Content.ToString().Substring(16));
                int dutyID = DutyRepository.GetDuty(DutyLabel.Content.ToString().Substring(0, 10), DutyLabel.Content.ToString().Substring(16)).DutyID;
                DBDutyController.UpdateDuty(newEmployeeID, DutyID);

                DBDutyExchangeController.DeleteDutyExchange(dutyID, oldEmployeeID);
            }
            lock (thisLock)
            {
                int newEmployeeID = EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString());
                int oldEmployeeID = EmployeeRepository.GetEmployeeID(DutyLabel.Content.ToString().Substring(16));
                int dutyID = DutyRepository.GetDuty(DutyLabel.Content.ToString().Substring(0, 10), DutyLabel.Content.ToString().Substring(16)).DutyID;

                DutyExchangeRepository.RemoveDutyExchange(dutyID, oldEmployeeID);
            }

            this.Close();
        }
    }
}
