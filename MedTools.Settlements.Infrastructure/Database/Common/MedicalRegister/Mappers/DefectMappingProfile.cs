using AutoMapper;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Mappers;

public sealed class DefectMappingProfile : Profile
{
    public DefectMappingProfile()
    {
        CreateMap<ProjectionDefect, DefectDto>();
    }
}
