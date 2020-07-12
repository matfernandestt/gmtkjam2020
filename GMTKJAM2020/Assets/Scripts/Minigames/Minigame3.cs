using System.Collections;
using UnityEngine;

public class Minigame3 : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private Transform barrier;
    [SerializeField] private Minigame3_Explosive explosiveBase;

    private Coroutine transitionCoroutine;

    private void OnEnable()
    {
        ValveButton.onValveButtonPress += RotateClockwise;
        Valve2Button.onValveButtonPress += RotateAnticlockwise;
        
        GenerateExplosive();
    }

    private void OnDisable()
    {
        ValveButton.onValveButtonPress -= RotateClockwise;
        Valve2Button.onValveButtonPress -= RotateAnticlockwise;
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

    private void GenerateExplosive()
    {
        IEnumerator Delay()
        {
            for (var i = 0; i < 10; i++)
            {
                Vector3 pos = Random.insideUnitCircle * 50;
                pos += transform.position;
                pos.z = barrier.transform.position.z;

                var obj = Instantiate(explosiveBase);
                obj.transform.position = pos;
                obj.TranslateToPoint(planet.transform.position);
                yield return new WaitForSeconds(.5f);
            }
        }
        StartCoroutine(Delay());
    }
}