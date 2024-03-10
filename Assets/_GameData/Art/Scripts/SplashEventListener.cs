using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SplashEventListener : MonoBehaviour
{
   public LoadingScreenEventListner loadingScreenEventListener;

   private void OnEnable()
   {
     Invoke(nameof(Loading),2f);
   }
   private void Loading()
   {
      loadingScreenEventListener.LoadScene("MainMenu");  
   }
   
}
