﻿namespace Source2Framework.Services.Command
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Commands;

    using Source2Framework.Models;

    /// <summary>
    /// This service exposes the internal <see cref="CommandManager"/>.
    /// </summary>
    public interface ICommandService : ISharedService
    {
        /// <summary>
        /// Executes a command in the given player context. (Only registered commands can be executed)
        /// </summary>
        /// <param name="player">Target player</param>
        /// <param name="command">Command</param>
        public void ExecuteRegisteredCommand(CCSPlayerController player, string command);

        /// <summary>
        /// Whether the given command is registered or not.
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns><see langword="true"/> if registered, <see langword="false"/> otherwise.</returns>
        public bool IsCommandRegistered(string command);

        /// <summary>
        /// Get the <see cref="CommandDefinition"/> instance for the given command.
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns><see cref="CommandDefinition"/> instance for the given command if exists, otherwise <see langword="null"/></returns>
        public CommandDefinition? GetCommandDefinition(string command);

        /// <summary>
        /// Gets every <see cref="CommandDefinition"/> instance for the given command.
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns>A <see cref="IList{CommandDefinition}"/> of <see cref="CommandDefinition"/>s for the given command if exists, otherwise <see langword="null"/></returns>
        public IList<CommandDefinition>? GetCommandDefinitions(string command);
    }
}
