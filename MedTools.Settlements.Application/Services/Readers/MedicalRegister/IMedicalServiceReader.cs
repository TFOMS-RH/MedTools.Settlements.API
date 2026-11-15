using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface IMedicalServiceReader
{
    public Task<IReadOnlyCollection<ProvidedServiceDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
