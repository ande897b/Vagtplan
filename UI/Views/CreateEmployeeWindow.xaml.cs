using Application.DatabaseControllers;
using System.ComponentModel;
using System.Windows;
using Domain.Models;
using System.Collections.Generic;
using Application.Repositories;

namespace UI.Views
{
    public partial class CreateEmployeeWindow : Window
    {
        public static CreateEmployeeWindow CreateEmployeeWindowInstance { get; set; }

        public CreateEmployeeWindow()
        {
            InitializeComponent();
            CreateEmployeeWindowInstance = this;
            RankCB.ItemsSource = new List<string>
            {
                "Deltidsmedarbejder",
                "Butikschef"
            };
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBEmployeeController.LoadEmployees();
            MenuWindow.MenuWindowInstance.UpdateEmployeeCB();
            MenuWindow.MenuWindowInstance.Show();
            e.Cancel = false;
        }

        private void CreateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Rank rank;
            if (RankCB.SelectedValue.ToString() == "Deltidsmedarbejder")
            {
                rank = Rank.parttimer;
            }
            else
            {
                rank = Rank.manager;
            }
            DBEmployeeController.CreateEmployee(new Employee(FirstNameTB.Text, LastNameTB.Text, rank));
            this.Close();
        }
    }
}
