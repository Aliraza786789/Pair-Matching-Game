using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanavsHandler : MonoBehaviour
{
    public GamePanel currentState;
    public GamePanel prevState;
    public GameObject[] panelState;

    private void OnEnable()
    {
        StateChange(GamePanel.GamePlayPanel);
    }

    public void StateChange(GamePanel nextState)
    {
        prevState = currentState;
        currentState = nextState;
        panelState[(int)prevState].gameObject.SetActive(false);
        panelState[(int)currentState].gameObject.SetActive(true);
        
    }
}

public enum GamePanel
{
    GamePlayPanel,
    WinPanel,
    LosePanel,
    Loading,
    TheEnd
}