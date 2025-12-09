using AceLand.EventDriven.Bus;

namespace AceLand.CommandHistory.Events
{
    public interface INewHistoryEvent : IEvent
    {
        void OnNewHistory(object sender);
    }
}