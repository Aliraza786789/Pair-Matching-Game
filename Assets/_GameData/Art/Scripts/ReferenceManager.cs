using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance;
    public MainCanavsHandler gameCanvasHandler;
    public static int CurrentLevel;
    public CardSpawner cardSpawner;
    public static LevelScript LevelScript;
    public LoadingScreenEventListner loadingScreen;
    public GameManager gameManager;
    private void Awake()
    {
        Instance = this;
        CurrentLevel = PrefHandler.Level;
    }
}

public static class PrefHandler
{
    public static int Level
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 0);
        set => PlayerPrefs.SetInt("CurrentLevel", value);
    }
}