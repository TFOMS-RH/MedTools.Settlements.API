using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Common.Models.Request;

public sealed record GetCompletedCasesByMedicalInvoiceUidRequest(
    int Page,
    int PageSize,
    string? Search,
    MedicalRegisterType RegisterType);
