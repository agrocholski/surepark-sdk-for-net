using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurePark.Core
{
    public class SureParkClient
    {
        public SureParkClient()
            : this("http://www.mspairport.com/data/sureparknow/surepark.aspx",
            "http://www.mspairport.com/data/sureparknow/info.xml") { }

        public SureParkClient(string availabilityUrl, string rateUrl)
        {
            if (string.IsNullOrEmpty(availabilityUrl))
                throw new ArgumentNullException("availabilityUrl");

            if (string.IsNullOrEmpty(rateUrl))
                throw new ArgumentNullException("rateUrl");

            AvailabilityUrl = availabilityUrl;
            RateUrl = availabilityUrl;
        }

        public string AvailabilityUrl { get; set; }
        public string RateUrl { get; set; }
    }
}
