using UnityEngine;

public class LevelControll : MonoBehaviour
{
    public int Level;
    public GameData.MISSIONTYPE MissionType;
    public int TargetScore;
    public GameData.Collection[] Collection;
    public GameObject panelShop;
    public int TimePlay;

    // Use this for initialization
    void Awake()
    {
        //name = "Level" + Level.ToString();        
        //GetComponentInChildren<Text>().text = Level.ToString();
        //GetComponent<Button>().onClick.AddListener(OnClick);
        //GetComponentInChildren<Text>().resizeTextMaxSize = 60;        
    }

    public void setLevelInfo(LevelInfo levelInfo)
    {
        Level = levelInfo.Level;
        MissionType = levelInfo.MissionType;
        TargetScore = levelInfo.TargetScore;
        if (levelInfo.Collection != null && levelInfo.Collection.Count > 0)
        {
            Collection = new GameData.Collection[levelInfo.Collection.Count];
            for (int i = 0; i < levelInfo.Collection.Count; i++)
            {
                Collection[i] = new GameData.Collection(levelInfo.Collection[i].KeoCollection);
                Collection[i].Count = levelInfo.Collection[i].Count;
            }
        }
        else
        {
            Collection = new GameData.Collection[0];
        }
    }
    
    void OnClick()
    {
        //SoundController.Intance.Play(SoundController.CLIP.CLICK);
        GameData.TimePlay = TimePlay;
        GameData.Level = Level;
        GameData.MissionType = MissionType;
        GameData.TargetScore = TargetScore;
        GameData.KeoCollection = Collection;
        //GetComponent<LevelShow>().setImageKeoCollection();
        panelShop.SetActive(true);      
    }
}
