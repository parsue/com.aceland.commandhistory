using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Events
{
    public interface IRedoHistoryEvent : IEvent
    {
        void OnRedHistory(object sender);
    }
}