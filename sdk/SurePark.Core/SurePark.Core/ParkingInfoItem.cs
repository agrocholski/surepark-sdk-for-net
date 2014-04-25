using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SurePark.Core
{
    public class ParkingInfoItem
    {
        [XmlElementAttribute("LOT")]
        public string TerminalName { get; set; }

        [XmlElementAttribute("COUNT_AREA_ID")]
        internal int CountAreaId { get; set; }

        [XmlElementAttribute("COUNT_AREA_DATE")]
        internal string CountAreaDate { get; set; }

        [XmlElementAttribute("COUNT_AREA_NAME")]
        public string LotName { get; set; }

        [XmlElementAttribute("SPACES")]
        public int AvailabileParkingStalls { get; set; }

        [XmlElementAttribute("VEHICLES")]
        public int UsedParkingStalls { get; set; }

        [XmlElementAttribute("CAPACITY")]
        public int TotalParkingStalls { get; set; }

        [XmlElementAttribute("PERCENT_FULL")]
        public int PercentFull { get; set; }

        [XmlIgnore]
        public DateTime? LastUpdated
        {
            get
            {
                if (!string.IsNullOrEmpty(CountAreaDate))
                {
                    DateTime result;

                    if (DateTime.TryParse(CountAreaDate, out result))
                        return result;
                    else
                        return null;
                }
                else
                    return null;
            }
        }
    }
}
