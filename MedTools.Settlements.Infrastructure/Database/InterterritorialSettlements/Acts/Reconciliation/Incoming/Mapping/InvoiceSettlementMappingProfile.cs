using AutoMapper;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Models;
using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Mapping;

public sealed class InvoiceSettlementMappingProfile : Profile
{
    public InvoiceSettlementMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.InvoiceSettlement, InvoiceSettlement>()
            .ForMember(x => x.ReconciliationActRecordUid, opt => opt.Ignore())
            .ForMember(x => x.Uid, opt => opt.Ignore());
    }
}
