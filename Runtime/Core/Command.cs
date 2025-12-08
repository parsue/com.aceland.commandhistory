using System;

namespace AceLand.CommandHistory.Core
{
    internal class Command : ICommand
    {
        public static Command Create(Action undo, Action redo) =>
            new(undo, redo);
        
        private Command(Action undo, Action redo)
        {
            _undo = undo;
            _redo = redo;
        }
        
        private readonly Action _undo;
        private readonly Action _redo;

        private CommandState State { get; set; }

        CommandState ICommand.State => State;

        void ICommand.Redo()
        {
            _redo?.Invoke();
            State = CommandState.Redo;
        }

        void ICommand.Undo()
        {
            _undo?.Invoke();
            State = CommandState.Undo;
        }
    }
}