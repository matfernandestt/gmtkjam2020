using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManagerScript : MonoBehaviour
{
    bool isPressed = false;
    private void Awake()
    {
        GreenButton.onGreenButtonPress += Menu;
        RedButton.onRedButtonPress += QuitGame;
        isPressed = false;
        
    }

    private void OnDestroy()
    {
        GreenButton.onGreenButtonPress -= Menu;
        RedButton.onRedButtonPress -= QuitGame;
    }

    private void Menu()
    {
        if (isPressed == true)
            return;

        isPressed = true;

        Fader.FadeIn();
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene("MenuScene");
        }
    }

    private void QuitGame()
    {
        if (isPressed == true)
            return;
        Application.Quit();
    }
}
