using System.IO;
using PS.UiFramework.Config;
using PS.UiFramework.Container;
using PS.UiFramework.Editor.Extensions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PS.UiFramework.Editor.Windows
{
    public class EmptyPanelCreationEditor : EditorWindow
    {
        private const string CONFIG_PATH = "Config/UiFramework/UiFrameworkConfig";

        private const string ASSETS_FOLDER_NAME = "Assets";
        private const string PREFABS_FOLDER_NAME = "Prefabs";
        private const string PANELS_PREFABS_FOLDER_NAME = "Panels";
        
        private static UiFrameworkConfig _config;
        
        private string panelName = "New Panel Name";
        
        private GameObject _panelInstance;

        [MenuItem("UiFramework/Create Empty Panel")]
        public static void ShowCreatePanelWindow()
        {
            LoadConfig();

            var window = GetWindow<EmptyPanelCreationEditor>("Create Panel");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.BeginVertical("box");
            
            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.BigHeader("Panels Creator & Saver");
            
            CustomEditorElements.SeparatorLine();

            EditorGUILayout.Space();
            
            GUILayout.BeginVertical("box");
            
            EditorGUILayout.LabelField("Enter panel name", CustomEditorStyles.HeaderStyle);
            
            EditorGUILayout.Space();
            
            panelName = EditorGUILayout.TextField("Panel Name", panelName);
            
            EditorGUILayout.Space();

            if (GUILayout.Button("Create Panel"))
            {
                CreateEmptyPanel();
            }
            
            if (GUILayout.Button("Save Panel as Prefab"))
            {
                SavePanelAsPrefab();
            }
            
            EditorGUILayout.Space();
            
            GUILayout.EndVertical();
            
            CustomEditorElements.SeparatorLine();
            
            GUILayout.EndVertical();
        }

        private static void LoadConfig()
        {
            if (_config == null) 
                _config = Resources.Load<UiFrameworkConfig>(CONFIG_PATH);
        }

        private void CreateEmptyPanel()
        {
            if (_config == null)
            {
                Debug.LogError("MyPluginConfig not found in Resources!");
                return;
            }

            if (TryLoadDevScene() == false) 
                return;

            DeletePanelsContainers();

            var panelContainerInstance = CreatePanelContainerInstance();
            _panelInstance = CreatePanelInstance(panelContainerInstance);
            
            SelectPanelObject(_panelInstance);
        }

        private static void DeletePanelsContainers()
        {
            var existingContainer = FindObjectOfType<PanelsContainer>();
            while (existingContainer != null)
            {
                DestroyImmediate(existingContainer.gameObject);
                existingContainer = FindObjectOfType<PanelsContainer>();
            }
        }

        private static bool TryLoadDevScene()
        {
            var devScenePath = AssetDatabase.GetAssetPath(_config.DevScene);

            if (SceneManager.GetActiveScene().path.Equals(devScenePath)) 
                return true;
            
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return false;

            EditorSceneManager.OpenScene(devScenePath);

            return true;
        }

        private static PanelsContainer CreatePanelContainerInstance()
        {
            var panelContainerInstance = (PanelsContainer)PrefabUtility.InstantiatePrefab(_config.ContainerPrefab);

            if (panelContainerInstance == null) 
                Debug.LogError("Failed to instantiate Panel Container prefab.");
            else
                PrefabUtility.UnpackPrefabInstance(panelContainerInstance.gameObject, PrefabUnpackMode.Completely, InteractionMode.UserAction);
            
            return panelContainerInstance;
        }

        private GameObject CreatePanelInstance(PanelsContainer panelContainerInstance)
        {
            var panelInstance = (GameObject)PrefabUtility.InstantiatePrefab(_config.EmptyPanelPrefab, panelContainerInstance.transform);
            panelInstance.name = panelName;

            if (panelInstance == null)
                Debug.LogError("Failed to instantiate Panel prefab.");
            else
                PrefabUtility.UnpackPrefabInstance(panelInstance, PrefabUnpackMode.Completely, InteractionMode.UserAction);
            
            return panelInstance;
        }

        private void SavePanelAsPrefab()
        {
            if (_config == null)
            {
                Debug.LogError("MyPluginConfig not found in Resources!");
                return;
            }

            EnsurePrefabsFolderExist();

            if (_panelInstance == null)
            {
                Debug.LogError("No panel found with the name: " + panelName);
                return;
            }

            var panelsPrefabsPath = Path.Combine(ASSETS_FOLDER_NAME, PREFABS_FOLDER_NAME, PANELS_PREFABS_FOLDER_NAME);
            var prefabPath = Path.Combine(panelsPrefabsPath, $"{panelName}.prefab");
            var uniquePrefabPath = AssetDatabase.GenerateUniqueAssetPath(prefabPath);

            var savedPrefab = PrefabUtility.SaveAsPrefabAssetAndConnect(_panelInstance, uniquePrefabPath, InteractionMode.UserAction);
            Selection.activeObject = savedPrefab;
            
            Debug.Log($"Panel saved as prefab at: {uniquePrefabPath}");
        }

        private static void EnsurePrefabsFolderExist()
        {
            EnsureFolderExist(ASSETS_FOLDER_NAME, PREFABS_FOLDER_NAME);
            EnsureFolderExist(Path.Combine(ASSETS_FOLDER_NAME, PREFABS_FOLDER_NAME), PANELS_PREFABS_FOLDER_NAME);
        }

        private static void EnsureFolderExist(string path, string folderName)
        {
            var folderPath = Path.Combine(path, folderName);
            
            if (AssetDatabase.IsValidFolder(folderPath) == false)
                AssetDatabase.CreateFolder(path, folderName);
        }
        
        private static void SelectPanelObject(GameObject panelInstance)
        {
            Selection.activeObject = panelInstance;
            EditorGUIUtility.PingObject(panelInstance);
            ExpandSelectedObject();
        }
        
        private static void ExpandSelectedObject()
        {
            var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
            var window = GetWindow(type);
            var exprec = type.GetMethod("SetExpandedRecursive");
            exprec!.Invoke(window, new object[] {Selection.activeGameObject.GetInstanceID(), true});
        }
    }
}