using AceLand.CommandHistory.ProjectSetting;
using AceLand.ProjectSetting.Editor;
using UnityEditor;

namespace AceLand.CommandHistory.Editor.Drawer
{
    [CustomEditor(typeof(CommandHistoryProjectSettings))]
    public class CommandHistoryProjectSettingsInspector : AceLandSettingsInspector
    {
    }
}