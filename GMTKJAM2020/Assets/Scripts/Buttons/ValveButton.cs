using System;

public class ValveButton : GenericButton
{
    public static Action onValveButtonPress;

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
        onValveButtonPress?.Invoke();
    }
}
