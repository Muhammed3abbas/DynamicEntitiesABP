using DynamicEntity.Integration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DynamicEntity.Integration.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IntegrationController : AbpControllerBase
{
    protected IntegrationController()
    {
        LocalizationResource = typeof(IntegrationResource);
    }
}
