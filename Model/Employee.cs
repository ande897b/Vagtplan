using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Rank
    {
        deltidmedarbejder,
        butikschef
    }
    public class Employee
    {
        public string Name { get; set; }
        public Rank Rank { get; set; }
    }
}
