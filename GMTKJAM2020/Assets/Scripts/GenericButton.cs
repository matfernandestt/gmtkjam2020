using System;
using UnityEngine;

public class GenericButton : MonoBehaviour
{
    protected Action onButtonClick;
    
    [SerializeField] protected Animator anim;
    
    private static readonly int UseButton = Animator.StringToHash("UseButton");

    public void ButtonClick()
    {
        Debug.Log("click");
        anim.SetTrigger(UseButton);
        onButtonClick?.Invoke();
    }
}
