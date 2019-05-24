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
            foreach(Employee employee in employees)
            {
                string newEmployee = employee.FirstName;
                newEmployees.Add(newEmployee);
            }
            EmployeesProp = newEmployees;
            EmployeeCB.ItemsSource = newEmployees;

            List<DutyExchange> dutyExchanges = DutyExchangeRepository.GetDutyExchanges();
            List<string> newDutyExchanges = new List<string>();
            foreach (DutyExchange dutyExchange in dutyExchanges)
            {
                string newDutyExchange = DateRepository.GetDate(DutyRepository.GetDuty(dutyExchange.DutyID).DateID).Date.ToString().Substring(0,10) + " <--> " + EmployeeRepository.GetEmployee(dutyExchange.EmployeeID).FirstName;
                newDutyExchanges.Add(newDutyExchange);
            }
            DutyList2.ItemsSource = newDutyExchanges;
        }

        private void GetDuties_Click(object sender, RoutedEventArgs e)
        {

            List<Duty> duties = DutyRepository.GetDuties(EmployeeCB.SelectedItem.ToString());
            List<string> dates = new List<string>();

            foreach(Duty duty in duties)
            {
                string date = DateRepository.GetDate(duty.DateID).ToString();
                dates.Add(date.Substring(0,10));
            }
            DutyList.ItemsSource = dates;
        }

        private void DutyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (DutyList.SelectedIndex != -1)
            {
                MessageBoxButton btn = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Exclamation;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil bytte denne vagt.", "Vagt bytte", btn, image);
                if (result == MessageBoxResult.Yes)
                {
                    DutyExchange dutyExchange = new DutyExchange(DutyRepository.GetDuty(DutyList.SelectedItem.ToString().Substring(0, 10), EmployeeCB.SelectedValue.ToString()).DutyID, EmployeeRepository.GetEmployeeID(EmployeeCB.SelectedValue.ToString()));
                    DBDutyExchangeController.CreateDutyExchange(dutyExchange);
                    this.Close();
                }
            }
        }

        private void DutyList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DutyList2.SelectedIndex != -1)
            {
                PopupExchangeDutyWindow popupExchangeDutyWindow = new PopupExchangeDutyWindow(EmployeesProp, DutyList2.SelectedValue.ToString(), DutyRepository.GetDuty(DutyList2.SelectedItem.ToString().Substring(0, 10), DutyList2.SelectedValue.ToString().Substring(16)).DutyID);
                popupExchangeDutyWindow.Show();
            }
        }
    }
}
