using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Repositories
{
    public static class DutyExchangeRepository
    {
        private static List<DutyExchange> dutyExchanges = new List<DutyExchange>();
        private static List<DutyExchange> tempDutyExchanges = new List<DutyExchange>();
        public static void AddDutyExchange(DutyExchange dutyExchange)
        {
            if (!DutyExchangeExist(dutyExchange))
                dutyExchanges.Add(dutyExchange);
        }

        public static void AddTempDutyExchanges(DutyExchange dutyExchange)
        {
                tempDutyExchanges.Add(dutyExchange);
        }

        public static List<DutyExchange> GetTempDutyExchanges()
        {
            return tempDutyExchanges;
        }

        public static void ClearTempDutyExchanges()
        {
            tempDutyExchanges.Clear();
        }



        public static bool DutyExchangeExist(DutyExchange dutyExchange)
        {
            bool exist = false;
            foreach (DutyExchange dutyExchange2 in dutyExchanges)
            {
                if (dutyExchange2.DutyID == dutyExchange.DutyID && dutyExchange2.EmployeeID == dutyExchange.EmployeeID)
                {
                    if (dutyExchange2.DutyExchangeID != dutyExchange.DutyExchangeID)
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

        public static void RemoveDutyExchange(int dutyID, int employeeID)
        {
            try
            {
                foreach (DutyExchange dutyExchange2 in dutyExchanges)
                {
                    if (dutyExchange2.DutyID == dutyID && dutyExchange2.EmployeeID == employeeID)
                    {
                        dutyExchanges.Remove(dutyExchange2);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
