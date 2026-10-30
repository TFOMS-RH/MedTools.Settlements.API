using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityIncomingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Mapping;

public sealed class InvoiceSettlementMappingProfile : Profile
{
    public InvoiceSettlementMappingProfile()
    {
        CreateMap<XmlReconciliationAct.InvoiceSettlement, DbEntityIncomingReconciliationAct.InvoiceSettlement>()
            .ForMember(x => x.ReconciliationActRecordUid, opt => opt.Ignore())
            .ForMember(x => x.Uid, opt => opt.Ignore());
    }
}
