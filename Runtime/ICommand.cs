using System;
using AceLand.CommandHistory.Core;

namespace AceLand.CommandHistory
{
    public interface ICommand
    {
        internal CommandState State { get; }
        internal void Redo();
        internal void Undo();
    }

    public static class CommandExtensions
    {
        public static bool Add<T>(this T historyCommand) where T : ICommand =>
            historyCommand == null
                ? throw new ArgumentNullException(nameof(historyCommand), "Execute Command Failed: command is null.")
                : AceCommand.History.Add(historyCommand);
        
        public static bool AddAndExecute<T>(this T historyCommand) where T : ICommand =>
            historyCommand == null
                ? throw new ArgumentNullException(nameof(historyCommand), "Execute Command Failed: command is null.")
                : AceCommand.History.ExecuteAndAdd(historyCommand);
        
        public static ICommand Clone<T>(this T command) where T : ICommand =>
            Command.Create(command.Undo, command.Redo);
    }
}