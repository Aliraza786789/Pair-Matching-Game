using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelScript[] allLevelObject;

    private void Start()
    {
        foreach (var level in allLevelObject)
        {
            level.gameObject.SetActive(false);
        }

     
        allLevelObject[ReferenceManager.CurrentLevel].gameObject.SetActive(true);
        
    }
}