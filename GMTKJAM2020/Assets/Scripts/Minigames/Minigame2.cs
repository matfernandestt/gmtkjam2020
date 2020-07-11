using System.Collections;
using UnityEngine;

public enum CarColor
{
    green,
    red,
    blue,
    yellow
}

public class Minigame2 : MonoBehaviour
{
    [SerializeField] private Minigame2_TrafficLight redLight;
    [SerializeField] private Minigame2_TrafficLight blueLight;
    [SerializeField] private Minigame2_TrafficLight yellowLight;
    [SerializeField] private Minigame2_TrafficLight greenLight;

    private void OnEnable()
    {
        GreenButton.onGreenButtonPress += OnGreenButtonPress;
        RedButton.onRedButtonPress += OnRedButtonPress;
        YellowButton.onYellowButtonPress += OnYellowButtonPress;
        BlueButton.onBlueButtonPress += OnBlueButtonPress;
    }

    private void OnDisable()
    {
        GreenButton.onGreenButtonPress -= OnGreenButtonPress;
        RedButton.onRedButtonPress -= OnRedButtonPress;
        YellowButton.onYellowButtonPress -= OnYellowButtonPress;
        BlueButton.onBlueButtonPress -= OnBlueButtonPress;
    }

    private void OnGreenButtonPress()
    {
        greenLight.MoveLane();

        IEnumerator WaitToStop()
        {
            yield return new WaitForSeconds(3f);
            greenLight.StopLane();
        }
        StartCoroutine(WaitToStop());
    }

    private void OnRedButtonPress()
    {
        redLight.MoveLane();

        IEnumerator WaitToStop()
        {
            yield return new WaitForSeconds(3f);
            redLight.StopLane();
        }
        StartCoroutine(WaitToStop());
    }
    
    private void OnYellowButtonPress()
    {
        yellowLight.MoveLane();

        IEnumerator WaitToStop()
        {
            yield return new WaitForSeconds(3f);
            yellowLight.StopLane();
        }
        StartCoroutine(WaitToStop());
    }
    
    private void OnBlueButtonPress()
    {
        blueLight.MoveLane();

        IEnumerator WaitToStop()
        {
            yield return new WaitForSeconds(3f);
            blueLight.StopLane();
        }
        StartCoroutine(WaitToStop());
    }
}
