using System.Xml.Serialization;

namespace MedTools.Settlements.Application.Models.XML.ReconciliationAct;

[XmlRoot(ElementName = "ZL_LIST")]
public sealed class ReconciliationActFileRoot
{
    [XmlElement(ElementName = "ZGLV")]
    public ReconciliationActFileHeader Header { get; set; } = null!;

    [XmlElement(ElementName = "ACT")]
    public ReconciliationAct Act { get; set; } = null!;

    [XmlElement(ElementName = "ZAP")]
    public List<ReconciliationActRecord> Records { get; set; } = null!;
}
