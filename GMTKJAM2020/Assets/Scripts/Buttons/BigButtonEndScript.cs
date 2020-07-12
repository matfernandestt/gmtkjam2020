using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BigButtonEndScript : MonoBehaviour
{
    bool isPressed = false;

    void BigOver()
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
