using AutoMapper;

using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Mapping;

public sealed class ReconciliationActFileHeaderMappingProfile : Profile
{
    public ReconciliationActFileHeaderMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActFileHeader, Models.ReconciliationActFileHeader>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}
