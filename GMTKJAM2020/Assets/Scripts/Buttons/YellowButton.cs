using System;

public class YellowButton : GenericButton
{
    public static Action onYellowButtonPress;

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
        onYellowButtonPress?.Invoke();
    }
}