using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPair;
    public int pairMatched;

    public void WinCheck()
    {
        pairMatched++;
        if (pairMatched >= totalPair)
        {
            ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.WinPanel);
        }
    }
}