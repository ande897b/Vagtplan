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
using Application.DatabaseControllers;
using Application.Repositories;
using Domain.Models;

namespace UI.Views
{
    public partial class CreateRosterWindow : Window
    {
        public CreateRosterWindow()
        {
            InitializeComponent();
        }

        private void CreateRosterBtn_Click(object sender, RoutedEventArgs e)
        {
            RosterRepository.CreateRoster(DatePickerStart.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, comboBoxShop.Text.ToString().ToLower());
            MessageBox.Show("Vagtplan med " + " i "+ comboBoxShop.Text +" oprettet. Du kan nu indsætte vagter", "Success");
            this.Close();
        }

        private void ComboBoxShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string shop = (comboBoxShop.SelectedItem as ComboBoxItem).Content.ToString().ToLower();
            DateTime startDate;
            if (RosterRepository.CurrentRosterExist(shop) == false)
            {
                startDate = DateTime.Now;
            }
            else
            {
                startDate = RosterRepository.GetEndDate(shop);
            }
            DatePickerStart.SelectedDate = startDate;
            DatePickerEnd.SelectedDate = DatePickerStart.SelectedDate;
        }
    }
}

