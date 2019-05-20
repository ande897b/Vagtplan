using Application;
using Controller.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.DatabaseControllers
{
    public class DBDutyController
    {
        public static void LoadDuties()
        {
            int employeeID ;
            DateTime startTime;
            DateTime endTime;
            int dateID;
            int dutyID;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Duty";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeID = (int)reader["EmployeeID"];
                        dateID = (int)reader["DateID"];
                        dutyID = (int)reader["DutyID"];
                        startTime = (DateTime)reader["StartTime"];
                        endTime = (DateTime)reader["EndTime"];

                        Duty duty = new Duty(employeeID, dutyID, startTime, endTime, dateID);
                        DutyRepository.AddDuty(duty);
                    }
                }
                DBConnection.Close();
            }
        }
        //public static int GetDutyID(Duty duty)
        //{
        //    int ID = 0;

        //    DBConnection.DatabaseName = "CANE";
        //    if (DBConnection.IsConnected())
        //    {
        //        string query = "Get_Employee";
        //        var cmd = new SqlCommand(query, DBConnection.Connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("FirstName_IN", duty.FirstName));
        //        cmd.Parameters.Add(new SqlParameter("LastName_IN", employee.LastName));
        //        var reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            if (reader.Read())
        //            {
        //                ID = (int)reader["EmployeeID"];
        //            }
        //        }
        //        DBConnection.Close();
        //    }
        //    return ID;
        //}
    }
}
