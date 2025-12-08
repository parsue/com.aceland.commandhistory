using AceLand.CommandHistory.Builder;
using AceLand.CommandHistory.ProjectSetting;
using UnityEngine;

namespace AceLand.CommandHistory
{
    public static class AceCommand
    {
        internal static CommandHistoryProjectSettings ProjectSettings
        {
            get
            {
                _projectSettings ??= Resources.Load<CommandHistoryProjectSettings>(nameof(CommandHistoryProjectSettings));
                return _projectSettings;
            }
        }
        private static CommandHistoryProjectSettings _projectSettings;
        internal static Core.History History { get; set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            History = Core.History.Create();
        }
        
        public static ICommandBuilder Builder() => CommandHistory.Builder.CommandBuilder.Create();
        public static int UndoCount() => History.UndoCount;
        public static int RedoCount() => History.RedoCount;
        public static bool Undo() => History.Undo();
        public static bool Redo() => History.Redo();
    }
}