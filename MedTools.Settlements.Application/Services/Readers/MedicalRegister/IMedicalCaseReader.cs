using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface IMedicalCaseReader
{
    public Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<MedicalCaseDetailsDto?> GetMedicalCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
