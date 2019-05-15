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
using Application.ViewControllers;
using Domain.Models;

namespace UI.Views
{
    public partial class ShowRosterWindow : Window
    {
        public Shop Shop { get; set; }
        List<Roster> rosters = RosterRepository.GetRosters();
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
            //List<Roster> rosters = RosterRepository.GetRosters();
            //rosterArrays = new List<Roster[]>();

            //for (int i = 0; i < rosters.Count; i++)
            //{
            //    DateTime start = rosters[i].StartDate;
            //    Date[] dates = new Date[360];

            //    for (int j = 0; start <= rosters[i].EndDate; j++)
            //    {
            //        dates[j] = rosters[i].;
            //        start = start.AddDays(1);
            //    }
            //    rosterArrays.Add(dates);
            //}
        }

       

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        private List<Date> GetSpecificDates(List<Date> dates, string startDate)
        {
            List<Date> specificDates = new List<Date>();
            int i = 0;
            foreach (var date in dates)
            {
                if (date.ToString().Substring(3, 2) == startDate.Substring(3, 2) )
                {
                    specificDates.Add(date);

                    if (i != 30)
                    {
                        i++;                      
                    }                   
                }
            }
            return specificDates;
        }



        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime[] dates = GetDates(2019, tabControl.SelectedIndex + 1).ToArray();
            if (tabControl.SelectedIndex == 0) // januar
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 1) // Februar
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 2) // Marts
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 3) // April
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 4) // Maj
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 5) // Juni
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 6) // juli
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 7) // August
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 8) // September
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 9) // Oktober
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 10) // November
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }

            if (tabControl.SelectedIndex == 11) // December
            {
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateSchedule(dates, 0);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateSchedule(dates, 1);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateSchedule(dates, 2);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateSchedule(dates, 3);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateSchedule(dates, 4);
                    if (ViewRosterController.CheckIfDateExists(weekday1label.Content.ToString(), Shop.ToString()))
                    {
                        weekday1txtbox.Text = "Fuck yes";
                    }
                }
            }
        }












            
            




            private void UpdateSchedule(DateTime[] dates, int i)
        {
         
            weekday1label.Content = dates[0].Date.AddDays(i * 7).ToString();
            //if (RosterRepository.CheckIfExists(dates[0].Day.AddDays(i * 7)) == true)
            //{
            //    weekday1txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[0].Day.AddDays(i * 7)) == false)
            //{
            //    weekday1txtbox.Text = "Vagtplan Not found";
            //}

            weekday2label.Content = dates[1].Date.AddDays(i * 7).ToString();
       //     if (RosterRepository.CheckIfExists(dates[1].Day.AddDays(i * 7)) == true)
            //{
            //    weekday2txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[1].Day.AddDays(i * 7)) == false)
            //{
            //    weekday2txtbox.Text = "Vagtplan Not found";
            //}

            weekday3label.Content = dates[02].Date.AddDays(i * 7).ToString();
           // if (RosterRepository.CheckIfExists(dates[2].Day.AddDays(i * 7)) == true)
            //{
            //    weekday3txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[2].Day.AddDays(i * 7)) == false)
            //{
            //    weekday3txtbox.Text = "Vagtplan Not found";
            //}

            weekday4label.Content = dates[03].Date.AddDays(i * 7).ToString();
            //if (RosterRepository.CheckIfExists(dates[3].Day.AddDays(i * 7)) == true)
            //{
            //    weekday4txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[3].Day.AddDays(i * 7)) == false)
            //{
            //    weekday4txtbox.Text = "Vagtplan Not found";
            //}

            weekday5label.Content = dates[04].Date.AddDays(i * 7).ToString();
            //if (RosterRepository.CheckIfExists(dates[4].Day.AddDays(i * 7)) == true)
            //{
            //    weekday5txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[04].Day.AddDays(i * 7)) == false)
            //{
            //    weekday5txtbox.Text = "Vagtplan Not found";
            //}

            weekday6label.Content = dates[05].Date.AddDays(i * 7).ToString();
            //if (RosterRepository.CheckIfExists(dates[5].Day.AddDays(i * 7)) == true)
            //{
            //    weekday6txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[5].Day.AddDays(i * 7)) == false)
            //{
            //    weekday6txtbox.Text = "Vagtplan Not found";
            //}

            weekday7label.Content = dates[06].Date.AddDays(i * 7).ToString();
            //if (RosterRepository.CheckIfExists(dates[6].Day.AddDays(i * 7)) == true)
            //{
            //    weekday7txtbox.Text = "Vagtplan Found";
            //}
            //else if (RosterRepository.CheckIfExists(dates[06].Day.AddDays(i * 7)) == false)
            //{
            //    weekday7txtbox.Text = "Vagtplan Not found";
            //}
        }
    }
}

// weekday1label.Content = (rosters[1].StartDate.ToString()+ rosters[1].Shop);

//public partial class ShowRosterWindow : Window
//{
//    public ShowRosterWindow()
//    {
//        InitializeComponent();
//        int x = 0;
//        List<Roster> rosters = RosterRepository.GetRosters();
//        bool isDone = false;
//        while (!isDone)
//        {
//            if (rosters[1].StartDate.AddDays(x) == rosters[1].EndDate.AddDays(0))
//            {
//                isDone = true;
//            }
//            weekday1label.Content = rosters[1].StartDate.AddDays(x);
//            weekday2label.Content = rosters[1].StartDate.AddDays(1 + x);
//            weekday3label.Content = rosters[1].StartDate.AddDays(2 + x);
//            weekday4label.Content = rosters[1].StartDate.AddDays(3 + x);
//            weekday5label.Content = rosters[1].StartDate.AddDays(4 + x);
//            weekday6label.Content = rosters[1].StartDate.AddDays(5 + x);
//            weekday7label.Content = rosters[1].StartDate.AddDays(6 + x);
//            x = x + 7;
//        }
//    }
//}

//bool isDone = false;
//                    while (!isDone)
//                    {
//                        int x = 0;
//                        if (dates[0] <= dates[dates.Count - 1])
//                        {
//                            isDone = true;
//                        }
//                        weekday1txtbox.Text = "test0";
//                        weekday1label.Content = rosters[1].StartDate.AddDays(x);
//                        weekday2label.Content = rosters[1].StartDate.AddDays(1 + x);
//                        weekday3label.Content = rosters[1].StartDate.AddDays(2 + x);
//                        weekday4label.Content = rosters[1].StartDate.AddDays(3 + x);
//                        weekday5label.Content = rosters[1].StartDate.AddDays(4 + x);
//                        weekday6label.Content = rosters[1].StartDate.AddDays(5 + x);
//                        weekday7label.Content = rosters[1].StartDate.AddDays(6 + x);
//                        x = x + 7;
//                    }






//if (tabControl.SelectedIndex == 11) // December
//{
//    DateTime[] dates = GetDates(2019, 12).ToArray();
//    if (DecemberTabControl.SelectedIndex == 0)
//    {
//        bool dayFound = false;
//        int j = rosters.Count - 1;

//        while (j >= 0 && dayFound == false)
//        {
//            int l = 0;
//            while (l <= rosters[j].Length - 1 && dayFound == false)
//            {
//                string rosterDay = rosters[j].GetValue(l).ToString().Substring(0, 2);
//                string rosterMonth = rosters[j].GetValue(l).ToString().Substring(3, 2);
//                if (rosterMonth == "12" && rosterDay == "01" || rosterMonth == "12" && rosterDay == "02" || rosterMonth == "12" && rosterDay == "03" || rosterMonth == "12" && rosterDay == "04" || rosterMonth == "12" && rosterDay == "05" || rosterMonth == "12" && rosterDay == "06" || rosterMonth == "12" && rosterDay == "07")
//                {
//                    dates = GetSpecificDates(rosters[j], "01/12/2019");
//                    dayFound = true;
//                }
//                l++;
//            }
//            j--;
//        }
//        UpdateSchedule(dates, 0);
//    }
//    else if (DecemberTabControl.SelectedIndex == 1)
//    {
//        bool dayFound = false;
//        int j = rosters.Count - 1;

//        while (j >= 0 && dayFound == false)
//        {
//            int l = 0;
//            while (l <= rosters[j].Length - 1 && dayFound == false)
//            {
//                string rosterDay = rosters[j].GetValue(l).ToString().Substring(0, 2);
//                string rosterMonth = rosters[j].GetValue(l).ToString().Substring(3, 2);
//                if (rosterMonth == "12" && rosterDay == "08" || rosterMonth == "12" && rosterDay == "09" || rosterMonth == "12" && rosterDay == "10" || rosterMonth == "12" && rosterDay == "11" || rosterMonth == "12" && rosterDay == "12" || rosterMonth == "12" && rosterDay == "13" || rosterMonth == "12" && rosterDay == "14")
//                {

//                    dates = GetSpecificDates(rosters[j], "08/12/2019");

//                    dayFound = true;
//                }
//                l++;
//            }
//            j--;
//        }
//        UpdateSchedule(dates, 1);
//    }
//    else if (DecemberTabControl.SelectedIndex == 2)
//    {
//        bool dayFound = false;
//        int j = rosters.Count - 1;

//        while (j >= 0 && dayFound == false)
//        {
//            int l = 0;
//            while (l <= rosters[j].Length - 1 && dayFound == false)
//            {
//                string rosterDay = rosters[j].GetValue(l).ToString().Substring(0, 2);
//                string rosterMonth = rosters[j].GetValue(l).ToString().Substring(3, 2);
//                if (rosterMonth == "12" && rosterDay == "15" || rosterMonth == "12" && rosterDay == "16" || rosterMonth == "12" && rosterDay == "17" || rosterMonth == "12" && rosterDay == "18" || rosterMonth == "12" && rosterDay == "19" || rosterMonth == "12" && rosterDay == "20" || rosterMonth == "12" && rosterDay == "21")
//                {

//                    dates = GetSpecificDates(rosters[j], "15/12");

//                    dayFound = true;
//                }
//                l++;
//            }
//            j--;
//        }
//        UpdateSchedule(dates, 2);
//    }
//    else if (DecemberTabControl.SelectedIndex == 3)
//    {
//        bool dayFound = false;
//        int j = rosters.Count - 1;

//        while (j >= 0 && dayFound == false)
//        {
//            int l = 0;
//            while (l <= rosters[j].Length - 1 && dayFound == false)
//            {
//                string rosterDay = rosters[j].GetValue(l).ToString().Substring(0, 2);
//                string rosterMonth = rosters[j].GetValue(l).ToString().Substring(3, 2);
//                if (rosterMonth == "12" && rosterDay == "22" || rosterMonth == "12" && rosterDay == "23" || rosterMonth == "12" && rosterDay == "24" || rosterMonth == "12" && rosterDay == "25" || rosterMonth == "12" && rosterDay == "26" || rosterMonth == "1121" && rosterDay == "27" || rosterMonth == "12" && rosterDay == "28")
//                {

//                    dates = GetSpecificDates(rosters[j], "22/12");

//                    dayFound = true;
//                }
//                l++;
//            }
//            j--;
//        }
//        UpdateSchedule(dates, 3);
//    }
//    else if (DecemberTabControl.SelectedIndex == 4)
//    {
//        bool dayFound = false;
//        int j = rosters.Count - 1;

//        while (j >= 0 && dayFound == false)
//        {
//            int l = 0;
//            while (l <= rosters[j].Length - 1 && dayFound == false)
//            {
//                string rosterDay = rosters[j].GetValue(l).ToString().Substring(0, 2);
//                string rosterMonth = rosters[j].GetValue(l).ToString().Substring(3, 2);
//                if (rosterMonth == "12" && rosterDay == "29" || rosterMonth == "12" && rosterDay == "30" || rosterMonth == "12" && rosterDay == "31")
//                {
//                    DateTime newDay = new DateTime(2019, 01, 01);
//                    dates = GetSpecificDates(rosters[j], "29/12");

//                    dayFound = true;
//                }
//                l++;
//            }
//            j--;
//        }
//        UpdateSchedule'(dates, 4);
//    }