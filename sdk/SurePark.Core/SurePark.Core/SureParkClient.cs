using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SurePark.Core
{
    public class SureParkClient
    {
        private string _parkingAvailabilityUrl = "";

        public SureParkClient(string parkingAvailabilityUrl)
        {
            _parkingAvailabilityUrl = parkingAvailabilityUrl;
        }

        public async Task<List<ParkingInfoItem>> GetAirportParkingInfoAsync()
        {
            var httpClient = new HttpClient();

            var responseXml = await httpClient.GetStringAsync(_parkingAvailabilityUrl);

            var validXml = CleanupAvailabilityXml(responseXml);

            byte[] byteArray = Encoding.UTF8.GetBytes(validXml);

            MemoryStream stream = new MemoryStream(byteArray);

            var serializer = new XmlSerializer(typeof(ParkingInfo));

            var parkingInfo = (ParkingInfo)serializer.Deserialize(stream);

            return parkingInfo.Items.ToList();
        }

        public async Task<List<ParkingInfoItem>> GetTerminalParkingInfoAsync(string terminalName)
        {
            var parkingInfo = await GetAirportParkingInfoAsync();

            var query = (from item in parkingInfo
                         where item.TerminalName == terminalName
                         select item).ToList();

            return query;
        }

        public async Task<List<ParkingInfoItem>>GetTerminalLotParkingInfoAsync(string terminalName, string lotName)
        {
            var parkingInfo = await GetTerminalParkingInfoAsync(terminalName);

            var query = (from item in parkingInfo
                         where item.LotName == lotName
                         select item).ToList();

            return query;
        }

        private string CleanupAvailabilityXml(string sourceXml)
        {
            var outputXml = "";

            //trim the xml
            sourceXml = sourceXml.Trim();

            //determine index of invalid markup
            var index = sourceXml.IndexOf("<?xml", 6);

            //return xml prior to invalid markup
            if (index >= 0)
                outputXml = sourceXml.Substring(0, index);
            else
                outputXml = sourceXml;

            return outputXml;
        }
    }
}
