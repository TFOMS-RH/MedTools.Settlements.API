using System.Xml.Serialization;

namespace MedTools.Settlements.Application.Models.XML.ReconciliationAct;


public sealed class ReconciliationAct
{
    [XmlElement(ElementName = "YEAR")]
    public int Year { get; set; }

    [XmlElement(ElementName = "QR")]
    public short Quarter { get; set; }

    [XmlElement(ElementName = "N_ACT")]
    public string ActNumber { get; set; } = string.Empty;

    [XmlElement(ElementName = "D_ACT")]
    public DateTime ActDate { get; set; }

    [XmlElement(ElementName = "C_OKATO1")]
    public string MedicalCareOkatoCode { get; set; } = string.Empty;

    [XmlElement(ElementName = "OKATO_OMS")]
    public string PolicyIssueOkatoCode { get; set; } = string.Empty;
}
