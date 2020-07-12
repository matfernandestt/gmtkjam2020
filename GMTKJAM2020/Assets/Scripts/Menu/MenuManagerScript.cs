using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    bool isPressed = false;

    private void Awake()
    {
        GreenButton.onGreenButtonPress += StartGame;
        RedButton.onRedButtonPress += QuitGame;
        isPressed = false;
        PlayerPrefs.SetInt("CurrentDay", 0);
    }

    private void OnDestroy()
    {
        GreenButton.onGreenButtonPress -= StartGame;
        RedButton.onRedButtonPress -= QuitGame;
    }

    private void StartGame()
    {
        if (isPressed == true)
            return;

        isPressed = true;

        Fader.FadeIn();
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene("GameScene");
        }
    }

    private void QuitGame()
    {
        if (isPressed == true)
            return;
        Application.Quit();
    }
}
