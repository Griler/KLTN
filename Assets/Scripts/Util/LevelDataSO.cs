using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelDataSO : ScriptableObject
{
    public List<LevelInfo> levels = new List<LevelInfo>();
}

[System.Serializable]
public class LevelInfo
{
    public int Level;
    public GameData.MISSIONTYPE MissionType;
    public int TargetScore;
    public List<CollectionInfo> Collection;
    public int TimePlay;
}

[System.Serializable]
public class CollectionInfo
{
    public GameData.KEOCOLLECTION KeoCollection;
    public int Count;
}

public enum MISSIONTYPE
{
    COLLECTION,
    SCORE,
}