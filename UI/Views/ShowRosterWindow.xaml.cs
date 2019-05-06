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

namespace UI.Views
{
    public partial class ShowRosterWindow : Window
    {
        List<DateTime []> monthList;
        public ShowRosterWindow()
        {
            InitializeComponent();
            List<Roster> rosters = RosterRepository.GetRosters(); 

         //   tabControl.SelectedIndex = DateTime.Now.Month - 1;

            monthList = new List<DateTime[]>();

            for (int i = 0; i < rosters.Count; i++)
            {
                DateTime start = rosters[i].StartDate;
                DateTime[] dates = new DateTime[360];

                for (int j = 0; start <= rosters[i].EndDate; j++)
                {
                    dates[j] = start;
                    start = start.AddDays(1);
                }
                monthList.Add(dates);
            }
        }
       

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int i = 0;
            DateTime[] dates = null;
           
          // januar
            if (tabControl.SelectedIndex == 0)
            {
                foreach (var date in monthList)
                {
                    if (date.ToString().Substring(3,2)=="01")
                    {
                        dates = date;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();                      
                    }
                }    
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }
            if (tabControl.SelectedIndex == 1) // Februar
            {
                dates = null;
                foreach (var date in monthList)
                {
                    if (date.ToString().Substring(3, 2) == "02")
                    {
                        dates = date;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (FebruaryTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 4);
                }
                else if (FebruaryTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 5);
                }
                else if (FebruaryTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 6);
                }
                else if (FebruaryTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 7);
                }
                else if (FebruaryTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 8);
                }
            }
            if (tabControl.SelectedIndex == 2) // March
            {
                dates = null;
                foreach (var date in monthList)
                {
                    if (date.ToString().Substring(3, 2) == "03")
                    {
                        dates = date;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (MarchTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 8);
                }
                else if (MarchTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 9);
                }
                else if (MarchTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 10);
                }
                else if (MarchTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 11);
                }
                else if (MarchTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 12);
                }
            }
            if (tabControl.SelectedIndex == 3) // April
            {
                dates = null;
                foreach (var date in monthList)
                {
                    if (date.ToString().Substring(3, 2) == "04")
                    {
                        dates = date;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (AprilTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 13);
                }
                else if (AprilTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 14);
                }
                else if (AprilTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 15);
                }
                else if (AprilTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 16);
                }
                else if (AprilTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 17);
                }
            }
            if (tabControl.SelectedIndex == 4) // May
            {
          
                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "05")
                    {
                        weekday1txtbox.Text = "sucess";
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (MayTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 17);
                }
                else if (MayTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 18);
                }
                else if (MayTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 19);
                }
                else if (MayTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 20);
                }
                else if (MayTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 21);
                }
            }



        }
        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
        private void UpdateWeedDays420(DateTime [] dates , int i)
        {
            int j = 0;

            if (i == 0)
                j = 0;
            else if (i == 1)
                j = 7;
            else if (i == 2)
                j = 14;
            else if (i == 3)
                j = 21;
            else if (i == 4)
                j = 28;
            else if (i == 5)
                j = 35;
            else if (i == 6)
                j = 42;
            else if (i == 7)
                j = 49;
            else if (i == 8)
                j = 56;
            else if (i == 9)
                j = 63;
            else if (i == 10)
                j = 70;
            else if (i == 11)
                j = 77;
            else if (i == 12)
                j = 84;
            else if (i == 13)
                j = 91;
            else if (i == 14)
                j = 98;
            else if (i == 15)
                j = 105;
            else if (i == 16)
                j = 112;
            else if (i == 17)
                j = 119;
            else if (i == 18)
                j = 126;
            else if (i == 19)
                j = 133;
            else if (i == 20)
                j = 140;
            else if (i == 21)
                j = 147;
            else if (i == 22)
                j = 154;
            else if (i == 23)
                j = 161;
            else if (i == 24)
                j = 168;
            else if (i == 25)
                j = 175;
            else if (i == 26)
                j = 182;
            else if (i == 27)
                j = 189;
            else if (i == 28)
                j = 196;
            else if (i == 29)
                j = 203;
            else if (i == 30)
                j = 210;





            weekday1txtbox.Text = "test0";
                    weekday1label.Content = dates[0].AddDays(j).ToString();

                    weekday2txtbox.Text = "test1";
                    weekday2label.Content = dates[1].AddDays(j).ToString();

                    weekday3txtbox.Text = "test2";
                    weekday3label.Content = dates[02].AddDays(j).ToString();

            weekday4label.Content = dates[03].AddDays(j).ToString();
            weekday4txtbox.Text = "test3";

                    weekday5label.Content = dates[04].AddDays(j).ToString();
            weekday5txtbox.Text = "test4";

                    weekday6label.Content = dates[05].AddDays(j).ToString();
            weekday6txtbox.Text = "test5";

                    weekday7label.Content = dates[06].AddDays(j).ToString();
            weekday7txtbox.Text = "test6";
                
            

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