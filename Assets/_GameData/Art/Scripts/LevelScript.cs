using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 offSets;
    public Vector3 pictureScale;
    public Vector2 rowsAndColumns;

    private void OnEnable()
    {
        ReferenceManager.LevelScript = this;
        ReferenceManager.Instance.cardSpawner.startPos = startPos;
        ReferenceManager.Instance.cardSpawner.offSet = offSets;
        ReferenceManager.Instance.cardSpawner.rowsAndColumns = rowsAndColumns;
        ReferenceManager.Instance.cardSpawner.Initialize();
    }
}