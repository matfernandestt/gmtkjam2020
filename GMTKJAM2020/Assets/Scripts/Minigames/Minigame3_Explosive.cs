using System;
using System.Collections;
using UnityEngine;

public class Minigame3_Explosive : MonoBehaviour
{
    private Coroutine translationCoroutine;
    
    public void TranslateToPoint(Vector3 point)
    {
        var duration = 30f;
        IEnumerator Translation()
        {
            float progress = 0;
            float step = progress / duration;
            while(step < 1f)
            {
                progress += Time.deltaTime / 100;
                step = progress / duration;
                transform.position = Vector3.Lerp(transform.position, point, step);      
                yield return null;
            }
        }
        translationCoroutine = StartCoroutine(Translation());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DisapwnPoint"))
        {
            if(translationCoroutine != null)
                StopCoroutine(translationCoroutine);
            Destroy(gameObject);
        }
    }
}
