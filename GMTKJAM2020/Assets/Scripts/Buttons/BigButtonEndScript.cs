using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BigButtonEndScript : MonoBehaviour
{
    private bool isPressed = false;

    private void Awake()
    {
        BigButton.bigButtonEnd += BigOver;
    }

    private void OnDestroy()
    {
        BigButton.bigButtonEnd -= BigOver;
    }

    private void BigOver()
    {
        if (isPressed == true)
            return;

        isPressed = true;
        Fader.FadeIn();
        StartCoroutine(Wait());
        PlayerPrefs.SetInt("EndgameId", 2);
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
