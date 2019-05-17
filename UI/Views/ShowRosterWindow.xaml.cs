﻿using System;
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
using Application.ViewControllers;
using Domain.Models;

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
                    FUCKTHISSHIT();
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 1) // Februar
            {
                if (FebruaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (FebruaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (FebruaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (FebruaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 2) // Marts
            {
                if (MarchTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (MarchTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (MarchTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (MarchTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (MarchTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 3) // April
            {
                if (AprilTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (AprilTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (AprilTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (AprilTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (AprilTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 4) // Maj
            {
                if (MayTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (MayTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (MayTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (MayTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (MayTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 5) // Juni
            {
                if (JuneTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (JuneTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (JuneTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (JuneTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (JuneTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 6) // juli
            {
                if (JulyTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (JulyTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (JulyTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (JulyTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (JulyTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 7) // August
            {
                if (AugustTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (AugustTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (AugustTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (AugustTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (AugustTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 8) // September
            {
                if (SeptemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (SeptemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (SeptemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (SeptemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (SeptemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 9) // Oktober
            {
                if (OctoberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (OctoberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (OctoberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (OctoberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (OctoberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 10) // November
            {
                if (NovemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (NovemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (NovemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (NovemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (NovemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }

            if (tabControl.SelectedIndex == 11) // December
            {
                if (DecemberTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    FUCKTHISSHIT();
                }
                else if (DecemberTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    FUCKTHISSHIT();
                }
                else if (DecemberTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    FUCKTHISSHIT();
                }
                else if (DecemberTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    FUCKTHISSHIT();
                }
                else if (DecemberTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    FUCKTHISSHIT();
                }
            }
        }

        public void UpdateComboboxes(bool decision, int comboBox)
        {
            if (decision == true)
            {
                switch (comboBox)
                {
                    case 1:
                        weekday1combobox.IsEnabled = true;
                        break;
                    case 2:
                        weekday2combobox.IsEnabled = true;
                        break;
                    case 3:
                        weekday3combobox.IsEnabled = true;
                        break;
                    case 4:
                        weekday4combobox.IsEnabled = true;
                        break;
                    case 5:
                        weekday5combobox.IsEnabled = true;
                        break;
                    case 6:
                        weekday6combobox.IsEnabled = true;
                        break;
                    case 7:
                        weekday7combobox.IsEnabled = true;
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

        private void FUCKTHISSHIT()
        {
            if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()), 1);
            }
            else
            {
                UpdateComboboxes(false, 1);
            }

            if (ViewRosterController.CheckIfDateExists(weekday2label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday2label.Content.ToString(), Shop.ToString()), 2);
            }
            else
            {
                UpdateComboboxes(false, 2);
            }

            if (ViewRosterController.CheckIfDateExists(weekday3label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday3label.Content.ToString(), Shop.ToString()), 3);
            }
            else
            {
                UpdateComboboxes(false, 3);
            }

            if (ViewRosterController.CheckIfDateExists(weekday4label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday4label.Content.ToString(), Shop.ToString()), 4);
            }
            else
            {
                UpdateComboboxes(false, 4);
            }

            if (ViewRosterController.CheckIfDateExists(weekday5label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday5label.Content.ToString(), Shop.ToString()), 5);
            }
            else
            {
                UpdateComboboxes(false, 5);
            }

            if (ViewRosterController.CheckIfDateExists(weekday6label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday6label.Content.ToString(), Shop.ToString()), 6);
            }
            else
            {
                UpdateComboboxes(false, 6);
            }

            if (ViewRosterController.CheckIfDateExists(weekday7label.Content.ToString(), Shop.ToString()))
            {
                UpdateComboboxes(ViewRosterController.CheckIfDateExists(weekday7label.Content.ToString(), Shop.ToString()), 7);
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
    }
}
