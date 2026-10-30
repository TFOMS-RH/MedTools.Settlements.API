using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityOutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Mapping;

public sealed class ReconciliationActFileHeaderMappingProfile : Profile
{
    public ReconciliationActFileHeaderMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationActFileHeader, DbEntityOutgoingReconciliationAct.ReconciliationActFileHeader>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRoot, opt => opt.Ignore());
    }
}
