namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.StoredProcedures;

public sealed record ProjectionPatient(
    string PatientLastName,
    string PatientFirstName,
    string PatientMiddleName,
    DateTime PatientBirthDate,
    string PatientSex,
    string DocumentTypeName,
    string? DocumentTypeCode,
    string? DocumentSeries,
    string? DocumentNumber,
    DateTime? DocumentIssueDate,
    string? IssuedBy,
    string? PatientRepresentativeLastName,
    string? PatientRepresentativeFirstName,
    string? PatientRepresentativeMiddleName,
    DateTime? PatientRepresentativeBirthday,
    string? PatientRepresentativeSex);
