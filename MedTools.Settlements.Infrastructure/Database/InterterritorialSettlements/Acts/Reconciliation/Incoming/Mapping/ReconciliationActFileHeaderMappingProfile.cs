using AutoMapper;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Models;
using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Mapping;

public sealed class ReconciliationActFileHeaderMappingProfile : Profile
{
    public ReconciliationActFileHeaderMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActFileHeader, ReconciliationActFileHeader>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}
