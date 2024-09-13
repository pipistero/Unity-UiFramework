using PS.UiFramework.Config;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PS.UiFramework.Editor.ContextMenu
{
    public static class FrameworkContextMenu
    {
        private const string CONFIG_PATH = "Config/UiFramework/UiFrameworkConfig";

        private static UiFrameworkConfig _config;
        
        [MenuItem("UiFramework/Open development scene")]
        public static void LoadDevelopmentScene()
        {
            if (_config == null) 
                _config = Resources.Load<UiFrameworkConfig>(CONFIG_PATH);
            
            var devScenePath = AssetDatabase.GetAssetPath(_config.DevScene);

            if (SceneManager.GetActiveScene().path.Equals(devScenePath)) 
                return;
            
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return;
                
            EditorSceneManager.OpenScene(devScenePath);
        }
    }
}