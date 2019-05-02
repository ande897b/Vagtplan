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
            if (RosterRepository.GetCountOfRosterMonths().ToString() == "0")
            {
                textBox.Text = DateTime.Today.ToString();
            }
            else
            {

            }
            textBox.Text = RosterRepository.GetCountOfRosterMonths().ToString();
            InitializeComponent();
        }


    }

}
