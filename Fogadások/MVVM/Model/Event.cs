using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fogadások.MVVM.Model
{
    internal class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public float OddsHome { get; set; }
        public float OddsDraw { get; set; }
        public float OddsAway { get; set; }
    }
}
