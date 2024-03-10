using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceContainer : MonoBehaviour
{
    public static  ReferenceContainer VInstance;
    public LoadingScreenEventListner loadingScreenEventListener;
    public MainMenuCanvasEventListener gameCanvasHandler;
    
    private void Awake()
    {
        VInstance = this;
    }
    
}
