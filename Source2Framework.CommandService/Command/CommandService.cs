namespace Source2Framework.Services.Command
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Commands;
    using CounterStrikeSharp.API.Core.Plugin;

    using Source2Framework.Models;

    /// <summary>
    /// This service exposes the internal <see cref="CounterStrikeSharp.API.Core.Commands.CommandManager"/>.
    /// </summary>
    public sealed partial class CommandService : SharedService<CommandService>, ICommandService
    {
        public required CommandManager CommandManager { get; set; }

        public required Dictionary<string, IList<CommandDefinition>> CommandDefinitions { get; set; }

        public CommandService(ILogger<CommandService> logger, IPluginContext pluginContext) : base(logger, pluginContext)
            { }

        public override void Initialize(bool hotReload)
        {
            CommandManager? commandManager = Reflection.GetFieldValue<CommandManager, PluginCommandManagerDecorator>(this.Plugin.CommandManager as PluginCommandManagerDecorator, "_inner");

            if (commandManager == null)
            {
                throw new NullReferenceException("CommandManager is null");
            }

            this.CommandManager = commandManager;

            Dictionary<string, IList<CommandDefinition>>? commandDefinitions = Reflection.GetFieldValue<Dictionary<string, IList<CommandDefinition>>, CommandManager>(commandManager, "_commandDefinitions");

            if (commandDefinitions == null)
            {
                throw new Exception("Unable to get command definitions");
            }

            this.CommandDefinitions = commandDefinitions;
        }

        /// <inheritdoc/>
        public void ExecuteRegisteredCommand(CCSPlayerController player, string command)
        {
            if (!this.IsCommandRegistered(command))
            {
                throw new Exception($"Unknown command '{command}'");
            }

            player.ExecuteClientCommand($"css_{command}");
        }

        /// <inheritdoc/>
        public bool IsCommandRegistered(string command)
        {
            return this.CommandDefinitions.ContainsKey(command);
        }

        /// <inheritdoc/>
        public CommandDefinition? GetCommandDefinition(string command)
        {
            return this.GetCommandDefinitions(command)?.FirstOrDefault();
        }

        /// <inheritdoc/>
        public IList<CommandDefinition>? GetCommandDefinitions(string command)
        {
            if (this.CommandDefinitions.TryGetValue(command, out IList<CommandDefinition>? commandDefinition))
            {
                return commandDefinition;
            }

            return null;
        }
    }
}
