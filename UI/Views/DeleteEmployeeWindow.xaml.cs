using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace UI.Views
{
    public partial class DeleteEmployeeWindow : Window
    {
        public static DeleteEmployeeWindow DeleteEmployeeWindowInstance { get; set; }

        public DeleteEmployeeWindow()
        {
            InitializeComponent();
            DeleteEmployeeWindowInstance = this;
            EmployeeListView.ItemsSource = EmployeeRepository.GetEmployees();
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBEmployeeController.LoadEmployees();
            MenuWindow.MenuWindowInstance.Show();
            e.Cancel = false;
        }

        private void EmployeeListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(EmployeeListView.SelectedIndex != -1)
            {
                MessageBoxButton btn = MessageBoxButton.YesNo;
                MessageBoxImage image = MessageBoxImage.Exclamation;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil slette denne medarbejder fra systemet?", "Slet medarbejder", btn, image);
                if (result == MessageBoxResult.Yes)
                {
                    DBEmployeeController.DeleteEmployee(((Employee)EmployeeListView.SelectedItem).EmployeeID);
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    EmployeeListView.SelectedIndex = -1;
                }
            }
        }
    }
}
