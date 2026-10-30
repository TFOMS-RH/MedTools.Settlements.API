using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityOutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Mapping;

public sealed class InvoiceSettlementMappingProfile : Profile
{
    public InvoiceSettlementMappingProfile()
    {
        CreateMap<XmlReconciliationAct.InvoiceSettlement, DbEntityOutgoingReconciliationAct.InvoiceSettlement>()
            .ForMember(x => x.ReconciliationActRecordUid, opt => opt.Ignore())
            .ForMember(x => x.Uid, opt => opt.Ignore());
    }
}
