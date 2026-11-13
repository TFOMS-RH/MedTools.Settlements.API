using AutoMapper;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Mappers;

public sealed class ClassificationCriterionMappingProfile : Profile
{
    public ClassificationCriterionMappingProfile()
    {
        CreateMap<ProjectionClassificationCriterion, ClassificationCriterionDto>();
    }
}
