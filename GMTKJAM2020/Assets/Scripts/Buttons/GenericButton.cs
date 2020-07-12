using System;
using UnityEngine;

public class GenericButton : MonoBehaviour
{
    protected Action onButtonClick;
    
    [SerializeField] protected Animator anim;
    [SerializeField] protected Renderer rend;
    
    private static readonly int UseButton = Animator.StringToHash("UseButton");
    private static readonly int OutlineProperty = Shader.PropertyToID("_Outline");

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

        //Play sound
        if (TryGetComponent(out ButtonSoundScript sound))
        {
            sound.PlaySound();
        }
    }

    public void OnHover()
    {
        foreach (var material in rend.materials)
        {
            material.SetFloat(OutlineProperty, .05f);
        }
        //rend.material.SetFloat(OutlineProperty, .05f);
    }

    private void DisableOutline()
    {
        foreach (var material in rend.materials)
        {
            material.SetFloat(OutlineProperty, 0f);
        }
        //rend.material.SetFloat(OutlineProperty, 0f);
    }
}
