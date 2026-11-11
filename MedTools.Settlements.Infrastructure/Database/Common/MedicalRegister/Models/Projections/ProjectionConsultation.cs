namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionConsultation(
    int ConsultationUid,
    byte ConsultationPurposeCode,
    string ConsultationPurpose,
    DateTime? ConsultationDate);
