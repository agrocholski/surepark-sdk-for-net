using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurePark.Core;

namespace SurePark.Core.Test
{
    [TestClass]
    public class SureParkClientTest
    {
        private string _parkingInfoUrl = "http://www.mspairport.com/data/sureparknow/surepark.aspx";
        private SureParkClient _client = null;

        [TestInitialize()]
        public void Initialize()
        {
            _client = new SureParkClient(_parkingInfoUrl);
        }

        [TestMethod]
        public void GetAirportParkingInfoTest()
        {
            var parkingInfo = _client.GetAirportParkingInfo().Result;
            
            Assert.IsNotNull(parkingInfo);
        }

        [TestMethod]
        public void GetTerminalParkingInfoTest()
        {
            string terminalName = "Terminal 1";

            var parkingInfo = _client.GetTerminalParkingInfo(terminalName).Result;

            int expected = 2;
            int actual = parkingInfo.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTerminalLotParkingInfoTest()
        {;
            string terminalName = "Terminal 1";
            string lotName = "Total General (T1)";

            var parkingInfo = _client.GetTerminalLotParkingInfo(terminalName, lotName).Result;

            int expected = 1;
            int actual = parkingInfo.Count;

            Assert.AreEqual(expected, actual);

        }
    }
}
