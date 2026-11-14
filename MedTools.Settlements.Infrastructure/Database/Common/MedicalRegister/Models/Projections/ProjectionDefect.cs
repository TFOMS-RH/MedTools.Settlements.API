namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionDefect(
    int DefectUid,
    short? Code,
    string Comment);
