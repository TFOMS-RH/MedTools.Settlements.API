using AutoMapper;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Mappers;

public sealed class ConsultationMappingProfile : Profile
{
    public ConsultationMappingProfile()
    {
        CreateMap<ProjectionConsultation, ConsultationDto>();
    }
}