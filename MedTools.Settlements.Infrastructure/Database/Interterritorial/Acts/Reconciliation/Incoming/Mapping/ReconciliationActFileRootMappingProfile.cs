using AutoMapper;

using MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming.Models;

using XML = MedTools.Settlements.Application.Models.XML;

namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming.Mapping;

public sealed class ReconciliationActFileRootMappingProfile : Profile
{
    public ReconciliationActFileRootMappingProfile()
    {
        CreateMap<XML.ReconciliationAct.ReconciliationActFileRoot, ReconciliationActFileRoot>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ActStatus, opt => opt.Ignore())
            .ForMember(x => x.Header, opt => opt.Ignore())
            .ForMember(x => x.UploadDate, opt => opt.Ignore())
            .ForMember(x => x.Uploader, opt => opt.Ignore())
            .ForMember(x => x.Act, opt => opt.Ignore())
            .ForMember(x => x.Records, opt => opt.Ignore());
    }
}
