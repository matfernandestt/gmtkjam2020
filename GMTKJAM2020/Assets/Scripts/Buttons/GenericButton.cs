using System;
using UnityEngine;

public class GenericButton : MonoBehaviour
{
    protected Action onButtonClick;
    
    [SerializeField] protected Animator anim;
    [SerializeField] protected Renderer rend;
    
    private static readonly int UseButton = Animator.StringToHash("UseButton");
    private static readonly int OutlineProperty = Shader.PropertyToID("_OutlineWidth");

    protected virtual void Awake()
    {
        ObjectDetector.disableAllOutlines += DisableOutline;
    }

    protected virtual void OnDestroy()
    {
        ObjectDetector.disableAllOutlines -= DisableOutline;
    }

    public void ButtonClick()
    {
        anim.SetTrigger(UseButton);
        onButtonClick?.Invoke();
    }

    public void OnHover()
    {
        rend.material.SetFloat(OutlineProperty, 1.2f);
    }

    private void DisableOutline()
    {
        rend.material.SetFloat(OutlineProperty, 1f);
    }
}
