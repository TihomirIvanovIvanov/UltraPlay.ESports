using System.Xml;
using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    public class XmlEventDto
    {
        [XmlElement("Match")]
        public List<XmlMatchDto> Matches { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public long Id { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlAttribute("CategoryID")]
        public long CategoryId { get; set; }
    }
}