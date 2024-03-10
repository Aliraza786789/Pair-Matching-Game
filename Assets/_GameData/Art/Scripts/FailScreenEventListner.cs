using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScreenEventListner : MonoBehaviour
{
    public void Restart()
    {
        ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.Loading);
        ReferenceManager.Instance.loadingScreen.LoadScene("GamePlay");
    }
}
