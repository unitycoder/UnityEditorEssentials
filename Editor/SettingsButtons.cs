using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace UnityCoder.Essentials.Editor
{
    public class BuildSettings
    {
        [MainToolbarElement("Essentials/Build Settings", defaultDockPosition = MainToolbarDockPosition.Left)]
        public static MainToolbarElement BuildSettingsButton()
        {
            var icon = EditorGUIUtility.IconContent("BuildSettings.Editor").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () =>
            {
                EditorApplication.ExecuteMenuItem("File/Build Profiles");
            });
        }
    } // BuildSettings

    public class ProjectSettings
    {
        [MainToolbarElement("Essentials/Project Settings", defaultDockPosition = MainToolbarDockPosition.Left)]
        public static MainToolbarElement ProjectSettingsButton()
        {
            var icon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () =>
            {
                SettingsService.OpenProjectSettings();
            });
        }
    } // ProjectSettings
} // namespace