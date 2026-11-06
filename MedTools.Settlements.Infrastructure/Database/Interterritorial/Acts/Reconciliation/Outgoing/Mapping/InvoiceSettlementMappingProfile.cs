using AutoMapper;

using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Mapping;

public sealed class InvoiceSettlementMappingProfile : Profile
{
    public InvoiceSettlementMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.InvoiceSettlement, Models.InvoiceSettlement>()
            .ForMember(x => x.ReconciliationActRecordUid, opt => opt.Ignore())
            .ForMember(x => x.Uid, opt => opt.Ignore());
    }
}
