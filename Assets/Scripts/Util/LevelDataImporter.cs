using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LevelDataImporter : EditorWindow
{
    private TextAsset jsonFile;
    private LevelDataSO levelDataSO;
    
    [MenuItem("Tools/Level Data Importer")]
    public static void ShowWindow()
    {
        GetWindow<LevelDataImporter>("Level Data Importer");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Import JSON to ScriptableObject", EditorStyles.boldLabel);
        
        EditorGUILayout.Space();
        
        jsonFile = (TextAsset)EditorGUILayout.ObjectField("JSON File", jsonFile, typeof(TextAsset), false);
        levelDataSO = (LevelDataSO)EditorGUILayout.ObjectField("Level Data SO", levelDataSO, typeof(LevelDataSO), false);
        
        EditorGUILayout.Space();
        
        if (GUILayout.Button("Import JSON"))
        {
            if (jsonFile != null && levelDataSO != null)
            {
                ImportJSON();
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "Please assign both JSON file and ScriptableObject!", "OK");
            }
        }
        
        EditorGUILayout.Space();
        
        if (GUILayout.Button("Create New Level Data SO"))
        {
            CreateNewLevelDataSO();
        }
    }
    
    private void ImportJSON()
    {
        try
        {
            string jsonContent = jsonFile.text;
            Debug.LogError(jsonContent);
            LevelDataWrapper wrapper = JsonUtility.FromJson<LevelDataWrapper>(jsonContent);
            levelDataSO.levels.Clear();
            levelDataSO.levels.AddRange(wrapper.levels);
            Debug.Log(levelDataSO.levels.ToString());
            EditorUtility.SetDirty(levelDataSO);
            AssetDatabase.SaveAssets();
            
            EditorUtility.DisplayDialog("Success", "JSON imported successfully!", "OK");
        }
        catch (System.Exception e)
        {
            EditorUtility.DisplayDialog("Error", "Failed to import JSON: " + e.Message, "OK");
        }
    }
    
    private void CreateNewLevelDataSO()
    {
        LevelDataSO newLevelData = ScriptableObject.CreateInstance<LevelDataSO>();
        
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Level Data",
            "LevelData",
            "asset",
            "Please enter a file name to save the level data to"
        );
        
        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(newLevelData, path);
            AssetDatabase.SaveAssets();
            levelDataSO = newLevelData;
        }
    }
    
    [System.Serializable]
    private class LevelDataWrapper
    {
        public List<LevelInfo> levels;
    }
}