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

        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(.3f);
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
