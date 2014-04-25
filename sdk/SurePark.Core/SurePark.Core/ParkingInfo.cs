using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SurePark.Core
{
    [XmlRootAttribute(ElementName="parkinginfo", Namespace="")]
    public class ParkingInfo
    {
        [XmlElementAttribute("item")]
        public ParkingInfoItem[] Items { get; set; }
    }
}
