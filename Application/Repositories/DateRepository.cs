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
            if (!DateExist(date))
            dates.Add(date);
        }
        public static bool DateExist(Date date)
        {
            bool exist = false;
            foreach (Date date2 in dates)
            {
                if (date2.Day == date.Day && date2.Shop == date.Shop)
                {
                    exist = true;
                }
            }
            return exist;
        }
        public static DateTime GetDate(string date)
        {
            DateTime newDate = DateTime.Now;
            foreach (Date date2 in dates)
            {
                if (date2.Day.ToString() == date)
                {
                    newDate = date2.Day;
                }
            }
            return newDate;
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
