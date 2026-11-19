namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record SanctionFilters(
    string ExpertiseActNumber,
    DateTime? ExpertiseActDate,
    List<string> ControlTypeCodes,
    List<int> RefusalReasons);
