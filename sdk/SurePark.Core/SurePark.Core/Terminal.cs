using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurePark.Core
{
    public class Terminal
    {
        public Terminal()
        {
            ParkingRates = new List<ParkingRate>();
        }

        public string Name { get; set; }
        public string ParkingAvailability { get; set; }
        public List<ParkingRate> ParkingRates { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
