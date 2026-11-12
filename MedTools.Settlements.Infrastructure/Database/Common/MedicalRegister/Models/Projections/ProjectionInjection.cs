namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionInjection(
    int InjectionUid,
    DateTime AdministrationDate,
    decimal? AdministeredQuantity,
    decimal? ConsumedQuantity,
    decimal? UnitCost,
    decimal? AdministeredCost,
    decimal? ConsumedCost,
    bool? IsReductionApplied);
