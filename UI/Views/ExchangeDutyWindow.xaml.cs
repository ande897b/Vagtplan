using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using Model.ViewModels;
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

        //private void DutyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string date = null;
        //    if (DutyList.SelectedItem != null)
        //    {
        //        //date = DutyList.SelectedItem.ToString().Substring(0, 10);
        //        //string employeeName = EmployeeCB.SelectedValue.ToString();
        //        //MessageBoxButton btn = MessageBoxButton.YesNo;
        //        //MessageBoxImage image = MessageBoxImage.Exclamation;
        //        //MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil bytte denne vagt.", "Vagt bytte", btn, image);
        //        //if (result == MessageBoxResult.Yes)
        //        //{
        //        //    DutyExchange dutyExchange = new DutyExchange(DutyRepository.GetDuty(date, employeeName).DutyID, EmployeeRepository.GetEmployeeID(employeeName));
        //        //    DBDutyExchangeController.CreateDutyExchange(dutyExchange);
        //        //    UpdateDutyList2();
        //        //    UpdateDutyList();
        //        //}
        //    }
        //}

        //private void DutyList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (DutyList2.SelectedIndex != -1)
        //    {
        //        //string date = DutyList2.SelectedItem.ToString().Substring(0, 10);
        //        //string firstName = DutyList2.SelectedValue.ToString().Substring(16);
        //        //string dutyList2selected = DutyList2.SelectedValue.ToString();
        //        //Duty duty = DutyRepository.GetDuty(date, firstName);
        //        //PopupExchangeDutyWindow popupExchangeDutyWindow = new PopupExchangeDutyWindow(EmployeesProp, duty.DutyID, this);
        //        //popupExchangeDutyWindow.Show();
        //    }
        //}

        public void UpdateDutyList()
        {
            List<Duty> duties = DutyRepository.GetDuties(EmployeeCB.SelectedItem.ToString());
            List<DutyListView> dutyListViews = new List<DutyListView>();
            foreach (Duty duty in duties)
            {
                dutyListViews.Add(new DutyListView
                {
                    Duty = duty,
                    EmployeeName = EmployeeRepository.GetEmployeeName(duty.EmployeeID)
                });
            }
            DutyListView.ItemsSource = dutyListViews;
            //List<string> dutiesS = new List<string>();
            //if (duties.Count > 0)
            //{
            //    foreach (Duty duty in duties)
            //    {
            //        string dutyS = DateRepository.GetDate(DutyRepository.GetDuty(duty.DutyID).DateID).Date.ToString().Substring(0, 10) + " <--> " + EmployeeRepository.GetEmployee(duty.EmployeeID).FirstName;
            //        dutiesS.Add(dutyS);
            //        DutyListView.Items.Add(duty);
            //    }
            //    DutyList.ItemsSource = dutiesS;
            //}
            //else
            //{
            //    DutyList.ItemsSource = null;
            //}
        }

        public void UpdateDutyList2()
        {
            List<DutyExchange> dutyExchanges = DutyExchangeRepository.GetDutyExchanges();
            List<DutyExchangeListView> dutyExchangeListViews = new List<DutyExchangeListView>();
            foreach (DutyExchange dutyExchange in dutyExchanges)
            {
                dutyExchangeListViews.Add(new DutyExchangeListView
                {
                    DutyExchange = dutyExchange,
                    Duty = DutyRepository.GetDuty(dutyExchange.DutyID)
                });
            }
            DutyExchangeListView.ItemsSource = dutyExchangeListViews;
            //List<string> newDutyExchanges = new List<string>();
            //if (dutyExchanges.Count > 0)
            //{
            //    foreach (DutyExchange dutyExchange in dutyExchanges)
            //    {
            //        string newDutyExchange = DateRepository.GetDate(DutyRepository.GetDuty(dutyExchange.DutyID).DateID).Date.ToString().Substring(0, 10) + " <--> " + EmployeeRepository.GetEmployee(dutyExchange.EmployeeID).FirstName;
            //        newDutyExchanges.Add(newDutyExchange);
            //    }
            //    DutyList2.ItemsSource = newDutyExchanges;
            //}
            //else
            //{
            //    DutyList2.ItemsSource = null;
            //}
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
                //string date = DutyList2.SelectedItem.ToString().Substring(0, 10);
                //string firstName = DutyList2.SelectedValue.ToString().Substring(16);
                //string dutyList2selected = DutyList2.SelectedValue.ToString();
                DutyExchangeListView dutyExchange = (DutyExchangeListView)DutyExchangeListView.SelectedItem;
                PopupExchangeDutyWindow popupExchangeDutyWindow = new PopupExchangeDutyWindow(EmployeesProp, dutyExchange);
                popupExchangeDutyWindow.Show();
                this.Hide();
            }
        }
    }
}
