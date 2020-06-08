using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfrastuctureLayer.GdsModels
{
    public class TripsResponseModel
    {
        [XmlRoot(ElementName="Trip")]
        public class Trip {
            [XmlElement(ElementName="Supplier")]
            public string Supplier { get; set; }
            [XmlElement(ElementName="Fligth")]
            public string Fligth { get; set; }
            [XmlElement(ElementName="variants")]
            public Variants Variants { get; set; }
        }
        [XmlRoot(ElementName="segment")]
        public class Segment {
            [XmlAttribute(AttributeName="operating_supplier")]
            public string OperatingSupplier { get; set; }
            [XmlAttribute(AttributeName="marketing_supplier")]
            public string MarketingSupplier { get; set; }
        }
        [XmlRoot(ElementName="variant")]
        public class Variant {
            [XmlElement(ElementName="segment")]
            public List<Segment> Segment { get; set; }
        }
        [XmlRoot(ElementName="variants")]
        public class Variants {
            [XmlElement(ElementName="variant")]
            public List<Variant> Variant { get; set; }
        }

        [XmlRoot(ElementName="Trips")]
        public class Trips {
            [XmlElement(ElementName="Trip")]
            public List<Trip> Trip { get; set; }
        }
    }
}