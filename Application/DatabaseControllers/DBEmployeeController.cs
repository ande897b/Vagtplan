using Application.Repositories;
using Domain.Models;
using System.Data;
using System.Data.SqlClient;

namespace Application.DatabaseControllers
{
    public static class DBEmployeeController
    {
        public static void LoadEmployees()
        {
            int employeeID;
            string rank = null;
            string firstName = null;
            string lastName = null;
            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeID = (int)reader["EmployeeID"];

                        rank = reader["EmployeeRank"].ToString();
                        Rank newRank;
                        if (rank == "Parttimer")
                        {
                            newRank = Rank.parttimer;
                        }
                        else
                        {
                            newRank = Rank.manager;
                        }

                        firstName = reader["FirstName"].ToString();
                        lastName = reader["LastName"].ToString();

                        Employee employee = new Employee(employeeID, firstName, lastName, newRank);
                        EmployeeRepository.AddEmployee(employee);
                    }
                }
                DBConnection.Close();
            }
        }
    }
}
