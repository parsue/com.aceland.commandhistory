using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Events
{
    public interface IUndoHistoryEvent : IEvent
    {
        void OnUndoHistory(object sender);
    }
}