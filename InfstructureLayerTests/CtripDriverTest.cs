using System.Collections.Generic;
using InfrastuctureLayer.Gds.Ctrip;
using InfrastuctureLayer.Models;
using Xunit;

namespace InfstructureLayerTests
{
    public class CtripDriverTest
    {
        private readonly Driver _driver;

        public CtripDriverTest()
        {
            _driver = (Driver) CompositionRootLayer.CompositionRootBuilder.BuildServiceProvider()
                .GetService(typeof(Driver));
        }

        [Fact]
        public void TestTrips()
        {
            var trips = _driver.Trips();
            var expectedTrips = new List<TripModel>();

            var variants = new List<Variant>();
            var segments = new List<Segment>();
            segments.Add(new Segment {OperatingSupplier = "SU", MarketingSupplier = "SU"});
            variants.Add(new Variant {Segments = segments});

            expectedTrips.Add(new TripModel {Variants = variants});

            Assert.Equal(expectedTrips, trips);
        }

        [Fact]
        public void TestTripFareRules()
        {
            const string expectedRules = "Remark -> text_1 IsNewFare -> False Remark -> text_2 IsNewFare -> False ";
            var rules = _driver.TripFareRules();

            Assert.Equal(expectedRules, rules);
        }
    }
}