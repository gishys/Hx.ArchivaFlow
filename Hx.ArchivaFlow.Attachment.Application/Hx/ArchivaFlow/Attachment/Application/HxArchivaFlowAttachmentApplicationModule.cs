using Hx.Abp.Attachment.Application;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.Attachment.Application
{
    [DependsOn(typeof(HxAbpAttachmentApplicationModule))]
    public class HxArchivaFlowAttachmentApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HxArchivaFlowAttachmentApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ArchivaFlowAttachmentProfile>(validate: true);
            });
        }
    }
}
