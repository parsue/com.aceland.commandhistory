using System.Collections.Generic;
using AceLand.CommandHistory.Events;
using AceLand.CommandHistory.ProjectSetting;
using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Core
{
    internal class History
    {
        public static History Create() => new();
        private History() {}
        
        public int UndoCount => _histories.Count;
        public int RedoCount => _abandonment.Count;
        
        private static CommandHistoryProjectSettings Settings => AceCommand.ProjectSettings;
        private readonly LinkedList<ICommand> _histories = new();
        private readonly Stack<ICommand> _abandonment = new();

        public bool Add<T>(T command) where T : ICommand
        {
            if (command.State is not CommandState.None) return false;
            
            _histories.AddLast(command);
            _abandonment.Clear();

            if (UndoCount > Settings.MaxHistory)
                _histories.RemoveFirst();
            
            EventBus.Event<INewHistoryEvent>().WithSender(this).Raise();
            EventBus.Event<IHistoryChangeEvent>().WithSender(this).Raise();

            return true;
        }
        
        public bool ExecuteAndAdd<T>(T command) where T : ICommand
        {
            if (command.State is not CommandState.None) return false;
            
            _histories.AddLast(command);
            _abandonment.Clear();
            command.Redo();

            if (UndoCount > Settings.MaxHistory)
                _histories.RemoveFirst();
            
            EventBus.Event<INewHistoryEvent>().WithSender(this).Raise();
            EventBus.Event<IHistoryChangeEvent>().WithSender(this).Raise();

            return true;
        }

        public bool Undo()
        {
            if (UndoCount == 0) return false;
            
            var command = PopHistory();
            if (command.State is CommandState.Undo) return false;
            
            _abandonment.Push(command);
            command.Undo();
            
            EventBus.Event<IUndoHistoryEvent>().WithSender(this).Raise();
            EventBus.Event<IHistoryChangeEvent>().WithSender(this).Raise();

            return true;
        }

        public bool Redo()
        {
            if (RedoCount == 0) return false;
            
            var command = _abandonment.Pop();
            if (command.State is CommandState.Redo)
            {
                _abandonment.Push(command);
                return false;
            }
            
            _histories.AddLast(command);
            command.Redo();
            
            EventBus.Event<IRedoHistoryEvent>().WithSender(this).Raise();
            EventBus.Event<IHistoryChangeEvent>().WithSender(this).Raise();

            return true;
        }

        private ICommand PopHistory()
        {
            var command = _histories.Last.Value;
            _histories.RemoveLast();
            return command;
        }
    }
}