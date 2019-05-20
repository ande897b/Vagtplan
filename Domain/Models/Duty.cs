using System;

namespace Domain.Models
{
    public class Duty
    {
        public int EmployeeID { get; set; }
        public int DutyID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DateID { get; set; }
        public Duty (int employeeID, int dutyID, DateTime startTime, DateTime endTime, int dateID)
        {
            EmployeeID = employeeID;
            DutyID = dutyID;
            StartTime = startTime;
            EndTime = endTime;
            DateID = DateID; 
        }
    }
}