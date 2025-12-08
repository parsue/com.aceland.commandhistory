using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.CommandHistory.ProjectSetting
{
    public class CommandHistoryProjectSettings : ProjectSettings<CommandHistoryProjectSettings>
    {
        [Header("Command History")]
        [SerializeField, Range(16, 512)] private int maxHistory = 32;

        public void OnValidate()
        {
            // noop
        }

        public int MaxHistory => maxHistory;
    }
}