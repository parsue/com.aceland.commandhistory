using AceLand.ProjectSetting;
using UnityEngine;

namespace AceLand.CommandHistory.ProjectSetting
{
    public class CommandHistoryProjectSettings : ProjectSettings<CommandHistoryProjectSettings>
    {
        [Header("Command History")]
        [SerializeField, Range(16, 512)] private int maxHistory = 32;
        
        [Header("Events")]
        [SerializeField] private bool newHistoryEvents = true;
        [SerializeField] private bool undoHistoryEvents = true;
        [SerializeField] private bool redoHistoryEvents = true;
        [SerializeField] private bool clearHistoryEvents = true;
        [SerializeField] private bool historyChangeEvents = true;

        public void OnValidate()
        {
            // noop
        }

        public int MaxHistory => maxHistory;
        public bool NewHistoryEvents => newHistoryEvents;
        public bool UndoHistoryEvents => undoHistoryEvents;
        public bool RedoHistoryEvents => redoHistoryEvents;
        public bool ClearHistoryEvents => clearHistoryEvents;
        public bool HistoryChangeEvents => historyChangeEvents;
    }
}