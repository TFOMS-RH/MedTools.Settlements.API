using AutoMapper;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Models;
using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Mapping;

public sealed class ReconciliationActFileRootMappingProfile : Profile
{
    public ReconciliationActFileRootMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActFileRoot, ReconciliationActFileRoot>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ActStatus, opt => opt.Ignore())
            .ForMember(x => x.UploadDate, opt => opt.Ignore())
            .ForMember(x => x.Uploader, opt => opt.Ignore());
    }
}
