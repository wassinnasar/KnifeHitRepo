using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Text _textApples;
    [SerializeField]
    private Text _textKnives;
    [SerializeField]
    private Text _textRecord;
    private int app = 0;
    private int kni = 0;
    private int recordKni = 0;
    public GameObject MenuCanvas;
    void Start()
    {
        kni = PlayerPrefs.GetInt("AK");
        app = PlayerPrefs.GetInt("Ap");
        recordKni = PlayerPrefs.GetInt("RK");
        _textApples.text = app.ToString();
        _textKnives.text = recordKni.ToString();
        _textRecord.text = "Record".ToString();
        StartCoroutine(MenuCanvasCoroutine());
    }
    public void Play()
    {
        DeleteData();
        Application.LoadLevel(1);
    }
    IEnumerator MenuCanvasCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        MenuCanvas.SetActive(true);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("AK");
        PlayerPrefs.DeleteKey("levelN");
        PlayerPrefs.SetInt("stageN", 1);
        PlayerPrefs.DeleteKey("ad");
    }
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
