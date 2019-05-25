using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace UI.Views
{
    public partial class WishForDayOffWindow : Window
    {
        public WishForDayOffWindow()
        {
            InitializeComponent();

            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBWishForDayOffController.LoadWishForDayOffs();
            e.Cancel = false;
        }

        private void WishForDayOffBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show($"Er du sikker på at {WishForDayOffCB.SelectedItem.ToString()} vil ønske fri på datoen: {WishForDayOffDP.SelectedDate.ToString().Substring(0,10)}?", "ønsk fri", btn);
            if(result == MessageBoxResult.Yes)
            {
                int employeeID = EmployeeRepository.GetEmployeeID(WishForDayOffCB.SelectedItem.ToString());
                DateTime date = WishForDayOffDP.SelectedDate.Value;
                WishForDayOff newWish = new WishForDayOff(employeeID, date);
                DBWishForDayOffController.CreateWishForDayOff(newWish);
                this.Close();
            }
        }
    }
}
