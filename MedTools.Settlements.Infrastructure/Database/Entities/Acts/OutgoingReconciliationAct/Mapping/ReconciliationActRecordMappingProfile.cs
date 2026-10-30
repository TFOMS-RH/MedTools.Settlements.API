using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityOutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Mapping;

public sealed class ReconciliationActRecordMappingProfile : Profile
{
    public ReconciliationActRecordMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationActRecord, DbEntityOutgoingReconciliationAct.ReconciliationActRecord>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.InvoiceSettlement, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRoot, opt => opt.Ignore())
            .ForMember(x => x.ReconciliationActFileRootUid, opt => opt.Ignore());
    }
}
