using AutoMapper;
using Hx.ArchivaFlow.Application.Contracts;
using Hx.ArchivaFlow.Domain;

namespace Hx.ArchiveFlow.Application
{
    public class ArchivaFlowProfile : Profile
    {
        public ArchivaFlowProfile()
        {
            CreateMap<Archive, ArchiveDto>(MemberList.None);
            CreateMap<Metadata, MetadataDto>(MemberList.None);
        }
    }
}
