using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Repositories
{
    public static class DateRepository
    {
        private static List<Date> dates = new List<Date>();
        public static void AddDate(Date date)
        {
            dates.Add(date);
        }
        public static List<Date> GetDates()
        {
            return dates;
        }
        public static void RemoveDate(Date date)
        {
            dates.Remove(date);
        }
        public static int GetDateID(string date, Shop shop)
        {
            int id = 0;
            foreach (Date day in dates)
            {
                if (day.Day.ToString().Substring(0, 10) == date.Substring(0,10) && day.Shop == shop)
                {
                    id = day.DateID;
                }
            }
            return id;
        }
    }
}
