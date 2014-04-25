using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurePark.Core;

namespace SurePark.Core.Test
{
    [TestClass]
    public class SureParkClientTest
    {
        [TestMethod]
        public void GetAirportParkingInfoTest()
        {
            string parkingInfoUrl = "http://www.mspairport.com/data/sureparknow/surepark.aspx";

            var client = new SureParkClient();
            var parkingInfo = client.GetAirportParkingInfo(parkingInfoUrl).Result;
            
            Assert.IsNotNull(parkingInfo);
        }

        [TestMethod]
        public void GetTerminalParkingInfoTest()
        {
            string parkingInfoUrl = "http://www.mspairport.com/data/sureparknow/surepark.aspx";
            string terminalId = "Terminal 1";

            var client = new SureParkClient();
            var parkingInfo = client.GetTerminalParkingInfo(parkingInfoUrl, terminalId).Result;

            int expected = 2;
            int actual = parkingInfo.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTerminalLotParkingInfoTest()
        {
            string parkingInfoUrl = "http://www.mspairport.com/data/sureparknow/surepark.aspx";
            string terminalId = "Terminal 1";
            string lotId = "Total General (T1)";

            var client = new SureParkClient();
            var parkingInfo = client.GetTerminalLotParkingInfo(parkingInfoUrl, terminalId, lotId).Result;

            int expected = 1;
            int actual = parkingInfo.Count;

            Assert.AreEqual(expected, actual);

        }
    }
}
