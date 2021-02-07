using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameUI))]
[RequireComponent(typeof(LogDisplay))]
[RequireComponent(typeof(LogDestroy))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(LevelsScript))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int knifeCount;
    public GameUI GameUI { get; private set; }
    public LogDisplay LogDisplay { get; private set; }
    public LogDestroy LogDestroy { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public LevelsScript LevelsScript { get; private set; }

    void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
        LogDisplay = GetComponent<LogDisplay>();
        LogDestroy = GetComponent<LogDestroy>();
        AudioManager = GetComponent<AudioManager>();
        LevelsScript = GetComponent<LevelsScript>();
    }
    void Start()
    {
        knifeCount = GetComponent<LogDisplay>().goal;
        GameUI.KnivesCount(knifeCount);
    }
}
