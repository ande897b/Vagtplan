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
using Model.Models;

namespace UI.Views
{
    public partial class ShowRosterWindow : Window
    {
        public Shop Shop { get; set; }

        public ShowRosterWindow(string boxResult)
        {
            InitializeComponent();
            if (boxResult.ToLower() == "kongensgade")
            {
                Shop = Shop.kongensgade;
            }
            else
            {
                Shop = Shop.skibhusvej;
            }
        }
        private static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
        private void ManageDuty(string labelContent, string textboxContent, string employeeName)
        {
            string start = textboxContent.Substring(0, 5);
            string end = textboxContent.Substring(8, 5);
            DateTime startdateTime = new DateTime(int.Parse(labelContent.ToString().Substring(6, 4)), int.Parse(labelContent.ToString().Substring(3, 2)), int.Parse(labelContent.ToString().Substring(0, 2)), int.Parse(start.Substring(0, 2)), int.Parse(start.Substring(3, 2)), 0);
            DateTime enddateTime = new DateTime(int.Parse(labelContent.ToString().Substring(6, 4)), int.Parse(labelContent.ToString().Substring(3, 2)), int.Parse(labelContent.ToString().Substring(0, 2)), int.Parse(end.Substring(0, 2)), int.Parse(end.Substring(3, 2)), 0);
            int employeeID = EmployeeRepository.GetEmployeeID(employeeName);
            int dateID = DateRepository.GetDateID(labelContent, Shop);
            Duty duty = new Duty(employeeID, dateID, startdateTime, enddateTime);
            if (!DutyRepository.DutyExist(duty))
            {
                DBDutyController.CreateDuty(duty);
            }
        }

        private void DeleteDuties(int dateID)
        {
            DutyRepository.Removeduties(dateID);
            DBDutyController.DeleteDuties(dateID);
        }
        private void UpdateSchedule(DateTime[] dates, int i)
        {
            weekday1label.Content = dates[0].Date.AddDays(i * 7).ToString();
            weekday1label2.Content = dates[0].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday2label.Content = dates[1].Date.AddDays(i * 7).ToString();
            weekday2label2.Content = dates[1].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday3label.Content = dates[02].Date.AddDays(i * 7).ToString();
            weekday3label2.Content = dates[02].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday4label.Content = dates[03].Date.AddDays(i * 7).ToString();
            weekday4label2.Content = dates[03].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday5label.Content = dates[04].Date.AddDays(i * 7).ToString();
            weekday5label2.Content = dates[04].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday6label.Content = dates[05].Date.AddDays(i * 7).ToString();
            weekday6label2.Content = dates[05].Date.AddDays(i * 7).DayOfWeek.ToString();
            weekday7label.Content = dates[06].Date.AddDays(i * 7).ToString();
            weekday7label2.Content = dates[06].Date.AddDays(i * 7).DayOfWeek.ToString();
        }
        private void ManageComboboxes()
        {
            if (RosterRepository.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday1label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday1label.Content.ToString());
                UpdateComboboxes(true, dateID, 1, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday1label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday1label.Content.ToString());
                UpdateComboboxes(false, dateID, 1, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday2label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday2label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday2label.Content.ToString());
                UpdateComboboxes(true, dateID, 2, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday2label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday2label.Content.ToString());
                UpdateComboboxes(false, dateID, 2, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday3label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday3label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday3label.Content.ToString());
                UpdateComboboxes(true, dateID, 3, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday3label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday3label.Content.ToString());
                UpdateComboboxes(false, dateID, 3, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday4label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday4label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday4label.Content.ToString());
                UpdateComboboxes(true, dateID, 4, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday4label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday4label.Content.ToString());
                UpdateComboboxes(false, dateID, 4, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday5label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday5label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday5label.Content.ToString());
                UpdateComboboxes(true, dateID, 5, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday5label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday5label.Content.ToString());
                UpdateComboboxes(false, dateID, 5, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday6label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday6label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday6label.Content.ToString());
                UpdateComboboxes(true, dateID, 6, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday6label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday6label.Content.ToString());
                UpdateComboboxes(false, dateID, 6, date);
            }

            if (RosterRepository.CheckIfDateExists(weekday7label.Content.ToString(), Shop.ToString()))
            {
                int dateID = DateRepository.GetDateID(weekday7label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday7label.Content.ToString());
                UpdateComboboxes(true, dateID, 7, date);
            }
            else
            {
                int dateID = DateRepository.GetDateID(weekday7label.Content.ToString(), Shop);
                DateTime date = DateRepository.GetDate(weekday7label.Content.ToString());
                UpdateComboboxes(false, dateID, 7, date);
            }
        }
        private void ResetComboboxes(int dayID)
        {


            switch (dayID)
            {
                case 1:
                    weekday1combobox.SelectedIndex = -1;
                    weekday1combobox2.SelectedIndex = -1;
                    weekday1combobox3.SelectedIndex = -1;
                    weekday1combobox2.Visibility = Visibility.Hidden;
                    weekday1combobox3.Visibility = Visibility.Hidden;

                    weekday1textbox2.Visibility = Visibility.Hidden;
                    weekday1textbox3.Visibility = Visibility.Hidden;
                    weekday1textbox4.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    weekday2combobox.SelectedIndex = -1;
                    weekday2combobox2.SelectedIndex = -1;
                    weekday2combobox3.SelectedIndex = -1;
                    weekday2combobox2.Visibility = Visibility.Hidden;
                    weekday2combobox3.Visibility = Visibility.Hidden;

                    weekday2textbox2.Visibility = Visibility.Hidden;
                    weekday2textbox3.Visibility = Visibility.Hidden;
                    weekday2textbox4.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    weekday3combobox.SelectedIndex = -1;
                    weekday3combobox2.SelectedIndex = -1;
                    weekday3combobox3.SelectedIndex = -1;
                    weekday3combobox2.Visibility = Visibility.Hidden;
                    weekday3combobox3.Visibility = Visibility.Hidden;
                    weekday3textbox2.Visibility = Visibility.Hidden;
                    weekday3textbox3.Visibility = Visibility.Hidden;
                    weekday3textbox4.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    weekday4combobox.SelectedIndex = -1;
                    weekday4combobox2.SelectedIndex = -1;
                    weekday4combobox3.SelectedIndex = -1;
                    weekday4combobox2.Visibility = Visibility.Hidden;
                    weekday4combobox3.Visibility = Visibility.Hidden;
                    weekday4textbox2.Visibility = Visibility.Hidden;
                    weekday4textbox3.Visibility = Visibility.Hidden;
                    weekday4textbox4.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    weekday5combobox.SelectedIndex = -1;
                    weekday5combobox2.SelectedIndex = -1;
                    weekday5combobox3.SelectedIndex = -1;
                    weekday5combobox2.Visibility = Visibility.Hidden;
                    weekday5combobox3.Visibility = Visibility.Hidden;
                    weekday5textbox2.Visibility = Visibility.Hidden;
                    weekday5textbox3.Visibility = Visibility.Hidden;
                    weekday5textbox4.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    weekday6combobox.SelectedIndex = -1;
                    weekday6combobox2.SelectedIndex = -1;
                    weekday6combobox3.SelectedIndex = -1;
                    weekday6combobox2.Visibility = Visibility.Hidden;
                    weekday6combobox3.Visibility = Visibility.Hidden;
                    weekday6textbox2.Visibility = Visibility.Hidden;
                    weekday6textbox3.Visibility = Visibility.Hidden;
                    weekday6textbox4.Visibility = Visibility.Hidden;
                    break;
                case 7:
                    weekday7combobox.SelectedIndex = -1;
                    weekday7combobox2.SelectedIndex = -1;
                    weekday7combobox3.SelectedIndex = -1;
                    weekday7combobox2.Visibility = Visibility.Hidden;
                    weekday7combobox3.Visibility = Visibility.Hidden;
                    weekday7textbox2.Visibility = Visibility.Hidden;
                    weekday7textbox3.Visibility = Visibility.Hidden;
                    weekday7textbox4.Visibility = Visibility.Hidden;
                    break;
            }

        }
        private void weekday1combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday1textbox2.Visibility = Visibility.Visible;
        }

        private void weekday1combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Date> dates = DateRepository.GetDates(Shop.ToString());
            weekday1textbox3.Text = weekday1textbox2.Text.Substring(8, 5) + " - 17:00";
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
        }

        private void weekday1combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            if (weekday3textbox3.Text.Substring(8, 2) == "17")
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

        private void weekday5combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday5textbox2.Visibility = Visibility.Visible;
        }

        private void weekday5textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday5textbox2.Text != "10:00 - 17:00")
            {
                weekday5combobox2.Visibility = Visibility.Visible;

            }
        }

        private void weekday5combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday5textbox3.Visibility = Visibility.Visible;
            weekday5textbox3.Text = weekday5textbox2.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday5textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday5textbox3.Text.Substring(8, 2) == "17")
            {
                weekday5combobox3.Visibility = Visibility.Hidden;
            }
            else
            {
                weekday5combobox3.Visibility = Visibility.Visible;
            }
        }

        private void weekday5combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday5textbox4.Visibility = Visibility.Visible;
            weekday5textbox4.Text = weekday5textbox3.Text.Substring(8, 5) + " - 17:00";
        }
        private void weekday6combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            weekday6textbox2.Visibility = Visibility.Visible;

        }
        private void weekday6textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday6textbox2.Text.Substring(8, 2) != "17")
            {
                weekday6combobox2.Visibility = Visibility.Visible;
            }
        }

        private void weekday6combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday6textbox3.Visibility = Visibility.Visible;
            weekday6textbox3.Text = weekday6textbox2.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday6textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday6textbox3.Text.Substring(8, 2) == "17")
            {
                weekday6combobox3.Visibility = Visibility.Hidden;
            }
            else
            {
                weekday6combobox3.Visibility = Visibility.Visible;
            }
        }

        private void weekday6combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday6textbox4.Visibility = Visibility.Visible;
            weekday6textbox4.Text = weekday6textbox3.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday7combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday7textbox2.Visibility = Visibility.Visible;
        }

        private void weekday7textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday7textbox2.Text.Substring(8, 2) != "17")
            {
                weekday7combobox2.Visibility = Visibility.Visible;
            }
        }

        private void weekday7combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday7textbox3.Visibility = Visibility.Visible;
            weekday7textbox3.Text = weekday7textbox2.Text.Substring(8, 5) + " - 17:00";
        }

        private void weekday7textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (weekday7textbox3.Text.Substring(8, 2) == "17")
            {
                weekday7combobox3.Visibility = Visibility.Hidden;
            }
            else
            {
                weekday7combobox3.Visibility = Visibility.Visible;
            }
        }

        private void weekday7combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            weekday7textbox4.Visibility = Visibility.Visible;
            weekday7textbox4.Text = weekday7textbox3.Text.Substring(8, 5) + " - 17:00";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteDuties(DateRepository.GetDateID(weekday1label.Content.ToString(), Shop));
            if (weekday1combobox.SelectedItem != null) // 1
            {

                if (weekday1textbox2.Text != null)
                {
                    ManageDuty(weekday1label.Content.ToString(), weekday1textbox2.Text, weekday1combobox.SelectedItem.ToString());
                }
                if (weekday1combobox2.SelectedItem != null)
                {
                    if (weekday1textbox3.Text != null)
                    {
                        ManageDuty(weekday1label.Content.ToString(), weekday1textbox3.Text, weekday1combobox2.SelectedItem.ToString());
                    }
                    if (weekday1combobox3.SelectedItem != null)
                    {
                        if (weekday1textbox4.Text != null)
                        {
                            ManageDuty(weekday1label.Content.ToString(), weekday1textbox4.Text, weekday1combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday2label.Content.ToString(), Shop));
            if (weekday2combobox.SelectedItem != null) // 2
            {

                if (weekday2textbox2.Text != null)
                {
                    ManageDuty(weekday2label.Content.ToString(), weekday2textbox2.Text, weekday2combobox.SelectedItem.ToString());
                }
                if (weekday2combobox2.SelectedItem != null)
                {
                    if (weekday2textbox3.Text != null)
                    {
                        ManageDuty(weekday2label.Content.ToString(), weekday2textbox3.Text, weekday2combobox2.SelectedItem.ToString());
                    }
                    if (weekday2combobox3.SelectedItem != null)
                    {
                        if (weekday2textbox4.Text != null)
                        {
                            ManageDuty(weekday2label.Content.ToString(), weekday2textbox4.Text, weekday2combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday3label.Content.ToString(), Shop));
            if (weekday3combobox.SelectedItem != null) // 3
            {
                if (weekday3textbox2.Text != null)
                {
                    ManageDuty(weekday3label.Content.ToString(), weekday3textbox2.Text, weekday3combobox.SelectedItem.ToString());
                }
                if (weekday3combobox2.SelectedItem != null)
                {
                    if (weekday3textbox3.Text != null)
                    {
                        ManageDuty(weekday3label.Content.ToString(), weekday3textbox3.Text, weekday3combobox2.SelectedItem.ToString());
                    }
                    if (weekday3combobox3.SelectedItem != null)
                    {
                        if (weekday3textbox4.Text != null)
                        {
                            ManageDuty(weekday3label.Content.ToString(), weekday3textbox4.Text, weekday3combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday4label.Content.ToString(), Shop));
            if (weekday4combobox.SelectedItem != null) // 4
            {
                if (weekday4textbox2.Text != null)
                {
                    ManageDuty(weekday4label.Content.ToString(), weekday4textbox2.Text, weekday4combobox.SelectedItem.ToString());
                }
                if (weekday4combobox2.SelectedItem != null)
                {
                    if (weekday4textbox3.Text != null)
                    {
                        ManageDuty(weekday4label.Content.ToString(), weekday4textbox3.Text, weekday4combobox2.SelectedItem.ToString());
                    }
                    if (weekday4combobox3.SelectedItem != null)
                    {
                        if (weekday4textbox4.Text != null)
                        {
                            ManageDuty(weekday4label.Content.ToString(), weekday4textbox4.Text, weekday4combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday5label.Content.ToString(), Shop));
            if (weekday5combobox.SelectedItem != null) // 5
            {
                if (weekday5textbox2.Text != null)
                {
                    ManageDuty(weekday5label.Content.ToString(), weekday5textbox2.Text, weekday5combobox.SelectedItem.ToString());
                }
                if (weekday5combobox2.SelectedItem != null)
                {
                    if (weekday5textbox3.Text != null)
                    {
                        ManageDuty(weekday5label.Content.ToString(), weekday5textbox3.Text, weekday5combobox2.SelectedItem.ToString());
                    }
                    if (weekday5combobox3.SelectedItem != null)
                    {
                        if (weekday5textbox4.Text != null)
                        {
                            ManageDuty(weekday5label.Content.ToString(), weekday5textbox4.Text, weekday5combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday6label.Content.ToString(), Shop));
            if (weekday6combobox.SelectedItem != null) // 6
            {
                if (weekday6textbox2.Text != null)
                {
                    ManageDuty(weekday6label.Content.ToString(), weekday6textbox2.Text, weekday6combobox.SelectedItem.ToString());
                }
                if (weekday6combobox2.SelectedItem != null)
                {
                    if (weekday6textbox3.Text != null)
                    {
                        ManageDuty(weekday6label.Content.ToString(), weekday6textbox3.Text, weekday6combobox2.SelectedItem.ToString());
                    }
                    if (weekday6combobox3.SelectedItem != null)
                    {
                        if (weekday6textbox4.Text != null)
                        {
                            ManageDuty(weekday6label.Content.ToString(), weekday6textbox4.Text, weekday6combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            DeleteDuties(DateRepository.GetDateID(weekday7label.Content.ToString(), Shop));
            if (weekday7combobox.SelectedItem != null) // 7
            {
                if (weekday7textbox2.Text != null)
                {
                    ManageDuty(weekday7label.Content.ToString(), weekday7textbox2.Text, weekday7combobox.SelectedItem.ToString());
                }
                if (weekday7combobox2.SelectedItem != null)
                {
                    if (weekday7textbox3.Text != null)
                    {
                        ManageDuty(weekday7label.Content.ToString(), weekday7textbox3.Text, weekday7combobox2.SelectedItem.ToString());
                    }
                    if (weekday7combobox3.SelectedItem != null)
                    {
                        if (weekday7textbox4.Text != null)
                        {
                            ManageDuty(weekday7label.Content.ToString(), weekday7textbox4.Text, weekday7combobox3.SelectedItem.ToString());
                        }
                    }
                }
            }
            MessageBox.Show("vagterne er blevet gemt", "success");
        }

        private void Weekday1resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(1);
        }

        private void Weekday2resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(2);
        }

        private void Weekday3resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(3);
        }

        private void Weekday4resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(4);
        }

        private void Weekday5resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(5);
        }

        private void Weekday6resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(6);
        }

        private void Weekday7resetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetComboboxes(7);
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

        private void UpdateComboboxes(bool decision, int dateID, int comboBox, DateTime date)
        {
            DateTime[] holidays = new DateTime[]
            {
                 new DateTime(2019, 01, 01), //Nytårsdag
                 new DateTime(2019, 04, 18), //Skærtorsdag
                 new DateTime(2019, 04, 19), //Langfredag
                 new DateTime(2019, 04, 21), //påskedag
                 new DateTime(2019, 04, 22), //anden påskedag
                 new DateTime(2019, 05, 17), //store Bededag
                 new DateTime(2019, 05, 30), //kristi himmelfartsdag
                 new DateTime(2019, 06, 09), //pinsedag
                 new DateTime(2019, 06, 10), //anden pinsedag
                 new DateTime(2019, 12, 24), //juledag
                 new DateTime(2019, 12, 25)  // Anden juledag      
            };
            bool isHoliday = false;
            foreach (DateTime holiday in holidays)
            {
                if (holiday.ToString().Substring(0, 10) == date.ToString().Substring(0, 10))
                {
                    isHoliday = true;
                }
            }

            List<Employee> employees = EmployeeRepository.GetEmployees();
            List<Duty> duties = DutyRepository.GetDuties(dateID);
            List<string> newEmployees = new List<string>();

            List<WishForDayOff> wishes = WishForDayOffRepository.GetWishForDayOffs(date.ToString().Substring(0,10));

            foreach (Employee employee in employees)
            {
                bool employeeWishesFree = false;
                foreach (WishForDayOff wish in wishes)
                {
                    if (employee.EmployeeID == wish.EmployeeID)
                    {
                        employeeWishesFree = true;
                    }
                }
                if (!employeeWishesFree)
                {
                    string newEmployee = employee.FirstName;
                    newEmployees.Add(newEmployee);
                }
            }

            if (decision == true)
            {
                switch (comboBox)
                {
                    case 1:
                        if (!isHoliday)
                            weekday1combobox.IsEnabled = true;
                        else
                            weekday1combobox.IsEnabled = false;

                        weekday1combobox.ItemsSource = newEmployees;
                        weekday1combobox2.ItemsSource = newEmployees;
                        weekday1combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday1combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday1textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday1combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday1combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {
                                weekday1combobox2.Visibility = Visibility.Visible;
                                weekday1textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday1combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday1combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {
                                weekday1combobox3.Visibility = Visibility.Visible;
                                weekday1textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday1label2.Content.ToString() == "Sunday")
                                weekday1combobox.IsEnabled = false;
                            ResetComboboxes(1);
                        }
                        break;

                    case 2:
                        if (!isHoliday)
                            weekday2combobox.IsEnabled = true;
                        else
                            weekday2combobox.IsEnabled = false;

                        weekday2combobox.ItemsSource = newEmployees;
                        weekday2combobox2.ItemsSource = newEmployees;
                        weekday2combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday2combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday2textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday2combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday2combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {
                                weekday2combobox2.Visibility = Visibility.Visible;
                                weekday2textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if(duties.Count >= 3)
                                weekday2combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday2combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {
                                
                                weekday2combobox3.Visibility = Visibility.Visible;
                                weekday2textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday2label2.Content.ToString() == "Sunday")
                                weekday2combobox.IsEnabled = false;
                            ResetComboboxes(2);
                        }
                        break;

                    case 3:
                        if (!isHoliday)
                            weekday3combobox.IsEnabled = true;
                        else
                            weekday3combobox.IsEnabled = false;

                        weekday3combobox.ItemsSource = newEmployees;
                        weekday3combobox2.ItemsSource = newEmployees;
                        weekday3combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday3combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday3textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday3combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday3combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {
                                weekday3combobox2.Visibility = Visibility.Visible;
                                weekday3textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday3combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday3combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {
                                weekday3combobox3.Visibility = Visibility.Visible;
                                weekday3textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday3label2.Content.ToString() == "Sunday")
                                weekday3combobox.IsEnabled = false;
                            ResetComboboxes(3);
                        }
                        break;

                    case 4:
                        if (!isHoliday)
                            weekday4combobox.IsEnabled = true;
                        else
                            weekday4combobox.IsEnabled = false;

                        weekday4combobox.ItemsSource = newEmployees;
                        weekday4combobox2.ItemsSource = newEmployees;
                        weekday4combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday4combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday4textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday4combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday4combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {
                                weekday4combobox2.Visibility = Visibility.Visible;
                                weekday4textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday4combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday4combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {
                                weekday4combobox3.Visibility = Visibility.Visible;
                                weekday4textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday4label2.Content.ToString() == "Sunday")
                                weekday4combobox.IsEnabled = false;
                            ResetComboboxes(4);
                        }
                        break;

                    case 5:
                        if (!isHoliday)
                            weekday5combobox.IsEnabled = true;
                        else
                            weekday5combobox.IsEnabled = false;

                        weekday5combobox.ItemsSource = newEmployees;
                        weekday5combobox2.ItemsSource = newEmployees;
                        weekday5combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday5combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday5textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday5combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday5combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {

                                weekday5combobox2.Visibility = Visibility.Visible;
                                weekday5textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday5combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday5combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {

                                weekday5combobox3.Visibility = Visibility.Visible;
                                weekday5textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday5label2.Content.ToString() == "Sunday")
                                weekday5combobox.IsEnabled = false;
                            ResetComboboxes(5);
                        }
                        break;

                    case 6:
                        if (!isHoliday)
                            weekday6combobox.IsEnabled = true;
                        else
                            weekday6combobox.IsEnabled = false;

                        weekday6combobox.ItemsSource = newEmployees;
                        weekday6combobox2.ItemsSource = newEmployees;
                        weekday6combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday6combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday6textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday6combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday6combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {

                                weekday6combobox2.Visibility = Visibility.Visible;
                                weekday6textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday6combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday6combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {

                                weekday6combobox3.Visibility = Visibility.Visible;
                                weekday6textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday6label2.Content.ToString() == "Sunday")
                                weekday6combobox.IsEnabled = false;
                            ResetComboboxes(6);
                        }
                        break;

                    case 7:
                        if (!isHoliday)
                            weekday7combobox.IsEnabled = true;
                        else
                            weekday7combobox.IsEnabled = false;

                        weekday7combobox.ItemsSource = newEmployees;
                        weekday7combobox2.ItemsSource = newEmployees;
                        weekday7combobox3.ItemsSource = newEmployees;

                        if (duties.Count >= 1)
                        {
                            weekday7combobox.SelectedItem = EmployeeRepository.GetEmployee(duties[0].EmployeeID).FirstName;
                            weekday7textbox2.Text = duties[0].StartTime.ToString().Substring(11, 5) + " - " + duties[0].EndTime.ToString().Substring(11, 5);
                            if (duties.Count >= 2)
                                weekday7combobox2.SelectedItem = EmployeeRepository.GetEmployee(duties[1].EmployeeID).FirstName;
                            if (weekday7combobox2.SelectedIndex != -1 && duties.Count >= 2)
                            {

                                weekday7combobox2.Visibility = Visibility.Visible;
                                weekday7textbox3.Text = duties[1].StartTime.ToString().Substring(11, 5) + " - " + duties[1].EndTime.ToString().Substring(11, 5);
                            }

                            if (duties.Count >= 3)
                                weekday7combobox3.SelectedItem = EmployeeRepository.GetEmployee(duties[2].EmployeeID).FirstName;
                            if (weekday7combobox3.SelectedIndex != -1 && duties.Count >= 3)
                            {

                                weekday7combobox3.Visibility = Visibility.Visible;
                                weekday7textbox4.Text = duties[2].StartTime.ToString().Substring(11, 5) + " - " + duties[2].EndTime.ToString().Substring(11, 5);
                            }
                        }
                        else
                        {
                            if (weekday7label2.Content.ToString() == "Sunday")
                                weekday7combobox.IsEnabled = false;
                            ResetComboboxes(7);
                        }
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
                        ResetComboboxes(1);
                        break;
                    case 2:
                        weekday2combobox.IsEnabled = false;
                        weekday2combobox.SelectedIndex = -1;
                        ResetComboboxes(2);
                        break;
                    case 3:
                        weekday3combobox.IsEnabled = false;
                        weekday3combobox.SelectedIndex = -1;
                        ResetComboboxes(3);
                        break;
                    case 4:
                        weekday4combobox.IsEnabled = false;
                        weekday4combobox.SelectedIndex = -1;
                        ResetComboboxes(4);
                        break;
                    case 5:
                        weekday5combobox.IsEnabled = false;
                        weekday5combobox.SelectedIndex = -1;
                        ResetComboboxes(5);
                        break;
                    case 6:
                        weekday6combobox.IsEnabled = false;
                        weekday6combobox.SelectedIndex = -1;
                        ResetComboboxes(6);
                        break;
                    case 7:
                        weekday7combobox.IsEnabled = false;
                        weekday7combobox.SelectedIndex = -1;
                        ResetComboboxes(7);
                        break;
                    default:
                        
                        break;
                }
            }
        }
    }
}
