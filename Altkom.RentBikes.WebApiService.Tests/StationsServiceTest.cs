using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Altkom.RentBikes.WebApiService.Services;
using System.Linq;

namespace Altkom.RentBikes.WebApiService.Tests
{
    [TestClass]
    public class StationsServiceTest
    {
        [TestMethod]
        public void GetBikesByStationTest()
        {
            var stationId = 1;

            IStationsService stationsService = new MockStationsService();
            var bikes = stationsService.GetBikesByStation(stationId);

            Assert.IsNotNull(bikes);
            Assert.IsTrue(bikes.Any());

        }
    }
}
