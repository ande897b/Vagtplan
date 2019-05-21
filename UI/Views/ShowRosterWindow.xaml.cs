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
using Application;
using Application.Repositories;
using Domain.Models;
using Application.DatabaseControllers;
using Controller.DatabaseControllers;
using Controller.Repositories;

namespace UI.Views
{
    public partial class ShowRosterWindow : Window
    {
        List<Roster> rosters = RosterRepository.GetRosters();
        public Shop Shop { get; set; }
        public ShowRosterWindow(string boxResult)
        {
            if(boxResult.ToLower() == "kongensgade")
            {
                Shop = Shop.kongensgade;
            }
            else if (boxResult.ToLower() == "skibhusvej")
            {
                Shop = Shop.skibhusvej;
            }


            DBDateController.LoadDates(Shop.ToString());

            InitializeComponent();
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime[] dates = GetDates(2019, tabControl.SelectedIndex + 1).ToArray();
            if (tabControl.SelectedIndex == 0) // januar
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 1) // Februar
            {
                if (FebruaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (FebruaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (FebruaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (FebruaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 2) // Marts
            {
                if (MarchTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (MarchTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (MarchTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (MarchTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (MarchTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 3) // April
            {
                if (AprilTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (AprilTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (AprilTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (AprilTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (AprilTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 4) // Maj
            {
                if (MayTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (MayTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (MayTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (MayTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (MayTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 5) // Juni
            {
                if (JuneTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (JuneTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (JuneTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (JuneTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (JuneTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 6) // juli
            {
                if (JulyTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (JulyTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (JulyTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (JulyTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (JulyTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 7) // August
            {
                if (AugustTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (AugustTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (AugustTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (AugustTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (AugustTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 8) // September
            {
                if (SeptemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (SeptemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (SeptemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (SeptemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (SeptemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 9) // Oktober
            {
                if (OctoberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (OctoberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (OctoberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (OctoberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (OctoberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 10) // November
            {
                if (NovemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (NovemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (NovemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (NovemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (NovemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }

            if (tabControl.SelectedIndex == 11) // December
            {
                if (DecemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    ManageComboboxes();
                }
                else if (DecemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    ManageComboboxes();
                }
                else if (DecemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    ManageComboboxes();
                }
                else if (DecemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    ManageComboboxes();
                }
                else if (DecemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    ManageComboboxes();
                }
            }
        }

        public void UpdateComboboxes(bool decision, int comboBox)
        {
            List<Employee> employees = EmployeeRepository.GetEmployees();
            List<string> newEmployees = new List<string>();

            foreach (Employee employee in employees)
            {
                string newEmployee = employee.FirstName;
                newEmployees.Add(newEmployee);
            }

            if (decision == true)
            {
                switch (comboBox)
                {
                    case 1:
                        weekday1combobox.IsEnabled = true;
                        weekday1combobox.ItemsSource = newEmployees;
                        weekday1combobox2.ItemsSource = newEmployees;
                        weekday1combobox3.ItemsSource = newEmployees;
                        break;
                    case 2:
                        weekday2combobox.IsEnabled = true;
                        weekday2combobox.ItemsSource = newEmployees;
                        weekday2combobox2.ItemsSource = newEmployees;
                        weekday2combobox3.ItemsSource = newEmployees;
                        break;
                    case 3:
                        weekday3combobox.IsEnabled = true;
                        weekday3combobox.ItemsSource = newEmployees;
                        weekday3combobox2.ItemsSource = newEmployees;
                        weekday3combobox3.ItemsSource = newEmployees;
                        break;
                    case 4:
                        weekday4combobox.IsEnabled = true;
                        weekday4combobox.ItemsSource = newEmployees;
                        weekday4combobox2.ItemsSource = newEmployees;
                        weekday4combobox3.ItemsSource = newEmployees;
                        break;
                    case 5:
                        weekday5combobox.IsEnabled = true;
                        weekday5combobox.ItemsSource = newEmployees;
                        weekday5combobox2.ItemsSource = newEmployees;
                        weekday5combobox3.ItemsSource = newEmployees;
                        break;
                    case 6:
                        weekday6combobox.IsEnabled = true;
                        weekday6combobox.ItemsSource = newEmployees;
                        weekday6combobox2.ItemsSource = newEmployees;
                        weekday6combobox3.ItemsSource = newEmployees;
                        break;
                    case 7:
                        weekday7combobox.IsEnabled = true;
                        weekday7combobox.ItemsSource = newEmployees;
                        weekday7combobox2.ItemsSource = newEmployees;
                        weekday7combobox3.ItemsSource = newEmployees;
                        break;
                    default:
                        break;
                }
            }

            if (decision == false)
            {
                switch (comboBox)
                {
                    case 1:
                        weekday1combobox.IsEnabled = false;
                        weekday1combobox.SelectedIndex = -1;
                        break;
                    case 2:
                        weekday2combobox.IsEnabled = false;
                        weekday2combobox.SelectedIndex = -1;
                        break;
                    case 3:
                        weekday3combobox.IsEnabled = false;
                        weekday3combobox.SelectedIndex = -1;
                        break;
                    case 4:
                        weekday4combobox.IsEnabled = false;
                        weekday4combobox.SelectedIndex = -1;
                        break;
                    case 5:
                        weekday5combobox.IsEnabled = false;
                        weekday5combobox.SelectedIndex = -1;
                        break;
                    case 6:
                        weekday6combobox.IsEnabled = false;
                        weekday6combobox.SelectedIndex = -1;
                        break;
                    case 7:
                        weekday7combobox.IsEnabled = false;
                        weekday7combobox.SelectedIndex = -1;
                        break;
                    default:
                        break;
                }
            }
        }


        private void ManageComboboxes()
        {
            if (RosterRepository.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(true, 1);
            }
            else
            {
                UpdateComboboxes(false, 1);
            }

            if (RosterRepository.CheckIfDateExists(weekday2label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(true, 2);
            }
            else
            {
                UpdateComboboxes(false, 2);
            }

            if (RosterRepository.CheckIfDateExists(weekday3label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(true, 3);
            }
            else
            {
                UpdateComboboxes(false, 3);
            }

            if (RosterRepository.CheckIfDateExists(weekday4label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(RosterRepository.CheckIfDateExists(weekday4label.Content.ToString(), Shop.ToString()), 4);
            }
            else
            {
                UpdateComboboxes(false, 4);
            }

            if (RosterRepository.CheckIfDateExists(weekday5label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(RosterRepository.CheckIfDateExists(weekday5label.Content.ToString(), Shop.ToString()), 5);
            }
            else
            {
                UpdateComboboxes(false, 5);
            }

            if (RosterRepository.CheckIfDateExists(weekday6label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(RosterRepository.CheckIfDateExists(weekday6label.Content.ToString(), Shop.ToString()), 6);
            }
            else
            {
                UpdateComboboxes(false, 6);
            }

            if (RosterRepository.CheckIfDateExists(weekday7label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(RosterRepository.CheckIfDateExists(weekday7label.Content.ToString(), Shop.ToString()), 7);
            }
            else
            {
                UpdateComboboxes(false, 7);
            }
        }

        private void UpdateSchedule(DateTime[] dates, int i)
        {
            weekday1label.Content = dates[0].Date.AddDays(i * 7).ToString();
            weekday2label.Content = dates[1].Date.AddDays(i * 7).ToString();
            weekday3label.Content = dates[02].Date.AddDays(i * 7).ToString();
            weekday4label.Content = dates[03].Date.AddDays(i * 7).ToString();
            weekday5label.Content = dates[04].Date.AddDays(i * 7).ToString();
            weekday6label.Content = dates[05].Date.AddDays(i * 7).ToString();
            weekday7label.Content = dates[06].Date.AddDays(i * 7).ToString();
        }

        private void weekday1combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday1textbox2.Visibility = Visibility.Visible;
        }

      

        private void weekday1combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Date> dates = DateRepository.GetDates();
            weekday1textbox3.Text = weekday1textbox2.Text.Substring(8, 5) + " - 17:00";
            foreach (Date date in dates)
            {
                if (weekday1label.Content.ToString() == date.Day.ToString())
                {
                    if (date.Day.DayOfWeek == DayOfWeek.Monday)
                    {
                        weekday1textbox3.Text = weekday1textbox2.Text.Substring(8, 5) + "- 16:00";
                    }
                }
            }
            weekday1textbox3.Visibility = Visibility.Visible;
        }

        private void weekday1textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday1textbox2.Text != "10:00 - 17:00")
            {
                weekday1combobox2.Visibility = Visibility.Visible;

            }
        }

        private void weekday1textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            weekday1combobox3.Visibility = Visibility.Visible;
            if (weekday1textbox3.Text.Substring(8, 2) == "17")
            {
                weekday1combobox3.Visibility = Visibility.Hidden;
            }
        }private void weekday1combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday1textbox4.Visibility = Visibility.Visible;
            weekday1textbox4.Text = weekday1textbox3.Text.Substring(8, 5) + " - 17:00";
        }


        private void weekday2combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday2textbox2.Visibility = Visibility.Visible;
        }

        private void weekday2textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday2textbox2.Text != "10:00 - 17:00")
            {
                weekday2combobox2.Visibility = Visibility.Visible;

            }
        }

        private void weekday2combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday2textbox3.Visibility = Visibility.Visible;
            weekday2textbox3.Text = weekday2textbox2.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday2textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday2textbox3.Text != "10:00 - 17:00")
            {
                weekday2combobox3.Visibility = Visibility.Visible;
            }
            if (weekday2textbox3.Text.Substring(8, 2) == "17")
            {
                weekday2combobox3.Visibility = Visibility.Hidden;
            }
        }

        private void weekday2combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday2textbox4.Visibility = Visibility.Visible;
            weekday2textbox4.Text = weekday2textbox3.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday3combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday3textbox2.Visibility = Visibility.Visible;
        }

        private void weekday3textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday3textbox2.Text != "10:00 - 17:00")
            {
                weekday3combobox2.Visibility = Visibility.Visible;

            }
        }

        private void weekday3combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday3textbox3.Visibility = Visibility.Visible;
            weekday3textbox3.Text = weekday3textbox2.Text.Substring(8, 5) + " - 17:00";

        }

        private void weekday3textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday3textbox3.Text.Substring(8,2) == "17")
            {
                weekday3combobox3.Visibility = Visibility.Hidden;
            }
            else
            {
                weekday3combobox3.Visibility = Visibility.Visible;
            }
        }

        private void weekday3combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday3textbox4.Visibility = Visibility.Visible;
            weekday3textbox4.Text = weekday3textbox3.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday4combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday4textbox2.Visibility = Visibility.Visible;
        }

        private void weekday4textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday4textbox2.Text != "10:00 - 17:00")
            {
                weekday4combobox2.Visibility = Visibility.Visible;

            }
        }

        private void weekday4combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday4textbox3.Visibility = Visibility.Visible;
            weekday4textbox3.Text = weekday4textbox2.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday4textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday4textbox3.Text.Substring(8, 2) == "17")
            {
                weekday4combobox3.Visibility = Visibility.Hidden;
            }
            else
            {
                weekday4combobox3.Visibility = Visibility.Visible;
            }
        }

        private void weekday4combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday4textbox4.Visibility = Visibility.Visible;
            weekday4textbox4.Text = weekday4textbox3.Text.Substring(8, 5) + " - 17:00";
        }


        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (weekday1combobox.SelectedItem != null)
        //    {
        //        if (weekday1textbox.Text != null)
        //        {

        //        }
        //        if (weekday1combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday1textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday2combobox.SelectedItem != null)
        //    {
        //        if (weekday2textbox.Text != null)
        //        {

        //        }
        //        if (weekday2combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday2textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday3combobox.SelectedItem != null)
        //    {
        //        if (weekday3textbox.Text != null)
        //        {

        //        }
        //        if (weekday3combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday3textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday4combobox.SelectedItem != null)
        //    {
        //        if (weekday4textbox.Text != null)
        //        {

        //        }
        //        if (weekday4combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday4textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday5combobox.SelectedItem != null)
        //    {
        //        if (weekday5textbox.Text != null)
        //        {

        //        }
        //        if (weekday5combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday5textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday6combobox.SelectedItem != null)
        //    {
        //        if (weekday6textbox.Text != null)
        //        {

        //        }
        //        if (weekday6combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday6textbox2.Text != null)
        //            {

        //            }
        //        }
        //    }
        //    if (weekday7combobox.SelectedItem != null)
        //    {
        //        if (weekday7textbox.Text != null)
        //        {

        //        }
        //        if (weekday7combobox_Copy.SelectedItem != null)
        //        {
        //            if (weekday7textbox2.Text != null)
        //            {

        //            }
        //        }
        // }
        // }
    }
}
