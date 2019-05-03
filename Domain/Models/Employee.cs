﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum Rank
    {
        deltidmedarbejder,
        butikschef
    }
    public class Employee
    {
		public int EmployeeID { get; set; }
		public string Name { get; set; }
        public Rank Rank { get; set; }
    }
}