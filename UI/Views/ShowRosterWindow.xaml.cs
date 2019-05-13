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
        List<DateTime[]> rosterArrays;
        public ShowRosterWindow()
        {
            InitializeComponent();
            List<Roster> rosters = RosterRepository.GetRosters();
            rosterArrays = new List<DateTime[]>();

            for (int i = 0; i < rosters.Count; i++)
            {
                DateTime start = rosters[i].StartDate;
                DateTime[] dates = new DateTime[360];

                for (int j = 0; start <= rosters[i].EndDate; j++)
                {
                    dates[j] = start;
                    start = start.AddDays(1);
                }
                rosterArrays.Add(dates);
            }
        }

       

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        private DateTime[] GetSpecificDates(DateTime[] dates, string startDate)
        {
            DateTime[] specificDates = new DateTime[31];
            int i = 0;
            foreach (var day in dates)
            {
                if (day.ToString().Substring(3, 2) == startDate.Substring(3, 2) )
                {
                    specificDates[i] = day.Date;

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

            if (tabControl.SelectedIndex == 0) // januar
            {
                DateTime[] dates = GetDates(2019, 01).ToArray();
                if (JanuaryTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "01" && rosterDay == "01" || rosterMonth == "01" && rosterDay == "02" || rosterMonth == "01" && rosterDay == "03" || rosterMonth == "01" && rosterDay == "04" || rosterMonth == "01" && rosterDay == "05" || rosterMonth == "01" && rosterDay == "06" || rosterMonth == "01" && rosterDay == "07")
                            {                         
                                dates = GetSpecificDates(rosterArrays[j], "01/01/2019");
                                
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (JanuaryTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "01" && rosterDay == "08" || rosterMonth == "01" && rosterDay == "09" || rosterMonth == "01" && rosterDay == "10" || rosterMonth == "01" && rosterDay == "11" || rosterMonth == "01" && rosterDay == "12" || rosterMonth == "01" && rosterDay == "13" || rosterMonth == "01" && rosterDay == "14")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "08/01/2019");
                                
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (JanuaryTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "01" && rosterDay == "15" || rosterMonth == "01" && rosterDay == "16" || rosterMonth == "01" && rosterDay == "17" || rosterMonth == "01" && rosterDay == "18" || rosterMonth == "01" && rosterDay == "19" || rosterMonth == "01" && rosterDay == "20" || rosterMonth == "01" && rosterDay == "21")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "15/01");
                           
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (JanuaryTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "01" && rosterDay == "22" || rosterMonth == "01" && rosterDay == "23" || rosterMonth == "01" && rosterDay == "24" || rosterMonth == "01" && rosterDay == "25" || rosterMonth == "01" && rosterDay == "26" || rosterMonth == "01" && rosterDay == "27" || rosterMonth == "01" && rosterDay == "28")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "22/01");
                                
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (JanuaryTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "01" && rosterDay == "29" || rosterMonth == "01" && rosterDay == "30" || rosterMonth == "01" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/01");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 1) // Februar
            {
                
                DateTime[] dates = GetDates(2019, 02).ToArray();
                if (FebruaryTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "02" && rosterDay == "01" || rosterMonth == "02" && rosterDay == "02" || rosterMonth == "02" && rosterDay == "03" || rosterMonth == "02" && rosterDay == "04" || rosterMonth == "02" && rosterDay == "05" || rosterMonth == "02" && rosterDay == "06" || rosterMonth == "02" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/02/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (FebruaryTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "02" && rosterDay == "08" || rosterMonth == "02" && rosterDay == "09" || rosterMonth == "02" && rosterDay == "10" || rosterMonth == "02" && rosterDay == "11" || rosterMonth == "02" && rosterDay == "12" || rosterMonth == "02" && rosterDay == "13" || rosterMonth == "02" && rosterDay == "14")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "08/02/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (FebruaryTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "02" && rosterDay == "15" || rosterMonth == "02" && rosterDay == "16" || rosterMonth == "02" && rosterDay == "17" || rosterMonth == "02" && rosterDay == "18" || rosterMonth == "02" && rosterDay == "19" || rosterMonth == "02" && rosterDay == "20" || rosterMonth == "02" && rosterDay == "21")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "15/02");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (FebruaryTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "02" && rosterDay == "22" || rosterMonth == "02" && rosterDay == "23" || rosterMonth == "02" && rosterDay == "24" || rosterMonth == "02" && rosterDay == "25" || rosterMonth == "02" && rosterDay == "26" || rosterMonth == "02" && rosterDay == "27" || rosterMonth == "02" && rosterDay == "28")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "22/02");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }

            }

            if (tabControl.SelectedIndex == 2) // March
            {
                DateTime[] dates = GetDates(2019, 03).ToArray();
                if (MarchTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "03" && rosterDay == "01" || rosterMonth == "03" && rosterDay == "02" || rosterMonth == "03" && rosterDay == "03" || rosterMonth == "03" && rosterDay == "04" || rosterMonth == "03" && rosterDay == "05" || rosterMonth == "03" && rosterDay == "06" || rosterMonth == "03" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/03/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (MarchTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "03" && rosterDay == "08" || rosterMonth == "03" && rosterDay == "09" || rosterMonth == "03" && rosterDay == "10" || rosterMonth == "03" && rosterDay == "11" || rosterMonth == "03" && rosterDay == "12" || rosterMonth == "03" && rosterDay == "13" || rosterMonth == "03" && rosterDay == "14")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "08/03/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (MarchTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "03" && rosterDay == "15" || rosterMonth == "03" && rosterDay == "16" || rosterMonth == "03" && rosterDay == "17" || rosterMonth == "03" && rosterDay == "18" || rosterMonth == "03" && rosterDay == "19" || rosterMonth == "03" && rosterDay == "20" || rosterMonth == "03" && rosterDay == "21")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "15/03");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (MarchTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "03" && rosterDay == "22" || rosterMonth == "03" && rosterDay == "23" || rosterMonth == "03" && rosterDay == "24" || rosterMonth == "03" && rosterDay == "25" || rosterMonth == "03" && rosterDay == "26" || rosterMonth == "03" && rosterDay == "27" || rosterMonth == "03" && rosterDay == "28")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "22/03");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (MarchTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "03" && rosterDay == "29" || rosterMonth == "03" && rosterDay == "30" || rosterMonth == "03" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/03");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 3) // April
            {
                DateTime[] dates = GetDates(2019, 04).ToArray();
                if (AprilTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "04" && rosterDay == "01" || rosterMonth == "04" && rosterDay == "02" || rosterMonth == "04" && rosterDay == "03" || rosterMonth == "04" && rosterDay == "04" || rosterMonth == "04" && rosterDay == "05" || rosterMonth == "04" && rosterDay == "06" || rosterMonth == "04" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/04/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (AprilTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "04" && rosterDay == "08" || rosterMonth == "04" && rosterDay == "09" || rosterMonth == "04" && rosterDay == "10" || rosterMonth == "04" && rosterDay == "11" || rosterMonth == "04" && rosterDay == "12" || rosterMonth == "04" && rosterDay == "13" || rosterMonth == "04" && rosterDay == "14")
                            {
                               
                                dates = GetSpecificDates(rosterArrays[j], "08/04/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (AprilTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "04" && rosterDay == "15" || rosterMonth == "04" && rosterDay == "16" || rosterMonth == "04" && rosterDay == "17" || rosterMonth == "04" && rosterDay == "18" || rosterMonth == "04" && rosterDay == "19" || rosterMonth == "04" && rosterDay == "20" || rosterMonth == "04" && rosterDay == "21")
                            {
                                
                                dates = GetSpecificDates(rosterArrays[j], "15/04");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (AprilTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "04" && rosterDay == "22" || rosterMonth == "04" && rosterDay == "23" || rosterMonth == "04" && rosterDay == "24" || rosterMonth == "04" && rosterDay == "25" || rosterMonth == "04" && rosterDay == "26" || rosterMonth == "04" && rosterDay == "27" || rosterMonth == "04" && rosterDay == "28")
                            {
                              
                                dates = GetSpecificDates(rosterArrays[j], "22/04");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (AprilTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "04" && rosterDay == "29" || rosterMonth == "04" && rosterDay == "30" || rosterMonth == "04" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/04");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 4) // May
            {
               DateTime[] dates = GetDates(2019, 05).ToArray();
                if (MayTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "05" && rosterDay == "01" || rosterMonth == "05" && rosterDay == "02" || rosterMonth == "05" && rosterDay == "03" || rosterMonth == "05" && rosterDay == "04" || rosterMonth == "05" && rosterDay == "05" || rosterMonth == "05" && rosterDay == "06" || rosterMonth == "05" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/05/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates,0);
                }
                else if (MayTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;
                    string rosterDay = "";
                 

                    while (j >= 0 && dayFound == false)
                    {
                        
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "05" && rosterDay == "08" || rosterMonth == "05" && rosterDay == "09" || rosterMonth == "05" && rosterDay == "10" || rosterMonth == "05" && rosterDay == "11" || rosterMonth == "05" && rosterDay == "12" || rosterMonth == "05" && rosterDay == "13" || rosterMonth == "05" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/05/2019");
                                
                                dayFound = true;
                            }
                            l++;

                        }
                        j--;
                    }
                    if (dayFound == true)
                    {
                        UpdateSchedule(dates, 0);
                    }
                    else
                    {
                        UpdateSchedule(dates, 1);
                    }
                   
                }
                else if (MayTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "05" && rosterDay == "15" || rosterMonth == "05" && rosterDay == "16" || rosterMonth == "05" && rosterDay == "17" || rosterMonth == "05" && rosterDay == "18" || rosterMonth == "05" && rosterDay == "19" || rosterMonth == "05" && rosterDay == "20" || rosterMonth == "05" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/05");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (MayTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "05" && rosterDay == "22" || rosterMonth == "05" && rosterDay == "23" || rosterMonth == "05" && rosterDay == "24" || rosterMonth == "05" && rosterDay == "25" || rosterMonth == "05" && rosterDay == "26" || rosterMonth == "05" && rosterDay == "27" || rosterMonth == "05" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/05");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (MayTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "05" && rosterDay == "29" || rosterMonth == "05" && rosterDay == "30" || rosterMonth == "05" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/05");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 5) // June
            {
                DateTime[] dates = GetDates(2019, 06).ToArray();
                if (JuneTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "06" && rosterDay == "01" || rosterMonth == "06" && rosterDay == "02" || rosterMonth == "06" && rosterDay == "03" || rosterMonth == "06" && rosterDay == "04" || rosterMonth == "06" && rosterDay == "05" || rosterMonth == "06" && rosterDay == "06" || rosterMonth == "06" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/06/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (JuneTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "06" && rosterDay == "08" || rosterMonth == "06" && rosterDay == "09" || rosterMonth == "06" && rosterDay == "10" || rosterMonth == "06" && rosterDay == "11" || rosterMonth == "06" && rosterDay == "12" || rosterMonth == "06" && rosterDay == "13" || rosterMonth == "06" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/06/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (JuneTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "06" && rosterDay == "15" || rosterMonth == "06" && rosterDay == "16" || rosterMonth == "06" && rosterDay == "17" || rosterMonth == "06" && rosterDay == "18" || rosterMonth == "06" && rosterDay == "19" || rosterMonth == "06" && rosterDay == "20" || rosterMonth == "06" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/06");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (JuneTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "06" && rosterDay == "22" || rosterMonth == "06" && rosterDay == "23" || rosterMonth == "06" && rosterDay == "24" || rosterMonth == "06" && rosterDay == "25" || rosterMonth == "06" && rosterDay == "26" || rosterMonth == "06" && rosterDay == "27" || rosterMonth == "06" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/06");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (JuneTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "06" && rosterDay == "29" || rosterMonth == "06" && rosterDay == "30" || rosterMonth == "06" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/06");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 6) // July
            {
                DateTime[] dates = GetDates(2019, 07).ToArray();
                if (JulyTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "07" && rosterDay == "01" || rosterMonth == "07" && rosterDay == "02" || rosterMonth == "07" && rosterDay == "03" || rosterMonth == "07" && rosterDay == "04" || rosterMonth == "07" && rosterDay == "05" || rosterMonth == "07" && rosterDay == "06" || rosterMonth == "07" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/07/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (JulyTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "07" && rosterDay == "08" || rosterMonth == "07" && rosterDay == "09" || rosterMonth == "07" && rosterDay == "10" || rosterMonth == "07" && rosterDay == "11" || rosterMonth == "07" && rosterDay == "12" || rosterMonth == "07" && rosterDay == "13" || rosterMonth == "07" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/07/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (JulyTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "07" && rosterDay == "15" || rosterMonth == "07" && rosterDay == "16" || rosterMonth == "07" && rosterDay == "17" || rosterMonth == "07" && rosterDay == "18" || rosterMonth == "07" && rosterDay == "19" || rosterMonth == "07" && rosterDay == "20" || rosterMonth == "07" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/07");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (JulyTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "07" && rosterDay == "22" || rosterMonth == "07" && rosterDay == "23" || rosterMonth == "07" && rosterDay == "24" || rosterMonth == "07" && rosterDay == "25" || rosterMonth == "07" && rosterDay == "26" || rosterMonth == "07" && rosterDay == "27" || rosterMonth == "07" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/07");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (JulyTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "07" && rosterDay == "29" || rosterMonth == "07" && rosterDay == "30" || rosterMonth == "07" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/07");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 7) // August
            {
                DateTime[] dates = GetDates(2019, 08).ToArray();
                if (AugustTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "08" && rosterDay == "01" || rosterMonth == "08" && rosterDay == "02" || rosterMonth == "08" && rosterDay == "03" || rosterMonth == "08" && rosterDay == "04" || rosterMonth == "08" && rosterDay == "05" || rosterMonth == "08" && rosterDay == "06" || rosterMonth == "08" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/08/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (AugustTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "08" && rosterDay == "08" || rosterMonth == "08" && rosterDay == "09" || rosterMonth == "08" && rosterDay == "10" || rosterMonth == "08" && rosterDay == "11" || rosterMonth == "08" && rosterDay == "12" || rosterMonth == "08" && rosterDay == "13" || rosterMonth == "08" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/08/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (AugustTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "08" && rosterDay == "15" || rosterMonth == "08" && rosterDay == "16" || rosterMonth == "08" && rosterDay == "17" || rosterMonth == "08" && rosterDay == "18" || rosterMonth == "08" && rosterDay == "19" || rosterMonth == "08" && rosterDay == "20" || rosterMonth == "08" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/08");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (AugustTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "08" && rosterDay == "22" || rosterMonth == "08" && rosterDay == "23" || rosterMonth == "08" && rosterDay == "24" || rosterMonth == "08" && rosterDay == "25" || rosterMonth == "08" && rosterDay == "26" || rosterMonth == "08" && rosterDay == "27" || rosterMonth == "08" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/08");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (AugustTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "08" && rosterDay == "29" || rosterMonth == "08" && rosterDay == "30" || rosterMonth == "08" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/08");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 8) // September
            {
                DateTime[] dates = GetDates(2019, 09).ToArray();
                if (SeptemberTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "09" && rosterDay == "01" || rosterMonth == "09" && rosterDay == "02" || rosterMonth == "09" && rosterDay == "03" || rosterMonth == "09" && rosterDay == "04" || rosterMonth == "09" && rosterDay == "05" || rosterMonth == "09" && rosterDay == "06" || rosterMonth == "09" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/09/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (SeptemberTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "09" && rosterDay == "08" || rosterMonth == "09" && rosterDay == "09" || rosterMonth == "09" && rosterDay == "10" || rosterMonth == "09" && rosterDay == "11" || rosterMonth == "09" && rosterDay == "12" || rosterMonth == "09" && rosterDay == "13" || rosterMonth == "09" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/09/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (SeptemberTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "09" && rosterDay == "15" || rosterMonth == "09" && rosterDay == "16" || rosterMonth == "09" && rosterDay == "17" || rosterMonth == "09" && rosterDay == "18" || rosterMonth == "09" && rosterDay == "19" || rosterMonth == "09" && rosterDay == "20" || rosterMonth == "09" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/09");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (SeptemberTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "09" && rosterDay == "22" || rosterMonth == "09" && rosterDay == "23" || rosterMonth == "09" && rosterDay == "24" || rosterMonth == "09" && rosterDay == "25" || rosterMonth == "09" && rosterDay == "26" || rosterMonth == "09" && rosterDay == "27" || rosterMonth == "09" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/09");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (SeptemberTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "09" && rosterDay == "29" || rosterMonth == "09" && rosterDay == "30" || rosterMonth == "09" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/09");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 9) // Oktober
            {

                DateTime[] dates = GetDates(2019, 10).ToArray();
                if (OctoberTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "10" && rosterDay == "01" || rosterMonth == "10" && rosterDay == "02" || rosterMonth == "10" && rosterDay == "03" || rosterMonth == "10" && rosterDay == "04" || rosterMonth == "10" && rosterDay == "05" || rosterMonth == "10" && rosterDay == "06" || rosterMonth == "10" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/10/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (OctoberTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "10" && rosterDay == "08" || rosterMonth == "10" && rosterDay == "09" || rosterMonth == "10" && rosterDay == "10" || rosterMonth == "10" && rosterDay == "11" || rosterMonth == "10" && rosterDay == "12" || rosterMonth == "10" && rosterDay == "13" || rosterMonth == "10" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/10/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (OctoberTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "10" && rosterDay == "15" || rosterMonth == "10" && rosterDay == "16" || rosterMonth == "10" && rosterDay == "17" || rosterMonth == "10" && rosterDay == "18" || rosterMonth == "10" && rosterDay == "19" || rosterMonth == "10" && rosterDay == "20" || rosterMonth == "10" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/10");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (OctoberTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "10" && rosterDay == "22" || rosterMonth == "10" && rosterDay == "23" || rosterMonth == "10" && rosterDay == "24" || rosterMonth == "10" && rosterDay == "25" || rosterMonth == "10" && rosterDay == "26" || rosterMonth == "10" && rosterDay == "27" || rosterMonth == "10" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/10");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (OctoberTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "10" && rosterDay == "29" || rosterMonth == "10" && rosterDay == "30" || rosterMonth == "10" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/10");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 10) // November
            {
                DateTime[] dates = GetDates(2019, 11).ToArray();
                if (NovemberTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "11" && rosterDay == "01" || rosterMonth == "11" && rosterDay == "02" || rosterMonth == "11" && rosterDay == "03" || rosterMonth == "11" && rosterDay == "04" || rosterMonth == "11" && rosterDay == "05" || rosterMonth == "11" && rosterDay == "06" || rosterMonth == "11" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/11/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (NovemberTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "11" && rosterDay == "08" || rosterMonth == "11" && rosterDay == "09" || rosterMonth == "11" && rosterDay == "10" || rosterMonth == "11" && rosterDay == "11" || rosterMonth == "11" && rosterDay == "12" || rosterMonth == "11" && rosterDay == "13" || rosterMonth == "11" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/11/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (NovemberTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "11" && rosterDay == "15" || rosterMonth == "11" && rosterDay == "16" || rosterMonth == "11" && rosterDay == "17" || rosterMonth == "11" && rosterDay == "18" || rosterMonth == "11" && rosterDay == "19" || rosterMonth == "11" && rosterDay == "20" || rosterMonth == "11" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/11");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (NovemberTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "11" && rosterDay == "22" || rosterMonth == "11" && rosterDay == "23" || rosterMonth == "11" && rosterDay == "24" || rosterMonth == "11" && rosterDay == "25" || rosterMonth == "11" && rosterDay == "26" || rosterMonth == "11" && rosterDay == "27" || rosterMonth == "11" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/11");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (NovemberTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "11" && rosterDay == "29" || rosterMonth == "11" && rosterDay == "30" || rosterMonth == "11" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/11");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }

            if (tabControl.SelectedIndex == 11) // December
            {
                DateTime[] dates = GetDates(2019, 12).ToArray();
                if (DecemberTabControl.SelectedIndex == 0)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "12" && rosterDay == "01" || rosterMonth == "12" && rosterDay == "02" || rosterMonth == "12" && rosterDay == "03" || rosterMonth == "12" && rosterDay == "04" || rosterMonth == "12" && rosterDay == "05" || rosterMonth == "12" && rosterDay == "06" || rosterMonth == "12" && rosterDay == "07")
                            {
                                dates = GetSpecificDates(rosterArrays[j], "01/12/2019");
                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 0);
                }
                else if (DecemberTabControl.SelectedIndex == 1)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "12" && rosterDay == "08" || rosterMonth == "12" && rosterDay == "09" || rosterMonth == "12" && rosterDay == "10" || rosterMonth == "12" && rosterDay == "11" || rosterMonth == "12" && rosterDay == "12" || rosterMonth == "12" && rosterDay == "13" || rosterMonth == "12" && rosterDay == "14")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "08/12/2019");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 1);
                }
                else if (DecemberTabControl.SelectedIndex == 2)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "12" && rosterDay == "15" || rosterMonth == "12" && rosterDay == "16" || rosterMonth == "12" && rosterDay == "17" || rosterMonth == "12" && rosterDay == "18" || rosterMonth == "12" && rosterDay == "19" || rosterMonth == "12" && rosterDay == "20" || rosterMonth == "12" && rosterDay == "21")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "15/12");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 2);
                }
                else if (DecemberTabControl.SelectedIndex == 3)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "12" && rosterDay == "22" || rosterMonth == "12" && rosterDay == "23" || rosterMonth == "12" && rosterDay == "24" || rosterMonth == "12" && rosterDay == "25" || rosterMonth == "12" && rosterDay == "26" || rosterMonth == "1121" && rosterDay == "27" || rosterMonth == "12" && rosterDay == "28")
                            {

                                dates = GetSpecificDates(rosterArrays[j], "22/12");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 3);
                }
                else if (DecemberTabControl.SelectedIndex == 4)
                {
                    bool dayFound = false;
                    int j = rosterArrays.Count - 1;

                    while (j >= 0 && dayFound == false)
                    {
                        int l = 0;
                        while (l <= rosterArrays[j].Length - 1 && dayFound == false)
                        {
                            string rosterDay = rosterArrays[j].GetValue(l).ToString().Substring(0, 2);
                            string rosterMonth = rosterArrays[j].GetValue(l).ToString().Substring(3, 2);
                            if (rosterMonth == "12" && rosterDay == "29" || rosterMonth == "12" && rosterDay == "30" || rosterMonth == "12" && rosterDay == "31")
                            {
                                DateTime newDay = new DateTime(2019, 01, 01);
                                dates = GetSpecificDates(rosterArrays[j], "29/12");

                                dayFound = true;
                            }
                            l++;
                        }
                        j--;
                    }
                    UpdateSchedule(dates, 4);
                }
            }
        }



        private void UpdateSchedule(DateTime[] dates, int i)
        {
            weekday1label.Content = dates[0].AddDays(i * 7).ToString();
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
            else if (RosterRepository.CheckIfExists(dates[1].AddDays(i * 7)) == false)
            {
                weekday2txtbox.Text = "Vagtplan Not found";
            }

            weekday3label.Content = dates[02].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[2].AddDays(i * 7)) == true)
            {
                weekday3txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[2].AddDays(i * 7)) == false)
            {
                weekday3txtbox.Text = "Vagtplan Not found";
            }

            weekday4label.Content = dates[03].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[3].AddDays(i * 7)) == true)
            {
                weekday4txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[3].AddDays(i * 7)) == false)
            {
                weekday4txtbox.Text = "Vagtplan Not found";
            }

            weekday5label.Content = dates[04].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[4].AddDays(i * 7)) == true)
            {
                weekday5txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[04].AddDays(i * 7)) == false)
            {
                weekday5txtbox.Text = "Vagtplan Not found";
            }

            weekday6label.Content = dates[05].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[5].AddDays(i * 7)) == true)
            {
                weekday6txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[5].AddDays(i * 7)) == false)
            {
                weekday6txtbox.Text = "Vagtplan Not found";
            }

            weekday7label.Content = dates[06].AddDays(i * 7).ToString();
            if (RosterRepository.CheckIfExists(dates[6].AddDays(i * 7)) == true)
            {
                weekday7txtbox.Text = "Vagtplan Found";
            }
            else if (RosterRepository.CheckIfExists(dates[06].AddDays(i * 7)) == false)
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