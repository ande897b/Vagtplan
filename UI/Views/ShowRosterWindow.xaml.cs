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
            if (tabControl.SelectedIndex == 5) // June
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "06")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (JuneTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 21);
                }
                else if (JuneTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 22);
                }
                else if (JuneTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 23);
                }
                else if (JuneTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 24);
                }
                else if (JuneTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 25);
                }
            }
            if (tabControl.SelectedIndex == 6) // July
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "07")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (JulyTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 26);
                }
                else if (JulyTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 27);
                }
                else if (JulyTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 28);
                }
                else if (JulyTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 29);
                }
                else if (JulyTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 30);
                }
            }
            if (tabControl.SelectedIndex == 7) // August
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "08")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (AugustTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 30);
                }
                else if (AugustTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 31);
                }
                else if (AugustTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 32);
                }
                else if (AugustTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 33);
                }
                else if (AugustTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 34);
                }
            }
            if (tabControl.SelectedIndex == 8) // September
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "09")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (SeptemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 34);
                }
                else if (SeptemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 35);
                }
                else if (SeptemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 36);
                }
                else if (SeptemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 37);
                }
                else if (SeptemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 38);
                }
            }
            if (tabControl.SelectedIndex == 9) // Kotober
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "10")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (OctoberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 39);
                }
                else if (OctoberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 40);
                }
                else if (OctoberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 41);
                }
                else if (OctoberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 42);
                }
                else if (OctoberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 43);
                }
            }
            if (tabControl.SelectedIndex == 10) // november
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "11")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (NovemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 43);
                }
                else if (NovemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 44);
                }
                else if (NovemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 45);
                }
                else if (NovemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 46);
                }
                else if (NovemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 47);
                }
            }
            if (tabControl.SelectedIndex == 11) // December
            {

                dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "12")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 01).ToArray();
                    }
                }
                if (DecemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 48);
                }
                else if (DecemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 49);
                }
                else if (DecemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 50);
                }
                else if (DecemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 51);
                }
                else if (DecemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 52);
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
           
            
                    weekday1label.Content = dates[0].AddDays(i*7).ToString();
            if (RosterRepository.CheckIfExists(dates[0].AddDays(i * 7)) == true)
            {
                weekday1txtbox.Text = "IT WORKS";
            }
            else
            {
                weekday1txtbox.Text = "IT DOESNT WORK";
            }
            weekday2txtbox.Text = "test1";
                    weekday2label.Content = dates[1].AddDays(i * 7).ToString();

                    weekday3txtbox.Text = "test2";
                    weekday3label.Content = dates[02].AddDays(i * 7).ToString();

            weekday4label.Content = dates[03].AddDays(i * 7).ToString();
            weekday4txtbox.Text = "test3";

                    weekday5label.Content = dates[04].AddDays(i * 7).ToString();
            weekday5txtbox.Text = "test4";

                    weekday6label.Content = dates[05].AddDays(i * 7).ToString();
            weekday6txtbox.Text = "test5";

                    weekday7label.Content = dates[06].AddDays(i * 7).ToString();
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