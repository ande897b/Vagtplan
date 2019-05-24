using Application.Repositories;
using Controller.DatabaseControllers;
using Domain.Models;
using Model.Models;
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
    public partial class WishForDayOffWindow : Window
    {
        public WishForDayOffWindow()
        {
            InitializeComponent();
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
