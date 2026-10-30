using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityIncomingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Mapping;

public sealed class ReconciliationActMappingProfile : Profile
{
    public ReconciliationActMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationAct, DbEntityIncomingReconciliationAct.ReconciliationAct>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRoot, opt => opt.Ignore());
    }
}