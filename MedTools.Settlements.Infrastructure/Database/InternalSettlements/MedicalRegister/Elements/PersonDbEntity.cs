using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class PersonDbEntity
{
    public int Uid { get; set; }
    public int PersonRegistryUid { get; set; }

    public string PatientRecordCode { get; set; } = string.Empty;
    public string PatientLastName { get; set; } = string.Empty;
    public string PatientFirstName { get; set; } = string.Empty;
    public string PatientMiddleName { get; set; } = string.Empty;
    public byte PatientSex { get; set; }
    public DateTime PatientBirthDate { get; set; }
    public byte? PatientIdentityConfidenceCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PatientRepresentativeLastName { get; set; }
    public string? PatientRepresentativeFirstName { get; set; }
    public string? PatientRepresentativeMiddleName { get; set; }
    public byte? PatientRepresentativeSex { get; set; }
    public DateTime? PatientRepresentativeBirthday { get; set; }
    public byte? RepresentativeIdentityConfidenceCode { get; set; }
    public string? BirthPlace { get; set; }
    public string? DocumentTypeCode { get; set; }
    public string? DocumentSeries { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Snils { get; set; }
    public string? ResidenceOkatoCode { get; set; }
    public string? TemporaryResidenceOkatoCode { get; set; }
    public string? InternalComment { get; set; }
    public DateTime? DocumentIssueDate { get; set; }
    public string? IssuedBy { get; set; }

    public PersonRegistryDbEntity PersonRegistry { get; set; } = null!;

}
