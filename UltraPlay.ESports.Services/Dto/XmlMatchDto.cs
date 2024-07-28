using System.Xml;
using System.Xml.Serialization;

namespace UltraPlay.ESports.Services.Dto
{
    public class XmlMatchDto
    {
        [XmlElement("Bet")]
        public List<XmlBetDto> Bets { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public long Id { get; set; }

        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute("MatchType")]
        public string MatchType { get; set; }
    }
}