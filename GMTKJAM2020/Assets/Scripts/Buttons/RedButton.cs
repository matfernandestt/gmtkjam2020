using System;

public class RedButton : GenericButton
{
    public static Action onRedButtonPress;

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
        onRedButtonPress?.Invoke();
    }
}