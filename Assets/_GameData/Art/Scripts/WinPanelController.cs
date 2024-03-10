using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelController : MonoBehaviour
{
    public void Next()
    {
        if (PrefHandler.Level <= 2)
        {
            PrefHandler.Level++;
            ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.Loading);
            ReferenceManager.Instance.loadingScreen.LoadScene("GamePlay");
        }
        else
        {
            ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.TheEnd);
        }
        if (SoundManager.instance)
        {
            SoundManager.instance.PlayOneTime(SoundName.ButtonClick);
        }

    }
}