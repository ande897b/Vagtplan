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
            duties.Add(duty);
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
        public static void Removeduty(Duty duty)
        {
            duties.Remove(duty);
        }
    }
}
