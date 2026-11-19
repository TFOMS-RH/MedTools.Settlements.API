using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Extractors;

public interface IMedicalRegisterExtractor
{
    public Task<IReadOnlyCollection<MedicalOrganizationDto>> ExtractMedicalOrganizationsAsync(
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<BillingPeriodDto>> ExtractBillingPeriodsAsync(
        string medicalOrganizationCode,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);


}
