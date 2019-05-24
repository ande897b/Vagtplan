using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI.Views
{
    public partial class ExchangeDutyWindow : Window
    {
        public List<string> EmployeesProp { get; set; }
        public ExchangeDutyWindow()
        {
            InitializeComponent();

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

        }


        private void DutyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string date = null;
            if (DutyList.SelectedItem != null)
            {
                date = DutyList.SelectedItem.ToString().Substring(0, 10);
                string employeeName = EmployeeCB.SelectedValue.ToString();

                MessageBoxButton btn = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Exclamation;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil bytte denne vagt.", "Vagt bytte", btn, image);
                if (result == MessageBoxResult.Yes)
                {
                    DutyExchange dutyExchange = new DutyExchange(DutyRepository.GetDuty(date, employeeName).DutyID, EmployeeRepository.GetEmployeeID(employeeName));
                    DBDutyExchangeController.CreateDutyExchange(dutyExchange);
                }
            }

        }
        private void DutyList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DutyList2.SelectedItem != null)
            {
                PopupExchangeDutyWindow popupExchangeDutyWindow = new PopupExchangeDutyWindow(EmployeesProp, DutyList2.SelectedValue.ToString(), DutyRepository.GetDuty(DutyList2.SelectedItem.ToString().Substring(0, 10), DutyList2.SelectedValue.ToString().Substring(16)).DutyID);
                popupExchangeDutyWindow.Show();
                UpdateDutyList2();
            }
        }

        public void UpdateDutyList()
        {
            List<Duty> duties = DutyRepository.GetDuties(EmployeeCB.SelectedItem.ToString());
            List<string> dates = new List<string>();

            foreach (Duty duty in duties)
            {
                string date = DateRepository.GetDate(duty.DateID).ToString();
                dates.Add(date.Substring(0, 10));
            }
            DutyList.ItemsSource = dates;
        }

        public void UpdateDutyList2()
        {
            List<DutyExchange> dutyExchanges = DutyExchangeRepository.GetDutyExchanges();
            List<string> newDutyExchanges = new List<string>();
            if (dutyExchanges.Count > 0)
            {
                foreach (DutyExchange dutyExchange in dutyExchanges)
                {
                    string newDutyExchange = DateRepository.GetDate(DutyRepository.GetDuty(dutyExchange.DutyID).DateID).Date.ToString().Substring(0, 10) + " <--> " + EmployeeRepository.GetEmployee(dutyExchange.EmployeeID).FirstName;
                    newDutyExchanges.Add(newDutyExchange);
                }
                DutyList2.ItemsSource = newDutyExchanges;
            }

        }




        private void EmployeeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDutyList();

        }
    }
}
