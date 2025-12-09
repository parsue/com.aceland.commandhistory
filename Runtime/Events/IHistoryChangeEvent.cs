using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Events
{
    public interface IHistoryChangeEvent : IEvent
    {
        void OnHistoryChanged(object sender);
    }
}