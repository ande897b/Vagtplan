using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.Models;
using System.Data;
using System.IO;
using Application.Repositories;

namespace Application.DatabaseControllers
{
    public static class DBRosterController
    {
        public static void LoadRosters()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            string shop = null;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Roster";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        startDate = (DateTime)reader["StartDate"];

                        endDate = (DateTime)reader["EndDate"];

                        shop = reader["Shop"].ToString();
                        Shop newShop;
                        if (shop == "kongensgade")
                        {
                            newShop = Shop.kongensgade;
                        }
                        else
                        {
                            newShop = Shop.skibhusvej;
                        }

                        Roster addRoster = new Roster(startDate, endDate, newShop);
                        RosterRepository.AddRoster(addRoster);
                    }
                }
                DBConnection.Close();
            }
        }

        public static void CreateRoster(Roster roster)
        {
            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "Create_Roster";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StartDate_IN", roster.StartDate));
                cmd.Parameters.Add(new SqlParameter("@EndDate_IN", roster.EndDate));
                cmd.Parameters.Add(new SqlParameter("@Shop_IN", roster.Shop.ToString()));
                cmd.ExecuteReader();
                DBConnection.Close();
            }
        }

        public static int GetRosterID(Roster roster)
        {
            string ID = null;
            int IDint = 0;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "Get_Roster";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("StartDate_IN", roster.StartDate));
                cmd.Parameters.Add(new SqlParameter("EndDate_IN", roster.EndDate));
                cmd.Parameters.Add(new SqlParameter("Shop_IN", roster.Shop.ToString()));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        ID = reader["RosterID"].ToString();
                        int.TryParse(ID, out IDint);
                    }
                }
                DBConnection.Close();
            }
            return IDint;
        }

        //public static void CreateDateList(int RosterID, string shop)
        //{
        //    DBConnection.DatabaseName = "CANE";
        //    if (DBConnection.IsConnected())
        //    {
        //        string query = "Create_DateList";
        //        var cmd = new SqlCommand(query, DBConnection.Connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@RosterID_IN", RosterID));
        //        cmd.Parameters.Add(new SqlParameter("@Shop_IN", shop));
        //        cmd.ExecuteReader();
        //        DBConnection.Close();
        //    }
        //}

        //public static int GetDateListID(int RosterID, string shop)
        //{
        //    string ID = null;
        //    int IDint = 0;

        //    DBConnection.DatabaseName = "CANE";
        //    if (DBConnection.IsConnected())
        //    {
        //        string query = "Get_DateList";
        //        var cmd = new SqlCommand(query, DBConnection.Connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("RosterID_IN", RosterID));
        //        cmd.Parameters.Add(new SqlParameter("Shop_IN", shop));
        //        var reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            if (reader.Read())
        //            {
        //                ID = reader["DateListID"].ToString();
        //                int.TryParse(ID, out IDint);
        //            }
        //        }
        //        DBConnection.Close();
        //    }
        //    return IDint;
        //}

        public static void CreateDates(int rosterID, string shop, DateTime startDay, DateTime endDay)
        {
            string query = "Create_Date";
            int daysDiff = ((TimeSpan)(endDay - startDay)).Days;

            for (int i = 0; i <= daysDiff; i++)
            {
                DBConnection.DatabaseName = "CANE";
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
            }
        }
        public static List<Date> GetDates(string shop)
        {
            List<Date> dates = new List<Date>();

            DateTime day;
            int dateID;
            int rosterID;
            string shopDB = null;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "Get_Dates";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Shop_IN", shop));
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
                        dates.Add(date);

                    }
                    DBConnection.Close();
                }
                
            }
            return dates;
        }
    }
}
