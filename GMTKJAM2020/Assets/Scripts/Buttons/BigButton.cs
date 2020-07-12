using System;
using UnityEngine;

public class BigButton : GenericButton
{
    public static Action bigButtonEnd;

    private enum ButtonState { Closed, Opened }

    private ButtonState state = ButtonState.Closed;
    
    private static readonly int ButtonOpening = Animator.StringToHash("ButtonOpening");
    private static readonly int ButtonPress = Animator.StringToHash("ButtonPress");

    protected override void Awake()
    {
        base.Awake();

        onButtonClick += ButtonClick;
        state = ButtonState.Closed;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        
        onButtonClick -= ButtonClick;
    }

    private void ButtonClick()
    {
        switch (state)
        {
            case ButtonState.Closed:
                anim.SetTrigger(ButtonOpening);
                state = ButtonState.Opened;
                break;
            case ButtonState.Opened:
                anim.SetTrigger(ButtonPress);
                bigButtonEnd?.Invoke();
                break;
        }
    }
}
