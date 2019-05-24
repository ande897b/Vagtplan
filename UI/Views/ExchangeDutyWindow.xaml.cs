using Application.Repositories;
using Controller.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
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
    public partial class ExchangeDutyWindow : Window
    {
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

            EmployeeCB.ItemsSource = newEmployees;
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
            if(DutyList.SelectedIndex != -1)
            {
                MessageBoxButton btn = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Exclamation;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil bytte denne vagt.", "Vagt bytte", btn, image);
                if (result == MessageBoxResult.Yes)
                {
                    
                    this.Close();
                }
            }

           


        }
    }
}
