using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfrastuctureLayer.Gds.Sirena.Models
{
    public class FareRemarkResponseModel
    {
        [XmlRoot(ElementName = "remark")]
        public class Remark
        {
            [XmlAttribute(AttributeName = "new_fare")]
            public string NewFare { get; set; }

            [XmlText] public string Text { get; set; }
        }

        [XmlRoot(ElementName = "fareremark")]
        public class Fareremark
        {
            [XmlElement(ElementName = "remark")] public List<Remark> Remark { get; set; }
        }
    }
}