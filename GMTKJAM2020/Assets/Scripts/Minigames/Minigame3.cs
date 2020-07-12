using System.Collections;
using UnityEngine;

public class Minigame3 : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private Transform barrier;

    private Coroutine transitionCoroutine;

    private void OnEnable()
    {
        YellowButton.onYellowButtonPress += RotateClockwise;
        BlueButton.onBlueButtonPress += RotateAnticlockwise;
    }

    private void OnDisable()
    {
        YellowButton.onYellowButtonPress -= RotateClockwise;
        BlueButton.onBlueButtonPress -= RotateAnticlockwise;
    }

    private void RotateClockwise()
    {
        if(transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);
        transitionCoroutine = StartCoroutine(Rotate(-45f, 1f));
    }

    private void RotateAnticlockwise()
    {
        if(transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);
        transitionCoroutine = StartCoroutine(Rotate(45f, 1f));
    }

    private IEnumerator Rotate(float angle, float duration)
    {
        float progress = 0;
        float step = progress / duration;
        var rotationAngle = Quaternion.Euler(barrier.eulerAngles.x, barrier.eulerAngles.y, barrier.eulerAngles.z  + angle);
        while(step < 1f)
        {
            progress += Time.deltaTime;
            step = progress / duration;
            barrier.rotation = Quaternion.Lerp(barrier.rotation, rotationAngle, step);      
            yield return null;
        }
    }
}
