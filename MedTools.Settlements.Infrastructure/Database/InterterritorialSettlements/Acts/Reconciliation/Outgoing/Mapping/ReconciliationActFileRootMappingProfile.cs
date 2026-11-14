using AutoMapper;
using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Outgoing.Mapping;

public sealed class ReconciliationActFileRootMappingProfile : Profile
{
    public ReconciliationActFileRootMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActFileRoot, Models.ReconciliationActFileRoot>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ActStatus, opt => opt.Ignore())
            .ForMember(x => x.UploadDate, opt => opt.Ignore())
            .ForMember(x => x.Uploader, opt => opt.Ignore());
    }
}
