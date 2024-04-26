namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;

    using Source2Framework.Services.Command;

    public class PluginServices : IPluginServiceCollection<CommandServicePlugin>
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<CommandService>();
        }
    }
}
