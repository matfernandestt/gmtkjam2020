using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private static Fader i;

    [SerializeField] private Image imgFade;

    private Coroutine transitionCoroutine;

    private void Awake()
    {
        i = this;
    }

    public static void FadeIn()
    {
        var duration = 1f;
        if(i.transitionCoroutine != null)
            i.StopCoroutine(i.transitionCoroutine);
        i.imgFade.color = new Color(i.imgFade.color.r, i.imgFade.color.g, i.imgFade.color.b, 0f);
        IEnumerator Fade(float alpha)
        {
            float progress = 0;
            float step = progress / duration;
            while(step < 1f)
            {
                progress += Time.deltaTime;
                step = progress / duration;
                var c = new Color(i.imgFade.color.r, i.imgFade.color.g, i.imgFade.color.b, alpha);
                i.imgFade.color = Color.Lerp(i.imgFade.color, c, step);      
                yield return null;
            }
        }
        if(i.transitionCoroutine != null)
            i.StopCoroutine(i.transitionCoroutine);
        i.transitionCoroutine = i.StartCoroutine(Fade(1f));
    }

    public static void FadeOut()
    {
        var duration = 1f;
        if(i.transitionCoroutine != null)
            i.StopCoroutine(i.transitionCoroutine);
        i.imgFade.color = new Color(i.imgFade.color.r, i.imgFade.color.g, i.imgFade.color.b, 1f);
        IEnumerator Fade(float alpha)
        {
            float progress = 0;
            float step = progress / duration;
            while(step < 1f)
            {
                progress += Time.deltaTime;
                step = progress / duration;
                var c = new Color(i.imgFade.color.r, i.imgFade.color.g, i.imgFade.color.b, alpha);
                i.imgFade.color = Color.Lerp(i.imgFade.color, c, step);      
                yield return null;
            }
        }
        if(i.transitionCoroutine != null)
            i.StopCoroutine(i.transitionCoroutine);
        i.transitionCoroutine = i.StartCoroutine(Fade(0f));
    }
}
