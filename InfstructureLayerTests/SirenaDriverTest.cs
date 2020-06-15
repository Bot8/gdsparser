using System.Collections.Generic;
using InfrastuctureLayer.Gds.Sirena;
using InfrastuctureLayer.Models;
using Xunit;

namespace InfstructureLayerTests
{
    public class SirenaDriverTest
    {
        private readonly Driver _driver;

        public SirenaDriverTest()
        {
            _driver = (Driver) CompositionRootLayer.CompositionRootBuilder.BuildServiceProvider()
                .GetService(typeof(Driver));
        }

        [Fact]
        public void TestTrips()
        {
            var trips = _driver.Trips();
            var expectedTrips = new List<TripModel>();

            expectedTrips.Add(new TripModel {Supplier = "SU", Fligth = "10"});
            expectedTrips.Add(new TripModel {Supplier = "S7", Fligth = "11"});
            expectedTrips.Add(new TripModel {Supplier = "N4", Fligth = "15"});

            var variants = new List<Variant>();
            var segments1 = new List<Segment>();
            segments1.Add(new Segment {OperatingSupplier = "SU", MarketingSupplier = "S7"});
            segments1.Add(new Segment {OperatingSupplier = "SU", MarketingSupplier = "S7"});
            variants.Add(new Variant {Segments = segments1});

            var segments2 = (new List<Segment>());
            segments2.Add(new Segment {OperatingSupplier = "AA", MarketingSupplier = "BB"});
            segments2.Add(new Segment {OperatingSupplier = "AA", MarketingSupplier = "BB"});
            variants.Add(new Variant {Segments = segments2});

            expectedTrips.Add(new TripModel {Supplier = "XX", Fligth = "20", Variants = variants});

            Assert.Equal(expectedTrips, trips);
        }

        [Fact]
        public void TestTripFareRules()
        {
            var expectedRules =
                "Remark -> some text 1 IsNewFare -> True Remark -> some text 2 IsNewFare -> True Remark -> some text 3 IsNewFare -> True Remark -> some text 4 IsNewFare -> True ";
            var rules = _driver.TripFareRules();

            Assert.Equal(expectedRules, rules);
        }
    }
}