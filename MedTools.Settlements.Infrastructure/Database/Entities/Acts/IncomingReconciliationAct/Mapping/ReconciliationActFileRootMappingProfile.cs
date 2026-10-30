using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityIncomingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Mapping;

public sealed class ReconciliationActFileRootMappingProfile : Profile
{
    public ReconciliationActFileRootMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationActFileRoot, DbEntityIncomingReconciliationAct.ReconciliationActFileRoot>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ActStatus, opt => opt.Ignore())
            .ForMember(x => x.Header, opt => opt.Ignore())
            .ForMember(x => x.UploadDate, opt => opt.Ignore())
            .ForMember(x => x.Uploader, opt => opt.Ignore())
            .ForMember(x => x.Act, opt => opt.Ignore())
            .ForMember(x => x.Records, opt => opt.Ignore());
    }
}
