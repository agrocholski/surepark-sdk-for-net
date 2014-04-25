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
        public async Task<List<ParkingInfoItem>> GetAirportParkingInfo(string parkingInfoUrl)
        {
            var httpClient = new HttpClient();

            var responseXml = await httpClient.GetStringAsync(parkingInfoUrl);

            var validXml = CleanupAvailabilityXml(responseXml);

            byte[] byteArray = Encoding.UTF8.GetBytes(validXml);

            MemoryStream stream = new MemoryStream(byteArray);

            var serializer = new XmlSerializer(typeof(ParkingInfo));

            var parkingInfo = (ParkingInfo)serializer.Deserialize(stream);

            return parkingInfo.Items.ToList();
        }

        public async Task<List<ParkingInfoItem>> GetTerminalParkingInfo(string parkingInfoUrl, string terminalId)
        {
            var parkingInfo = await GetAirportParkingInfo(parkingInfoUrl);

            var query = (from item in parkingInfo
                         where item.Lot == terminalId
                         select item).ToList();

            return query;
        }

        public async Task<List<ParkingInfoItem>>GetTerminalLotParkingInfo(string parkingInfoUrl, string terminalId, string lotId)
        {
            var parkingInfo = await GetTerminalParkingInfo(parkingInfoUrl, terminalId);

            var query = (from item in parkingInfo
                         where item.CountAreaName == lotId
                         select item).ToList();

            return query;
        }

        public async Task<List<ParkingRate>> GetTerminalParkingRates(string parkingRateId, string parkingRateUrl)
        {
            throw new NotImplementedException();
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
