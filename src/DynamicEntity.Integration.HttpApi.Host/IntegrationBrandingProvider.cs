using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DynamicEntity.Integration;

[Dependency(ReplaceServices = true)]
public class IntegrationBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Integration";
}
