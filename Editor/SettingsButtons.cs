using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace UnityCoder.Essentials.Editor
{
    public class ProjectSettings
    {
        [MainToolbarElement("Tools/Project Settings", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement ProjectSettingsButton()
        {
            var icon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () =>
            {
                SettingsService.OpenProjectSettings();
            });
        }
    } // class

    public class BuildSettings
    {
        [MainToolbarElement("Tools/Build Settings", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement BuildSettingsButton()
        {
            var icon = EditorGUIUtility.IconContent("BuildSettings.Editor").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () =>
            {
                //EditorWindow.GetWindow(System.Type.GetType("UnityEditor.BuildPlayerWindow,UnityEditor"));
                EditorApplication.ExecuteMenuItem("File/Build Profiles");
            });
        }
    } // class




} // namespace