using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Application.DatabaseControllers;
using Application.Repositories;

namespace UI.Views
{
    public partial class CreateRosterWindow : Window
    {
        public CreateRosterWindow()
        {
            InitializeComponent();
            this.Closing += WindowClosed;
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            DBRosterController.LoadRosters();
            e.Cancel = false;
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

