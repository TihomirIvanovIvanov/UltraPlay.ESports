using System.Xml;
using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    public class XmlBetDto
    {
        [XmlElement("Odd")]
        public List<XmlOddDto> Odds { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public long Id { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }
    }
}