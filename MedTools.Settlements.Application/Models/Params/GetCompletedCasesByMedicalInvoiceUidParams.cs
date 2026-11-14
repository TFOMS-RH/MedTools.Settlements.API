using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Application.Models.Params;

public sealed record GetCompletedCasesByMedicalInvoiceUidParams(
    int MedicalInvoiceUid,
    int Page,
    int PageSize,
    MedicalRegisterType RegisterType,
    string? Search);
