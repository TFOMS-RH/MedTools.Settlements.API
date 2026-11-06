using AutoMapper;

using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming.Mapping;

public sealed class ReconciliationActMappingProfile : Profile
{
    public ReconciliationActMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationAct, Models.ReconciliationAct>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}