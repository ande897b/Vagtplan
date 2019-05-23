using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Repositories
{
    public static class DutyRepository
    {
        private static List<Duty> duties = new List<Duty>();
        public static void AddDuty(Duty duty)
        {
            if (!DutyExist(duty))
            {
                duties.Add(duty);
            }
        }
        public static List<Duty> GetDuties()
        {
            return duties;
        }
        public static List<Duty> GetDuties(int dateID)
        {
            List<Duty> newDuties = new List<Duty>();
            foreach(Duty duty in duties)
            {
                if(duty.DateID == dateID)
                {
                    newDuties.Add(duty);
                }
            }
            return newDuties;
        }
        public static void Removeduties(int dateID)
        {
            foreach (Duty duty in duties.ToList()) 
            {
                if (duty.DateID == dateID)
                {
                    duties.Remove(duty);
                }
            }
        }

        public static bool DutyExist(Duty duty)
        {
            bool exist = false;
            foreach(Duty duti in duties)
            {
                if (duti.DateID == duty.DateID && duti.EmployeeID == duty.EmployeeID && duti.StartTime == duty.StartTime && duti.EndTime == duty.EndTime)
                {
                    exist = true;
                }
            }
            return exist;
        }
    }
}
