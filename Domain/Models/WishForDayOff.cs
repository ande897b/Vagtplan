using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class WishForDayOff
    {
        public int WishForDayOffID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }

        public WishForDayOff(int employeeID, DateTime date)
        {
            WishForDayOffID = -1;
            EmployeeID = employeeID;
            Date = date;
        }
        public WishForDayOff(int wishForDayOffID, int employeeID, DateTime date)
        {
            WishForDayOffID = wishForDayOffID;
            EmployeeID = employeeID;
            Date = date;
        }
    }
}
