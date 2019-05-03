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
        public ShowRosterWindow()
        {
            InitializeComponent();
            int x = 0;
            List<Roster> rosters = RosterRepository.GetRosters();
            //bool isDone = false;
            //while (!isDone)
            //{
            //    if(rosters[1].StartDate.AddDays(x) == rosters[1].EndDate.AddDays(0))
            //    {
            //        isDone = true;
            //    }
            //    weekday1label.Content = rosters[1].StartDate.AddDays(x);
            //    weekday2label.Content = rosters[1].StartDate.AddDays(1 + x);
            //    weekday3label.Content = rosters[1].StartDate.AddDays(2 + x);
            //    weekday4label.Content = rosters[1].StartDate.AddDays(3 + x);
            //    weekday5label.Content = rosters[1].StartDate.AddDays(4 + x);
            //    weekday6label.Content = rosters[1].StartDate.AddDays(5 + x);
            //    weekday7label.Content = rosters[1].StartDate.AddDays(6 + x);
            //    x = x + 7;
            var dates = new List<DateTime>();
            for (var start = rosters[0].StartDate; start <= rosters[0].EndDate; start = start.AddDays(1))
            {
                dates.Add(start);
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