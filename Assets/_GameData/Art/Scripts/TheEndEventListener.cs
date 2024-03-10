using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndEventListener : MonoBehaviour
{
    public void TheEnd()
    {
       Invoke(nameof(InvokeEND),2F);
    }

    public void InvokeEND()
    {
        ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.Loading);

        ReferenceManager.Instance.loadingScreen.LoadScene("MainMenu");
    }
}
