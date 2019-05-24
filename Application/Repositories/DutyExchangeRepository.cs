using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public static class DutyExchangeRepository
    {
        private static List<DutyExchange> dutyExchanges = new List<DutyExchange>();
        public static void AddDutyExchange(DutyExchange dutyExchange)
        {
            if (!DutyExchangeExist(dutyExchange))
                dutyExchanges.Add(dutyExchange);
        }
        public static bool DutyExchangeExist(DutyExchange dutyExchange)
        {
            bool exist = false;
            foreach (DutyExchange dutyExchange2 in dutyExchanges)
            {
                if (dutyExchange2.DutyID == dutyExchange.DutyID && dutyExchange2.EmployeeID == dutyExchange.EmployeeID)
                {
                    if (dutyExchange2.DutyExchangeID == -1)
                    {
                        dutyExchange2.DutyExchangeID = dutyExchange.DutyExchangeID;
                    }
                    exist = true;
                }
            }
            return exist;
        }
        public static List<DutyExchange> GetDutyExchanges()
        {
            return dutyExchanges;
        }
        public static void RemoveDutyExchange(DutyExchange dutyExchange)
        {
            dutyExchanges.Remove(dutyExchange);
        }

    }
}
