using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManagerScript : MonoBehaviour
{
    bool isPressed = false;
    public GameObject yesImage;
    public GameObject noImage;

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

    public void SetEndGame(int i)
    {
        if (i == 0)
        {
            yesImage.SetActive(true);
            noImage.SetActive(false);
        }
        else
        {
            noImage.SetActive(true);
            yesImage.SetActive(false);
        }
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
