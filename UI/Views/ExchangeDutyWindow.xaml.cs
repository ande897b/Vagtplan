using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using UI;

namespace UI.Views
{
    public partial class ExchangeDutyWindow : Window
    {
        public List<string> EmployeesProp { get; set; }
        public static ExchangeDutyWindow ExchangeDutyWindowInstance { get; set; }

        public ExchangeDutyWindow()
        {
            InitializeComponent();
            ExchangeDutyWindowInstance = this;
            List<string> newEmployees = new List<string>();
            List<Employee> employees = EmployeeRepository.GetEmployees();
            foreach (Employee employee in employees)
            {
                string newEmployee = employee.FirstName;
                newEmployees.Add(newEmployee);
            }
            EmployeesProp = newEmployees;
            EmployeeCB.ItemsSource = newEmployees;
            UpdateDutyList2();
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBDutyController.LoadDuties();
            DBDutyExchangeController.LoadDutyExchanges();
            MenuWindow.MenuWindowInstance.Show();
            e.Cancel = false;
        }

        public void UpdateDutyList()
        {
            List<Duty> duties = DutyRepository.GetDuties(EmployeeCB.SelectedItem.ToString());
            List<DutyListView> dutyListViews = new List<DutyListView>();
            foreach (Duty duty in duties)
            {
                int dateCompare = DateTime.Compare(duty.StartTime, DateTime.Now);
                if (dateCompare > 0)
                {
                    dutyListViews.Add(new DutyListView
                    {
                        Duty = duty,
                        EmployeeName = EmployeeRepository.GetEmployeeName(duty.EmployeeID)
                    });
                }
            }
            DutyListView.ItemsSource = dutyListViews;
        }

        public void UpdateDutyList2()
        {
            List<DutyExchange> dutyExchanges = DutyExchangeRepository.GetDutyExchanges();
            List<DutyListView> dutyExchangeListViews = new List<DutyListView>();
            foreach (DutyExchange dutyExchange in dutyExchanges)
            {
                dutyExchangeListViews.Add(new DutyListView
                {
                    Duty = DutyRepository.GetDuty(dutyExchange.DutyID),
                    EmployeeName = EmployeeRepository.GetEmployeeName(dutyExchange.EmployeeID)
                });
            }
            DutyExchangeListView.ItemsSource = dutyExchangeListViews;
        }

        private void EmployeeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDutyList();
        }

        private void DutyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DutyListView.SelectedIndex != -1)
            {
                DutyListView dutyListView = (DutyListView)DutyListView.SelectedItem;
                MessageBoxButton btn = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Exclamation;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil bytte denne vagt.", "Vagt bytte", btn, image);
                if (result == MessageBoxResult.Yes)
                {
                    DutyExchange dutyExchange = new DutyExchange(dutyListView.Duty.DutyID, dutyListView.Duty.EmployeeID);
                    DBDutyExchangeController.CreateDutyExchange(dutyExchange);
                    UpdateDutyList2();
                    UpdateDutyList();
                }
            }
        }

        private void DutyExchangeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DutyExchangeListView.SelectedIndex != -1)
            {
                DutyListView dutyExchange = (DutyListView)DutyExchangeListView.SelectedItem;
                PopupExchangeDutyWindow popupExchangeDutyWindow = new PopupExchangeDutyWindow(EmployeesProp, dutyExchange);
                popupExchangeDutyWindow.Show();
                this.Hide();
            }
        }
    }
}
