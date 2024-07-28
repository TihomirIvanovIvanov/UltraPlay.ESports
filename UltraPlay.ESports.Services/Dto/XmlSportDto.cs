using System.Xml;
using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    public class XmlSportDto
    {
        [XmlElement("Event")]
        public List<XmlEventDto> Events { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public long Id { get; set; }
    }
}