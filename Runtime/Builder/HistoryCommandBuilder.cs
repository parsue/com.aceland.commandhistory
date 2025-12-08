using System;
using AceLand.CommandHistory.Core;

namespace AceLand.CommandHistory.Builder
{
    public interface ICommandBuilder
    {
        ICommandBuilder WithUndoState(Action undo);
        ICommandBuilder WithRedoState(Action redo);
        ICommand Build();
    }
    
    internal class CommandBuilder : ICommandBuilder
    {
        public static CommandBuilder Create() => new();
        private CommandBuilder() { }
        
        private Action _undo;
        private Action _redo;
        
        public ICommand Build()
        {
            if (_undo == null || _redo == null)
                throw new NullReferenceException("History Command Builder: Action of Redo state cannot be null.");
            
            return Command.Create(_undo, _redo);
        }

        public ICommandBuilder WithUndoState(Action undo)
        {
            _undo += undo ?? throw new ArgumentNullException(
                nameof(undo),
                "History Command Builder: Action of Redo state cannot be null."
            );
            return this;
        }

        public ICommandBuilder WithRedoState(Action redo)
        {
            _redo += redo ?? throw new ArgumentNullException(
                nameof(redo),
                "History Command Builder: Action of Redo state cannot be null."
            );
            return this;
        }
    }
}