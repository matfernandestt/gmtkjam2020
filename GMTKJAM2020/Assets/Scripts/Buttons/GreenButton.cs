using System;

public class GreenButton : GenericButton
{
    public static Action onGreenButtonPress;

    protected override void Awake()
    {
        base.Awake();
        
        onButtonClick += OnButtonPress;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        
        onButtonClick -= OnButtonPress;
    }

    private void OnButtonPress()
    {
        onGreenButtonPress?.Invoke();
    }
}
