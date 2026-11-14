using System.Xml.Serialization;

namespace MedTools.Settlements.Application.Models.XML.ReconciliationAct;

public sealed class InvoiceSettlement
{
    [XmlElement(ElementName = "NSCHET")]
    public string InvoiceNumber { get; set; } = string.Empty;

    [XmlElement(ElementName = "DSCHET")]
    public DateTime InvoiceDate { get; set; }
    
    [XmlElement(ElementName = "SCHET_OB")]
    public decimal OpeningBalance { get; set; }
    
    [XmlElement(ElementName = "SUMMAP")]
    public decimal MedicalCarePaymentAmount { get; set; }
    
    [XmlElement(ElementName = "SUMMAREC")]
    public decimal RecoveryNoticeAmount { get; set; }
    
    [XmlElement(ElementName = "SUMMARET")]
    public decimal RefundNoticeAmount { get; set; }
    
    [XmlElement(ElementName = "SUMMA1")]
    public decimal TransferFromInsurancePlaceAmount { get; set; }
    
    [XmlElement(ElementName = "SUMMA2")]
    public decimal TransferFromCarePlaceAmount { get; set; }
    
    [XmlElement(ElementName = "SCHET_CB")]
    public decimal ClosingBalance { get; set; }
}
