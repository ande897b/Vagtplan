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
            int i = 1;
            int x = 0;
            List<Roster> rosters =  RosterRepository.GetRosters();
            // weekday1label.Content = (rosters[1].StartDate.ToString()+ rosters[1].Shop);
            while (rosters[i].StartDate.AddDays(1) != rosters[i].EndDate)
            {
                weekday1label.Content = rosters[i].StartDate.AddDays(0+x);
                weekday2label.Content = rosters[i].StartDate.AddDays(1 + x);
                weekday3label.Content = rosters[i].StartDate.AddDays(2 + x);
                weekday4label.Content = rosters[i].StartDate.AddDays(3 + x);
                weekday5label.Content = rosters[i].StartDate.AddDays(4 + x);
                weekday6label.Content = rosters[i].StartDate.AddDays(5 + x);
                weekday7label.Content = rosters[i].StartDate.AddDays(6 + x);
                x = x + 7;


            }
        }
    }
}
