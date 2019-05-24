using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DutyExchange
    {
        public int DutyExchangeID { get; set; }
        public int DutyID { get; set; }
        public int EmployeeID { get; set; }

        public DutyExchange (int dutyExchangeID, int dutyID, int employeeID)
        {
            DutyExchangeID = dutyExchangeID;
            DutyID = dutyID;
            EmployeeID = employeeID;
        }
    }
}
