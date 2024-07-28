using System.Xml;
using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    public class XmlOddDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public long Id { get; set; }

        [XmlAttribute("Value")]
        public double Value { get; set; }

        [XmlElement("SpecialBetValue")]
        public double? SpecialBetValue { get; set; }
    }
}