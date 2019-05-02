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
using Controller;

namespace Vagtplan
{
    /// <summary>
    /// Interaction logic for ShowRosterWindow.xaml
    /// </summary>
    public partial class ShowRosterWindow : Window
    {
        public ShowRosterWindow()
        {
            DateTime start = new DateTime(2000, 01, 01);
            DateTime end = new DateTime(2000, 01, 01);
            InitializeComponent();
            if (RosterRepository.GetCountOfRosterMonths().ToString() == "0")
            {
                textBox1.Text = start.ToString();
            }
            else
            {
                if (RosterRepository.GetCountOfRosterMonths()<12)
                {
                    end = new DateTime(2000, RosterRepository.GetCountOfRosterMonths(), 01);
                }
                textBox1.Text = end.ToString();
            }
            DateTime.UtcNow();
        }
    }
}
