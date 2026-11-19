using MedTools.Settlements.Application.Models.Filters.MedicalRegister;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Common.Models.Request;

public sealed record GetFilteredCompletedCasesRequest(
    MedicalRegisterAppliedFilters Filters,
    int Page,
    int PageSize,
    MedicalRegisterType RegisterType);
