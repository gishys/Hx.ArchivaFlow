using AutoMapper;
using Hx.Abp.Attachment.Application.Contracts;
using Hx.Abp.Attachment.Domain.Shared;
using Hx.ArchivaFlow.Application.Contracts;

namespace Hx.ArchivaFlow.Attachment.Application
{
    public class ArchivaFlowAttachmentProfile : Profile
    {
        public ArchivaFlowAttachmentProfile()
        {
            CreateMap<GetArchiveCatalogueListInput, GetAttachListInput>(MemberList.None);
            CreateMap<AttachCatalogueDto, ArchiveCatalogueDto>(MemberList.None)
                .ForMember(f => f.Count, m => m.MapFrom(c => c.AttachCount))
                .ForMember(f => f.Files, m => m.MapFrom(c => c.AttachFiles));
            CreateMap<AttachFileDto, ArchiveFileDto>(MemberList.None);
            CreateMap<ArchiveCatalogueCreateDto, AttachCatalogueCreateDto>(MemberList.None);
            CreateMap<ArchiveFileCreateDto, AttachFileCreateDto>(MemberList.None);
        }
    }
}
