using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record PersonFilters(
    PatientFilters Patient,
    RepresentativeFilters Representative,
    InsuranceFilters Insurance);

public sealed record PatientFilters(
    string FirstName,
    string LastName,
    string MiddleName,
    Sex? Sex,
    DateTime? BirthDate);

public sealed record RepresentativeFilters(
    string FirstName,
    string LastName,
    string MiddleName,
    Sex? Sex,
    DateTime? BirthDate);

public sealed record InsuranceFilters(
    List<string> Insurances,
    List<string> InsurancePolicyTypes,
    List<string> InsurancePolicyNumbers,
    List<string> UnifiedPolicyNumbers,
    string InsurancePolicySeries);
