using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface IMedicalControlReader
{
    public Task<PagedResult<DefectDto>> GetDefectsAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<MedicalSanctionDto>> GetMedicalSanctionsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
