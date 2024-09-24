using DynamicEntity.Integration.Localization;
using Volo.Abp.Application.Services;

namespace DynamicEntity.Integration;

/* Inherit your application services from this class.
 */
public abstract class IntegrationAppService : ApplicationService
{
    protected IntegrationAppService()
    {
        LocalizationResource = typeof(IntegrationResource);
    }
}
