using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Common.Models.Request;

public sealed record GetMedicalInvoicesRequest(
    string MedicalOrganizationCode,
    int Year,
    int Month,
    int Page,
    int PageSize,
    string? Search,
    MedicalRegisterType MedicalRegisterType);
