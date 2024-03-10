using System;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public FruitsType fruitsType;
    public MeshRenderer front;
    public MeshRenderer back;
    public Animator myCardAnimator;
    private static readonly int CardFlip = Animator.StringToHash("CardFlip");

    public void OnSelected()
    {
        myCardAnimator.SetBool(CardFlip,true);
    }
    public void DeSelected()
    {
        myCardAnimator.SetBool(CardFlip,false);
        
    }
    public void SetIdentifier(CardScript tempCard, FruitsType _fruitsType, Material[] mMaterial)
    {
        fruitsType = _fruitsType;
        front.material = mMaterial[(int)fruitsType];
    }
}