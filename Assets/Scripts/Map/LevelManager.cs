using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelData;
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private GameObject content;
    
    public LevelInfo GetLevel(int levelNumber)
    {
        return levelData.levels.Find(l => l.Level == levelNumber);
    }
    
    public void LoadLevel(int levelNumber)
    {
        LevelInfo level = GetLevel(levelNumber);
        if (level != null)
        {
            // Sử dụng level data ở đây
            Debug.Log($"Loading Level {level.Level}");
            Debug.Log($"Mission Type: {level.MissionType}");
            Debug.Log($"Target Score: {level.TargetScore}");
            Debug.Log($"Time: {level.TimePlay}");
            
            foreach (var collection in level.Collection)
            {
                Debug.Log($"Collect {collection.Count} {collection.KeoCollection}");
            }
        }
    }

    private void Start()
    {
        levelData.levels.ForEach(l =>
        {
            GameObject  levelItem = Instantiate(levelPrefab, content.transform, true);
            LevelControll levelControll = levelItem.GetComponent<LevelControll>();
            levelControll.setLevelInfo(l);
        });
    }
    
}
