using AutoMapper;

using MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Models;

using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Mapping;

public sealed class ReconciliationActRecordMappingProfile : Profile
{
    public ReconciliationActRecordMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActRecord, ReconciliationActRecord>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}
