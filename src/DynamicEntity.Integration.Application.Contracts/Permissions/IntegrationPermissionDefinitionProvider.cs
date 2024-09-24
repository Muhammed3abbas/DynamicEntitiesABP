using DynamicEntity.Integration.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace DynamicEntity.Integration.Permissions;

public class IntegrationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IntegrationPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(IntegrationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IntegrationResource>(name);
    }
}
