using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject worldMap;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Play;
    [SerializeField] private GameObject Quit;
    [SerializeField] private Button yes, no;
    [SerializeField] private bool testModel = false;
    [SerializeField] private GameObject Sound;
    [SerializeField] private Sprite  soundOn, soundOff;
    [SerializeField] private Text txtMyGold;
    [SerializeField] private Button freeGold;
}
