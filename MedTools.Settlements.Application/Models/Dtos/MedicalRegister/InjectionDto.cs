namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record InjectionDto(
    int InjectionUid,
    DateTime AdministrationDate,
    decimal? AdministeredQuantity,
    decimal? ConsumedQuantity,
    decimal? UnitCost,
    decimal? AdministeredCost,
    decimal? ConsumedCost,
    bool? IsReductionApplied);
