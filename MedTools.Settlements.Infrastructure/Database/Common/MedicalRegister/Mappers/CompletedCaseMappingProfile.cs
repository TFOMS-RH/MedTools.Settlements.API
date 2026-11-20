using AutoMapper;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Mappers;

public sealed class CompletedCaseMappingProfile : Profile
{
    public CompletedCaseMappingProfile()
    {
        CreateMap<ProjectionCompletedCase, CompletedCaseDto>()
            .ConstructUsing(src => new CompletedCaseDto(
                CompletedCaseUid: src.CompletedCaseUid,
                MedicalOrganizationCode: null,
                InsuranceOrganizationCode: null,
                EntryNumber: src.EntryNumber,
                AmountBilled: src.AmountBilled,
                ApprovedAmount: src.ApprovedAmount,
                InsuranceCompanyApprovedAmount: src.InsuranceCompanyApprovedAmount,
                MedicalCareConditionsCode: src.MedicalCareConditionsCode,
                MedicalCareConditionsName: src.MedicalCareConditionsName,
                PatientLastName: src.PatientLastName,
                PatientFirstName: src.PatientFirstName,
                PatientMiddleName: src.PatientMiddleName,
                InsurancePolicySeries: src.InsurancePolicySeries,
                InsurancePolicyNumber: src.InsurancePolicyNumber,
                TreatmentStartDate: null,
                TreatmentEndDate: null,
                EntryPositionNumber: src.EntryPositionNumber))
            .ForMember(x => x.MedicalOrganizationCode, opt => opt.Ignore())
            .ForMember(x => x.InsuranceOrganizationCode, opt => opt.Ignore())
            .ForMember(x => x.TreatmentEndDate, opt => opt.Ignore())
            .ForMember(x => x.TreatmentStartDate, opt => opt.Ignore());

        CreateMap<ProjectionCompletedCaseDetails, CompletedCaseDetailsDto>();
    }
}
