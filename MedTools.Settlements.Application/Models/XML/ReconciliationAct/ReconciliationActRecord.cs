using System.Xml.Serialization;

namespace MedTools.Settlements.Application.Models.XML.ReconciliationAct;

public sealed class ReconciliationActRecord
{
    [XmlElement(ElementName = "N_ZAP")]
    public int RecordNumber { get; set; }

    [XmlElement(ElementName = "RASSCHET")]
    public InvoiceSettlement InvoiceSettlement { get; set; } = null!;

}
