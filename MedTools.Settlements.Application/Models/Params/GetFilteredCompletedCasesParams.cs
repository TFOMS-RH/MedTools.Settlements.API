using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Models.Filters.MedicalRegister;

namespace MedTools.Settlements.Application.Models.Params;

public sealed record GetFilteredCompletedCasesParams(
    MedicalRegisterAppliedFilters Filters,
    int Page,
    int PageSize,
    MedicalRegisterType RegisterType);
