using Application.Repositories;
using Domain.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Application.DatabaseControllers
{
    public static class DBDateController
    {
        public static void LoadDates()
        {
            DateTime day;
            int dateID;
            int rosterID;
            string shopDB = null;
            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Date";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dateID = (int)reader["DateID"];
                        rosterID = (int)reader["RosterID"];
                        day = (DateTime)reader["Day"];
                        shopDB = reader["Shop"].ToString();
                        Shop newShop;
                        if (shopDB == "kongensgade")
                        {
                            newShop = Shop.kongensgade;
                        }
                        else
                        {
                            newShop = Shop.skibhusvej;
                        }
                        Date date = new Date(day, dateID, rosterID, newShop);
                        DateRepository.AddDate(date);
                    }
                }
                DBConnection.Close();
            }
        }

        public static void CreateDates(int rosterID, string shop, DateTime startDay, DateTime endDay)
        {
            DBConnection.DatabaseName = "CANE";
            string query = "Create_Date";
            int daysDiff = ((TimeSpan)(endDay.Date - startDay.Date)).Days;
            Shop newShop;
            if (shop.ToLower() == "kongensgade")
            {
                newShop = Shop.kongensgade;
            }
            else
            {
                newShop = Shop.skibhusvej;
            }
            for (int i = 0; i <= daysDiff; i++)
            {
                Date date = new Date(startDay.AddDays(i), rosterID, newShop);
                if (!DateRepository.DateExist(date))
                {
                    if (DBConnection.IsConnected())
                    {
                        var cmd = new SqlCommand(query, DBConnection.Connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@RosterID_IN", rosterID));
                        cmd.Parameters.Add(new SqlParameter("@Shop_IN", shop));
                        cmd.Parameters.Add(new SqlParameter("@Day_IN", startDay.AddDays(i)));
                        cmd.ExecuteReader();
                    }
                    DBConnection.Close();
                    DateRepository.AddDate(date);
                }
            }
        }
    }
}
    

