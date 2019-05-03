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
            weekday1label.Content = dates[0].ToString();
            weekday2label.Content = dates[1].ToString();
            weekday3label.Content = dates[02].ToString();
            weekday4label.Content = dates[03].ToString();
            weekday5label.Content = dates[04].ToString();
            weekday6label.Content = dates[05].ToString();
            weekday7label.Content = dates[06].ToString();
            weekday8label.Content = dates[07].ToString();
            weekday9label.Content = dates[08].ToString();
            weekday10label.Content = dates[09].ToString();
            weekday11label.Content = dates[10].ToString();
            weekday12label.Content = dates[11].ToString();
            weekday13label.Content = dates[12].ToString();
            weekday14label.Content = dates[013].ToString();
            weekday15label.Content = dates[014].ToString();
            weekday16label.Content = dates[015].ToString();
            weekday17label.Content = dates[016].ToString();
            weekday18label.Content = dates[017].ToString();
            weekday19label.Content = dates[018].ToString();
            weekday20label.Content = dates[019].ToString();
            weekday21label.Content = dates[020].ToString();
            weekday22label.Content = dates[021].ToString();
            weekday23label.Content = dates[022].ToString();
            weekday24label.Content = dates[023].ToString();
            weekday25label.Content = dates[024].ToString();
            weekday26label.Content = dates[025].ToString();
            weekday27label.Content = dates[026].ToString();
            weekday28label.Content = dates[027].ToString();



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