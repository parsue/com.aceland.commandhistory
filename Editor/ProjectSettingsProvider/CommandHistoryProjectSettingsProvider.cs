using AceLand.CommandHistory.ProjectSetting;
using AceLand.Library.Editor.Providers;
using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.CommandHistory.Editor.ProjectSettingsProvider
{
    public class CommandHistoryProjectSettingsProvider : AceLandSettingsProvider
    {
        public const string SETTINGS_NAME = "Project/AceLand Packages/Command History";
        
        private CommandHistoryProjectSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Settings = CommandHistoryProjectSettings.GetSerializedSettings();
            var s = Settings.targetObject as CommandHistoryProjectSettings;
            s?.OnValidate();
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new CommandHistoryProjectSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            
            return provider;
        }
    }
}