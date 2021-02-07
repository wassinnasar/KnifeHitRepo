using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private GameObject panelKnife;
    [SerializeField]
    private Color knifeColor;
    [SerializeField]
    private Text _tex;
    public int apples = 0;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject gameButton;
    public bool tapBool = true;
    [SerializeField]
    private GameObject mainSpawner;
    [SerializeField]
    private GameObject log;
    [SerializeField]
    private Text textKnives;
    [SerializeField]
    private Text textApples;
    public int knives;
    [SerializeField]
    private int appls;

    void Start()
    {
        apples = PlayerPrefs.GetInt("Ap");
    }
    void Update()
    {
        appls = GameController.Instance.GameUI.apples;
        textApples.text = appls.ToString();
        knives = log.GetComponent<LogDisplay>().allKnives;
        textKnives.text = knives.ToString();
    }
    public void KnivesCount(int count)
    {
        for(int i = 0; i<count; i++){
            Instantiate(iconKnife,panelKnife.transform);
        }
    }
    private int knifeIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnife.transform.GetChild(knifeIndexToChange++).GetComponent<Image>().color = knifeColor;
    }
    public void CatchApple()
    {
        apples++;
        _tex.text = apples.ToString();
        PlayerPrefs.SetInt("Ap", apples);
    }
    public void ActiveRestartButton()
    {
        StartCoroutine(CoroutineRestartButton());
        tapBool = false;
    }
    private IEnumerator CoroutineRestartButton()
    {
        yield return new WaitForSeconds(0.3f);
        restartButton.SetActive(true);
        mainSpawner.SetActive(false);
    }
    public void Restart()
    {
        Application.LoadLevel(1);
    }
}
