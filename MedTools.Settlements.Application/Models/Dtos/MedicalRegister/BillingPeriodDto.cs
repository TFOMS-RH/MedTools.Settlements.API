namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record BillingPeriodDto(
    int BillingYear,
    List<byte> BillingMonths);
