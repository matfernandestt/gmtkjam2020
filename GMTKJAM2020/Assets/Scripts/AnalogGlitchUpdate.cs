using System;
using System.Collections;
using UnityEngine;
using Kino;

public class AnalogGlitchUpdate : MonoBehaviour
{
    [SerializeField] private AnalogGlitch glitch;

    private Coroutine glitchCoroutine;
    
    private void OnEnable()
    {
        StartGlitchingUpdate();
    }

    private void OnDisable()
    {
        if(glitchCoroutine != null)
            StopCoroutine(glitchCoroutine);
    }

    private void StartGlitchingUpdate()
    {
        IEnumerator Glitching()
        {
            bool pong = true;
            while (true)
            {
                if(pong)
                    glitch.scanLineJitter += Time.deltaTime * 2;
                else
                    glitch.scanLineJitter -= Time.deltaTime * 2;
                glitch.scanLineJitter = Mathf.Clamp(glitch.scanLineJitter, 0f , .7f);
                if (glitch.scanLineJitter >= .7f)
                    pong = false;
                if (glitch.scanLineJitter <= 0)
                    pong = true;
                yield return null;
            }
        }
        if(glitchCoroutine != null)
            StopCoroutine(glitchCoroutine);
        glitchCoroutine = StartCoroutine(Glitching());
    }
}
