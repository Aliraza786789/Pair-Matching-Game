using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public LayerMask selectableObjectsLayer;
    public float delayBeforeHidingNonMatchingPairs = .2f;

    private CardScript firstSelectedObject;
    private CardScript secondSelectedObject;
    public Camera mainCam;

    public Text level;

    private void OnEnable()
    {
        level.text = "LEVEL NO " + (PrefHandler.Level + 1);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, selectableObjectsLayer))
            {
                hit.collider.gameObject.TryGetComponent(out CardScript cardScript);

                SelectObject(cardScript);
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
        if (SoundManager.instance)
        {
            SoundManager.instance.PlayOneTime(SoundName.ButtonClick);
        }

    }

    public void Restart()
    {
        ReferenceManager.Instance.gameCanvasHandler.StateChange(GamePanel.Loading);
        ReferenceManager.Instance.loadingScreen.LoadScene("GamePlay");
        if (SoundManager.instance)
        {
            SoundManager.instance.PlayOneTime(SoundName.ButtonClick);
        }

    }

    private void SelectObject(CardScript selectedObject)
    {
        if (!selectedObject || selectedObject == firstSelectedObject || selectedObject == secondSelectedObject)
            return;

        if (!firstSelectedObject)
        {
            firstSelectedObject = selectedObject;
            firstSelectedObject.OnSelected();
            if (SoundManager.instance)
            {
                SoundManager.instance.PlayOneTime(SoundName.CardSet);
            }
        }
        else if (!secondSelectedObject)
        {
            secondSelectedObject = selectedObject;
            secondSelectedObject.OnSelected();
            if (SoundManager.instance)
            {
                SoundManager.instance.PlayOneTime(SoundName.CardSet);
            }
            CheckPairMatch();
        }
       
    }

    private void CheckPairMatch()
    {
        if (firstSelectedObject.fruitsType.Equals(secondSelectedObject.fruitsType))
        {
            StartCoroutine(OnPairMatched());
            

        }
        else
        {
            StartCoroutine(HideNonMatchingPairs());
         
            
        }
    }

    public Transform moveTowardsPosition;

    private IEnumerator MoveToPosition(Vector3 target, CardScript card)
    {
        if (card)
        {
            while (card.transform.position != target)
            {
                card.transform.position =
                    Vector3.MoveTowards(card.transform.position, target, 250 * Time.deltaTime);
                print("I AM WORKING");
                yield return null;
            }
            card.gameObject.SetActive(false);
        }
    }

    private IEnumerator OnPairMatched()
    {
        
        yield return new WaitForSeconds(delayBeforeHidingNonMatchingPairs);
        Vector3 position = moveTowardsPosition.transform.position;
        var temp1 = firstSelectedObject;
        var temp2 = secondSelectedObject;
        StartCoroutine(MoveToPosition(position, temp1));
        StartCoroutine(MoveToPosition(position, temp2));
        if (SoundManager.instance)
        {
            SoundManager.instance.PlayOneTime(SoundName.Matched);
        }
       
        
       
        firstSelectedObject = null;
        secondSelectedObject = null;
        yield return new WaitForSeconds(delayBeforeHidingNonMatchingPairs);

        ReferenceManager.Instance.gameManager.WinCheck();
        yield return new WaitForSeconds(0);
    }

    public void NotMatched()
    {
        firstSelectedObject.DeSelected();
        secondSelectedObject.DeSelected();
        firstSelectedObject = null;
        secondSelectedObject = null;
        if (SoundManager.instance)
        {
            SoundManager.instance.PlayOneTime(SoundName.MissMatched);
        }
    }

    private IEnumerator HideNonMatchingPairs()
    {
        yield return new WaitForSeconds(delayBeforeHidingNonMatchingPairs);
        NotMatched();
    }
}