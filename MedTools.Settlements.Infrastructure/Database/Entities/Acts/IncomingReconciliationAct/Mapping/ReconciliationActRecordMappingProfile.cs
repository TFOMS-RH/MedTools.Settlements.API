using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityIncomingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Mapping;

public sealed class ReconciliationActRecordMappingProfile : Profile
{
    public ReconciliationActRecordMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationActRecord, DbEntityIncomingReconciliationAct.ReconciliationActRecord>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.InvoiceSettlement, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRoot, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}
