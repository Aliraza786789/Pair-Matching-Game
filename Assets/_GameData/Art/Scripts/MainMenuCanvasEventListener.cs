using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasEventListener : MonoBehaviour
{
    public MenuPanel currentState;
    public MenuPanel prevState;
    public GameObject[] panelState;

    private void OnEnable()
    {
        StateChange(MenuPanel.MainMenu);
    }

    public void StateChange(MenuPanel nextState)
    {
        prevState = currentState;
        currentState = nextState;
        panelState[(int)prevState].gameObject.SetActive(false);
        panelState[(int)currentState].gameObject.SetActive(true);
    }
}

public enum MenuPanel
{
    MainMenu,
    Loading
}