using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public sealed class MedicalServiceReader(

    MedicalRegisterDbContextResolver dbContextResolver,
    IMapper mapper) : IMedicalServiceReader
{
    public async Task<IReadOnlyCollection<ProvidedServiceDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionProvidedService>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetProvidedServices,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ProvidedServiceDto>>(result);
    }

    public async Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalDevice>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalDevices,
                parameters: new SqlParameter("@pProvidedServiceUid", providedServiceUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicalDeviceDto>>(result);
    }
}
