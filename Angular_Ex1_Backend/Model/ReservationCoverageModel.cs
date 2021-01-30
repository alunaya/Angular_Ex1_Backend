using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Model
{
    public class ReservationCoverageModel
    {
        public string InstanceType { get; set; }
        public float TotalHours { get; set; }
        public float ReservedHours { get; set; }

        public float OnDemandHours {
            get
            {
                return (float)Math.Round(TotalHours - ReservedHours, 2);
            }
        }

        public float Coverage
        {
            get
            {
                return (float)Math.Round(ReservedHours/TotalHours * 100, 2);
            }
        }
    }
}
