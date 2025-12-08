using AceLand.Library.Editor;
using UnityEditor;

namespace AceLand.CommandHistory.Editor.Drawer
{
    [CustomEditor(typeof(CommandHistoryProjectSettingsInspector))]
    public class CommandHistoryProjectSettingsInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorHelper.DrawAllPropertiesAsDisabled(serializedObject);
        }
    }
}