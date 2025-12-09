using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Events
{
    public interface IClearHistoryEvent : IEvent
    {
        void OnClearHistory(object sender);
    }
}