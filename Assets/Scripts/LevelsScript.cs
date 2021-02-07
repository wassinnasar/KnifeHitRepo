using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScript : MonoBehaviour
{
    [SerializeField]
    private Log[] logs = new Log[10];
    private int levelNumber = 0;
    [SerializeField]
    private Log currentLog;
    int addInt = 0;
    [SerializeField]
    private Text stageText;
    [SerializeField]
    private Text stText;
    int stageNumber;
    string st = "STAGE";
    // Start is called before the first frame update
    void Awake()
    {
        stageNumber = 1;
        levelNumber = PlayerPrefs.GetInt("levelN");
        addInt = PlayerPrefs.GetInt("ad");
        stageNumber = PlayerPrefs.GetInt("stageN");
        currentLog = logs[levelNumber];
        GameController.Instance.LogDisplay.log = currentLog;
        stText.text = st.ToString();
        stageText.text = stageNumber.ToString();

    }
    public void Win()
    {
        levelNumber++;
        stageNumber++;
        Application.LoadLevel(1);
        PlayerPrefs.SetInt("levelN", levelNumber);
        PlayerPrefs.SetInt("stageN",stageNumber);
    }
    public void Loss()
    {
        
            currentLog = logs[0];
            stageNumber = 1;
        levelNumber = 0;
        PlayerPrefs.SetInt("AK", 0);
        PlayerPrefs.SetInt("stageN", stageNumber);
         PlayerPrefs.SetInt("levelN",levelNumber);
        PlayerPrefs.SetInt("ad", addInt);
            Application.LoadLevel(1);
        
    }
}
