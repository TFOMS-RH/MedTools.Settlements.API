using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Application.Models.Params;

public sealed record GetMedicalInvoiceParams(
    string MCode,
    int BillingYear,
    int BillingMonth,
    int Page,
    int PageSize,
    string? Search,
    MedicalRegisterType RegisterType);
