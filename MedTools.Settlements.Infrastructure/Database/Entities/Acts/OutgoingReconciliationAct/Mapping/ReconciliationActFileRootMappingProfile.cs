using AutoMapper;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityOutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Mapping;

public sealed class ReconciliationActFileRootMappingProfile : Profile
{
    public ReconciliationActFileRootMappingProfile()
    {
        CreateMap<XmlReconciliationAct.ReconciliationActFileRoot, DbEntityOutgoingReconciliationAct.ReconciliationActFileRoot>()
            .ForMember(x => x.Uid, opt => opt.Ignore())
            .ForMember(x => x.ActStatus, opt => opt.Ignore())
            .ForMember(x => x.UploadDate, opt => opt.Ignore())
            .ForMember(x => x.Uploader, opt => opt.Ignore());
    }
}
