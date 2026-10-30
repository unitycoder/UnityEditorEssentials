using System.Reflection;
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

    public class SceneViewToggles
    {
        private static readonly PropertyInfo s_ShowSelectionOutline = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.AnnotationUtility")?.GetProperty("showSelectionOutline", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        [MainToolbarElement("Essentials/Toggle UI Layer", defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement ToggleUiLayerButton()
        {
            var icon = EditorGUIUtility.IconContent("d_Canvas Icon").image as Texture2D;
            var content = new MainToolbarContent(icon, "Toggle UI layer visibility in the Scene view");
            return new MainToolbarToggle(content, IsUiLayerVisible(), SetUiLayerVisibility);
        }

        [MainToolbarElement("Essentials/Toggle Selection Outline", defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement ToggleSelectionOutlineButton()
        {
            var icon = EditorGUIUtility.IconContent("d_SceneViewFx").image as Texture2D;
            var content = new MainToolbarContent(icon, "Toggle selection outlines in the Scene view");
            return new MainToolbarToggle(content, IsSelectionOutlineVisible(), SetSelectionOutlineVisibility);
        }

        private static bool IsUiLayerVisible()
        {
            var uiLayer = LayerMask.NameToLayer("UI");
            return uiLayer >= 0 && (Tools.visibleLayers & (1 << uiLayer)) != 0;
        }

        private static void SetUiLayerVisibility(bool visible)
        {
            var uiLayer = LayerMask.NameToLayer("UI");
            if (uiLayer < 0)
            {
                Debug.LogWarning("The UI layer does not exist.");
                return;
            }

            var uiLayerMask = 1 << uiLayer;
            Tools.visibleLayers = visible ? Tools.visibleLayers | uiLayerMask : Tools.visibleLayers & ~uiLayerMask;
            SceneView.RepaintAll();
        }

        private static bool IsSelectionOutlineVisible()
        {
            return s_ShowSelectionOutline != null && (bool)s_ShowSelectionOutline.GetValue(null);
        }

        private static void SetSelectionOutlineVisibility(bool visible)
        {
            if (s_ShowSelectionOutline == null)
            {
                Debug.LogWarning("Selection outline settings are unavailable in this Unity version.");
                return;
            }

            s_ShowSelectionOutline.SetValue(null, visible);
            SceneView.RepaintAll();
        }
    } // SceneViewToggles
} // namespace