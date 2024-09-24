using Volo.Abp.Settings;

namespace DynamicEntity.Integration.Settings;

public class IntegrationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IntegrationSettings.MySetting1));
    }
}
