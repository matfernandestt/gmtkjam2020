using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverManagerScript : MonoBehaviour
{
    bool isPressed = false;
    public GameObject yesImage;
    public GameObject noImage;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI performanceText;

    private void Awake()
    {
        GreenButton.onGreenButtonPress += Menu;
        RedButton.onRedButtonPress += QuitGame;
        isPressed = false;

        if (PlayerPrefs.HasKey("EndgameId"))
        {
            SetEndGame(PlayerPrefs.GetInt("EndgameId"));
        }
        else
        {
            PlayerPrefs.SetInt("EndgameId",0);
            SetEndGame(PlayerPrefs.GetInt("EndgameId"));

        }
    }

    private void OnDestroy()
    {
        GreenButton.onGreenButtonPress -= Menu;
        RedButton.onRedButtonPress -= QuitGame;
    }

    public void SetEndGame(int i)
    {
        switch (i)
        {
            case 0:
                yesImage.SetActive(true);
                noImage.SetActive(false);
                messageText.text = "Thanks for playing!";
                break;
            case 1:
                noImage.SetActive(true);
                yesImage.SetActive(false);
                messageText.text = "Thanks for playing!";

                break;
            case 2:
                noImage.SetActive(true);
                yesImage.SetActive(false);
                messageText.text = "We told you to not press that button!";
                break;

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
