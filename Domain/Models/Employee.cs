using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum Rank
    {
        parttimer,
        manager
    }
    public class Employee
    {
		public int EmployeeID { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }

        public Employee(int employeeID, string firstName, string lastName, Rank rank)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            Rank = rank;
        }
    }
}
