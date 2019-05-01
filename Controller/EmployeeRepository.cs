using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class EmployeeRepository
    {
		private static List<Employee> employees = new List<Employee>();
		public static void AddEmployee(Employee employee)
		{
			employees.Add(employee);
		}
		public  int GetEmployeeID()
		{

		}
		public List<Employee> GetEmployees()
		{
			return List<Employee> employees;
		}
		public void RemoveEmployee()
		{

		}
    }
}
