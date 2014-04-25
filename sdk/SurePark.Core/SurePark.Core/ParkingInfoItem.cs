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
        public string Lot { get; set; }

        [XmlElementAttribute("COUNT_AREA_ID")]
        public int CountAreaId { get; set; }

        [XmlElementAttribute("COUNT_AREA_DATE")]
        public string CountAreaDate { get; set; }

        [XmlElementAttribute("COUNT_AREA_NAME")]
        public string CountAreaName { get; set; }

        [XmlElementAttribute("SPACES")]
        public int Spaces { get; set; }

        [XmlElementAttribute("VEHICLES")]
        public int Vehicles { get; set; }

        [XmlElementAttribute("CAPACITY")]
        public int Capacity { get; set; }

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
