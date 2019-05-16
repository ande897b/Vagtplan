using System;

namespace Domain.Models
{
    public class Duty
    {
        public Employee Employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}