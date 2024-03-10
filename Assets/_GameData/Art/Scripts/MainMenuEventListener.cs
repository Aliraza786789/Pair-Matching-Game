using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEventListener : MonoBehaviour
{
   
   public void Play()
   {
      ReferenceContainer.VInstance.gameCanvasHandler.StateChange(MenuPanel.Loading);
      ReferenceContainer.VInstance.loadingScreenEventListener.LoadScene("GamePlay");
      if (SoundManager.instance)
      {
         SoundManager.instance.PlayOneTime(SoundName.ButtonClick);
      }

   }
}
