namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionContraindication(
    int ContraindicationUid,
    byte ContraindicationCode,
    string Contraindication,
    DateTime ContraindicationDate);
