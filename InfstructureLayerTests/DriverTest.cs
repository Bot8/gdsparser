using System.Collections.Generic;
using InfrastuctureLayer.Gds.Sirena;
using InfrastuctureLayer.Models;
using Xunit;

namespace InfstructureLayerTests
{
    public class DriverTest
    {
        protected readonly Driver _driver;

        public DriverTest()
        {
            _driver = new Driver();
        }

        [Fact]
        public void TestTrips()
        {
            var trips = _driver.Trips();
            var expectedTrips = new List<TripModel>();

            expectedTrips.Add(new TripModel {Supplier = "SU", Fligth = "10"});
            expectedTrips.Add(new TripModel {Supplier = "S7", Fligth = "11"});
            expectedTrips.Add(new TripModel {Supplier = "N4", Fligth = "15"});
            expectedTrips.Add(new TripModel {Supplier = "XX", Fligth = "20"});

            Assert.Equal(trips, expectedTrips);
        }
    }
}