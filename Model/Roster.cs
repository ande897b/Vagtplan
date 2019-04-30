using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Shop
    {
        skibhusvej,
        kongensgade
    }
    public enum Period
    {
        oneMonth,
        twoMonth,
        threeMonth
    }
    
    public class Roster
    {
        public int RosterID { get; set; }
        public Period Period { get; set; }
        public Shop Shop { get; set; }
    }
}
