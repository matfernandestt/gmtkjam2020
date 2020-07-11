using System;

public class BlueButton : GenericButton
{
    public static Action onBlueButtonPress;

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
        onBlueButtonPress?.Invoke();
    }
}