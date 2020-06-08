using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Sirena
{
    public class Driver
    {
        public List<Models.TripModel> Trips()
        {
            var response = @"
                <Trips>
                  <Trip>
                    <Supplier>SU</Supplier>
                    <Fligth>10</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>S7</Supplier>
                    <Fligth>11</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>N4</Supplier>
                    <Fligth>15</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>XX</Supplier>
                    <Fligth>20</Fligth>
                    <variants>
                      <variant>
                        <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                        <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                      </variant>
                      <variant>
                        <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                        <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                      </variant>
                    </variants>
                  </Trip>
                </Trips>
            ";
            var serializer = new XmlSerializer(typeof(GdsModels.TripsResponseModel.Trips));
            var rawTrips = (GdsModels.TripsResponseModel.Trips) serializer.Deserialize(new StringReader(response));
            var trips = new List<Models.TripModel>();
            foreach (var rawTrip in rawTrips.Trip)
            {
              var variants = new List<Variant>();

              if (rawTrip.Variants != null)
              {
                foreach (var variant in rawTrip.Variants.Variant)
                {
                  var segments = new List<Segment>();
                  foreach (var segment in variant.Segment)
                  {
                    segments.Add(new Segment{MarketingSupplier = segment.MarketingSupplier, OperatingSupplier = segment.OperatingSupplier});

                  }
                  variants.Add(new Variant{Segments = segments});                  
                } 
              }
                trips.Add(new Models.TripModel
                {
                  Supplier = rawTrip.Supplier, 
                  Fligth = rawTrip.Fligth,
                  Variants = variants
                });
            }
            return trips;
        }

        public Fareremark TripFareRules()
        {
         var response = @"
                <fareremark>
                  <remark new_fare='true'>some text 1</remark>
                  <remark new_fare='true'>some text 2</remark>
                  <remark new_fare='true'>some text 3</remark>
                  <remark new_fare='true'>some text 4</remark>
           </fareremark>
            ";
            var serializer = new XmlSerializer(typeof(GdsModels.FareRemarkResponseModel.Fareremark));
            var rawFareRemark = (GdsModels.FareRemarkResponseModel.Fareremark) serializer.Deserialize(new StringReader(response));
            var remarks = new List<Models.Remark>();
            foreach (var rawRemark in rawFareRemark.Remark)
            {
                remarks.Add(new Remark
                {
                  IsNewFare = (rawRemark.NewFare == "true"),
                  Value = rawRemark.Text
                });
            }
            
            return new Fareremark{Remarks = remarks};
        }
    }
}