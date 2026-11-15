using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface IPatientReader
{
    public Task<PatientDto?> GetPatientAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<InsuranceDto?> GetInsuranceAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
