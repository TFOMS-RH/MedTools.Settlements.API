namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class ProvidedServiceDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public string ServiceRecordId { get; set; } = string.Empty;
    public string MedicalOrganizationCode { get; set; } = string.Empty;
    public string Division { get; set; } = string.Empty;
    public string? DepartmentCode { get; set; }
    public long? MedicalProfile { get; set; }
    public string? MedicalInterventionType { get; set; }
    public byte IsPediatric { get; set; }
    public DateTime ServiceStartDate { get; set; }
    public DateTime ServiceEndDate { get; set; }
    public byte? IsRefusal { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string ServiceCode { get; set; } = string.Empty;
    public decimal ServiceQuantity { get; set; }
    public decimal? UnitRate { get; set; }
    public decimal AmountBilled { get; set; }
    public int PhysicianSpecialty { get; set; }
    public string PhysicianCode { get; set; } = string.Empty;
    public int? IncompleteVolume { get; set; }
    public string? InternalComment { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
    public List<MedicalDeviceDbEntity> MedicalDevices { get; set; } = [];
}