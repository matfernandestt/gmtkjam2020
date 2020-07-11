using UnityEngine;

public class Minigame2 : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private void OnEnable()
    {
        GreenButton.onGreenButtonPress += OnGreenButtonPress;
        RedButton.onRedButtonPress += OnRedButtonPress;
    }

    private void OnDisable()
    {
        GreenButton.onGreenButtonPress -= OnGreenButtonPress;
        RedButton.onRedButtonPress -= OnRedButtonPress;
    }

    private void OnGreenButtonPress()
    {
        car.SetActive(true);
    }

    private void OnRedButtonPress()
    {
        car.SetActive(false);
    }
}
