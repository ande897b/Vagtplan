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
            
            if (tabControl.SelectedIndex == 0) // januar
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3,2)=="01")
                    {
                        dates = date;
                        i++;
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
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "02")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 02).ToArray();
                    }
                }
                if (FebruaryTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (FebruaryTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (FebruaryTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (FebruaryTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
               
            }

            if (tabControl.SelectedIndex == 2) // March
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "03")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 03).ToArray();
                    }
                }
                if (MarchTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (MarchTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (MarchTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (MarchTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (MarchTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 3) // April
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "04")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 04).ToArray();
                    }
                }
                if (AprilTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (AprilTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (AprilTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (AprilTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (AprilTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 4) // May
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "05")
                    {                       
                        dates = date;
                        i++;
                    }
                    else 
                    {
                        
                        dates = GetDates(2019, 05).ToArray();
                    }
                }
                if (MayTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (MayTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (MayTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (MayTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (MayTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 5) // June
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "06")
                    {
                        dates = date;
                        i++;
                    }
                    else 
                    {

                        dates = GetDates(2019, 06).ToArray();
                    }
                }
                if (JuneTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (JuneTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (JuneTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (JuneTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (JuneTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 6) // July
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    
                    if (date.GetValue(i).ToString().Substring(3, 2) == "07" )
                    {
                        dates = date;
                        i++;
                    }
                   else
                    {
                       
                        dates = GetDates(2019, 07).ToArray();
                    }
                }
                if (JulyTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (JulyTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (JulyTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (JulyTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (JulyTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 7) // August
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "08")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 08).ToArray();
                    }
                }
                if (AugustTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (AugustTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (AugustTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (AugustTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (AugustTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }
      
            if (tabControl.SelectedIndex == 8) // September
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "09")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 09).ToArray();
                    }
                }
                if (SeptemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (SeptemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (SeptemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (SeptemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (SeptemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 9) // Kotober
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "10")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 10).ToArray();
                    }
                }
                if (OctoberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (OctoberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (OctoberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (OctoberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (OctoberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 10) // november
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "11")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 11).ToArray();
                    }
                }
                if (NovemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (NovemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (NovemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (NovemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (NovemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 11) // December
            {
                int i = 0;
                DateTime[] dates = null;
                foreach (var date in monthList)
                {
                    if (date.GetValue(i).ToString().Substring(3, 2) == "12")
                    {
                        dates = date;
                        i++;
                    }
                    else
                    {
                        dates = GetDates(2019, 12).ToArray();
                    }
                }
                if (DecemberTabControl.SelectedIndex == 0)
                {
                    UpdateWeedDays420(dates, 0);
                }
                else if (DecemberTabControl.SelectedIndex == 1)
                {
                    UpdateWeedDays420(dates, 1);
                }
                else if (DecemberTabControl.SelectedIndex == 2)
                {
                    UpdateWeedDays420(dates, 2);
                }
                else if (DecemberTabControl.SelectedIndex == 3)
                {
                    UpdateWeedDays420(dates, 3);
                }
                else if (DecemberTabControl.SelectedIndex == 4)
                {
                    UpdateWeedDays420(dates, 4);
                }
            }
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            List<DateTime> test1;
           
             test1 = Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
            return test1;
               
        }

        private void UpdateWeedDays420(DateTime [] dates , int i)
        {
            weekday1label.Content = dates[0].AddDays(i*7).ToString();
            if (RosterRepository.CheckIfExists(dates[0].AddDays(i * 7)) == true)
            {
                weekday1txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[0].AddDays(i * 7)) == false)
            {
                weekday1txtbox.Text = "Vagtplan Not found";
            }
           
            weekday2label.Content = dates[1].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[1].AddDays(i * 7)) == true)
            {
                weekday2txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[1].AddDays(i * 7)) == false)
            {
                weekday2txtbox.Text = "Vagtplan Not found";
            }        
            
            weekday3label.Content = dates[02].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[2].AddDays(i * 7)) == true)
            {
                weekday3txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[2].AddDays(i * 7)) == false)
            {
                weekday3txtbox.Text = "Vagtplan Not found";
            }

            weekday4label.Content = dates[03].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[3].AddDays(i * 7)) == true)
            {
                weekday4txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[3].AddDays(i * 7)) == false)
            {
                weekday4txtbox.Text = "Vagtplan Not found";
            }

            weekday5label.Content = dates[04].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[4].AddDays(i * 7)) == true)
            {
                weekday5txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[04].AddDays(i * 7)) == false)
            {
                weekday5txtbox.Text = "Vagtplan Not found";
            }

            weekday6label.Content = dates[05].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[5].AddDays(i * 7)) == true)
            {
                weekday6txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[5].AddDays(i * 7)) == false)
            {
                weekday6txtbox.Text = "Vagtplan Not found";
            }

            weekday7label.Content = dates[06].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[6].AddDays(i * 7)) == true)
            {
                weekday7txtbox.Text = "Vagtplan Found";
            }
            else if(RosterRepository.CheckIfExists(dates[06].AddDays(i * 7)) == false)
            {
                weekday7txtbox.Text = "Vagtplan Not found";
            }
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