namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionInjectionDate(
    int InjectionDateUid,
    DateTime AdministrationDate);
