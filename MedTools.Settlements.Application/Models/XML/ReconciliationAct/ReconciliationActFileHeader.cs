using System.Xml.Serialization;

namespace MedTools.Settlements.Application.Models.XML.ReconciliationAct;


public sealed class ReconciliationActFileHeader
{
    [XmlElement(ElementName = "VERSION")]
    public string Version { get; set; } = string.Empty;

    [XmlElement(ElementName = "DATA")]
    public DateTime FileDate { get; set; }

    [XmlElement(ElementName = "FILENAME")]
    public string Filename { get; set; } = string.Empty;
}
