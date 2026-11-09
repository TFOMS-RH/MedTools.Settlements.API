using AutoMapper;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.StoredProcedures;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Mappers;

public sealed class CompletedCaseMappingProfile : Profile
{
    public CompletedCaseMappingProfile()
    {
        CreateMap<ProjectionCompletedCase, CompletedCaseDto>();
    }
}
