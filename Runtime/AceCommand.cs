using AceLand.CommandHistory.Builder;
using AceLand.CommandHistory.ProjectSetting;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif
using UnityEngine;

namespace AceLand.CommandHistory
{
    public static partial class AceCommand
    {
        internal static CommandHistoryProjectSettings ProjectSettings
        {
            get
            {
                _projectSettings ??= Resources.Load<CommandHistoryProjectSettings>(nameof(CommandHistoryProjectSettings));
                return _projectSettings;
            }
        }
        
#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private static CommandHistoryProjectSettings _projectSettings;
        internal static Core.History History { get; private set; }

#if !UNITY_6000_5_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void ClearStatic()
        {
            _projectSettings = null;
        }
#endif
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            History = Core.History.Create();
        }
        
        public static ICommandBuilder Builder() => CommandBuilder.Create();
        public static int UndoCount() => History.UndoCount;
        public static int RedoCount() => History.RedoCount;
        public static bool Undo() => History.Undo();
        public static bool Redo() => History.Redo();
        public static void Clear() => History.Clear();

        public static void SetMaxHistory(int maxHistory) => ProjectSettings.SetMaxHistory(maxHistory);
    }
}
