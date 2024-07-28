using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    [XmlRoot("XmlSports")]
    public class XmlSportsDto
    {
        [XmlElement("Sport")]
        public List<XmlSportDto> Sports { get; set; }

        [XmlAttribute("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
