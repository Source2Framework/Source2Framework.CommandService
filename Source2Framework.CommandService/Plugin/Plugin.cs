namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Attributes;

    using Source2Framework.Models;

    using Source2Framework.Services.Command;

    [MinimumApiVersion(214)]
    public sealed partial class CommandServicePlugin : BasePlugin, IS2FModule
    {
        public required IFramework Framework { get; set; }

        public readonly CommandService CommandService;

        public CommandServicePlugin
            (
                CommandService commandService
            )
        {
            this.CommandService = commandService;
        }

        public override void OnAllPluginsLoaded(bool hotReload)
        {
            using (ModuleLoader loader = new ModuleLoader())
            {
                loader.Attach(this, hotReload);
            }
        }

        public void OnCoreReady(IFramework framework, bool hotReload)
        {
            (this.Framework = framework).Services.RegisterService<CommandService>(this.CommandService, true);
        }

        public override void Unload(bool hotReload)
        {
            this.Framework?.Services.RemoveService<CommandService>();
        }
    }
}
