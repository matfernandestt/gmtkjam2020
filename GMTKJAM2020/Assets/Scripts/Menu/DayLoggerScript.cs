using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayLoggerScript : MonoBehaviour
{

    [Header("UI Elements")]
    public TextMeshProUGUI logText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI perfomanceText;
    public GameObject mark;

    [Header("Timers for each day")]
    public float day1Timer;
    public float day2Timer;
    public float day3Timer;
    public float day4Timer;

    [Header("Mini Games and Screens")]
    public GameObject minigame1;
    public GameObject minigame2;
    public GameObject minigame3;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;

    private int currentDay = 0;
    private float timeLeft;
    private bool inTimer = false;

    private bool pressedButton;

    private Coroutine dayCoroutine;
    private Coroutine timerCoroutine;
    
    private void Awake()
    {
        currentDay = PlayerPrefs.GetInt("CurrentDay");

        StartingButton.onStartingButtonPress += OnUpdateTimer;
    }

    private void OnDestroy()
    {
        StartingButton.onStartingButtonPress -= OnUpdateTimer;
        
        if(dayCoroutine != null)
            StopCoroutine(dayCoroutine);
        if(timerCoroutine != null)
            StopCoroutine(timerCoroutine);
    }

    private void Start()
    {
        minigame1.SetActive(false);
        screen1.SetActive(false);
        minigame2.SetActive(false);
        screen2.SetActive(false);
        minigame3.SetActive(false);
        screen3.SetActive(false);
        SetDayLog();
    }

    private void OnUpdateTimer()
    {
        if (pressedButton) return;
        pressedButton = true;
        switch (currentDay)
        {
            case 1:
                if(dayCoroutine != null)
                    StopCoroutine(dayCoroutine);
                dayCoroutine = StartCoroutine(NexDay(day1Timer));
                minigame1.SetActive(true);
                screen1.SetActive(true);
                break;
            case 2:
                if(dayCoroutine != null)
                    StopCoroutine(dayCoroutine);
                dayCoroutine = StartCoroutine(NexDay(day2Timer));
                mark.SetActive(true);
                minigame1.SetActive(true);
                screen1.SetActive(true);
                minigame2.SetActive(true);
                screen2.SetActive(true);
                break;
            case 3:
                if(dayCoroutine != null)
                    StopCoroutine(dayCoroutine);
                dayCoroutine = StartCoroutine(NexDay(day3Timer));
                minigame1.SetActive(true);
                screen1.SetActive(true);
                minigame2.SetActive(true);
                screen2.SetActive(true);
                minigame3.SetActive(true);
                screen3.SetActive(true);
                break;
            case 4:
                if(dayCoroutine != null)
                    StopCoroutine(dayCoroutine);
                dayCoroutine = StartCoroutine(NexDay(day4Timer));
                minigame1.SetActive(true);
                screen1.SetActive(true);
                minigame2.SetActive(true);
                screen2.SetActive(true);
                minigame3.SetActive(true);
                screen3.SetActive(true);
                break;
        }
    }
    
    public void SetDayLog()
    {
        currentDay++;
        PlayerPrefs.SetInt("CurrentDay", currentDay);
        mark.SetActive(false);
        //Fader.FadeOut();

        switch (currentDay)
        {
            case 0:
                logText.text = "F.A.T.E. is looking for a new operator" +
                    "\nApply now!";
                break;
            case 1:
                logText.text = "Welcome to your first day at F.A.T.E. as intership!" +
                    "\nYour job today is to make the cars on the screen crash as much as you can." +
                    "\nThe more cars you crash, higher your perfomance will be." +
                    "\n Whatever happens DO NOT press the big red button!" +
                    "\nGood Luck and remember that fate is at our hands!";
                break;
            case 2:
                logText.text ="For the second day, your task is to approve foreign alins to enter earth." +
                    "\n Approve the ones with the mark below." +
                    "\nAnd don't forget your previous tasks! We'll be checking your perfomance!" +
                    "\nGood Luck and remember that fate is at our hands!";
                break;
            case 3:
                logText.text = "We reached the third day mark." +
                    "\nToday you'll have to let the nukes hit the earth." +
                    "\nDon't worry, it's just a simulation of course!" +
                    "\nAnd don't forget your previous tasks! We'll be checking your perfomance!" +
                    "\nGood Luck and remember that fate is at our hands!";
                break;
            case 4:
                logText.text = "Contratulations for reaching the last day of the intership!" +
                    "\nToday we'll be simulating a real experience as a operator at F.A.T.E." +
                    "\nDon't worry if things gets out of control, that's super normal!" +
                    "\nWe'll be checking your perfomance!" +
                    "\nGood Luck and remember that fate is at our hands!";
                break;
            case 5: //End Game
                SceneManager.LoadScene("GameOverScene");
                break;
        }
        dayText.text = "Day: "+ currentDay;
    }

    private IEnumerator NexDay(float timer)
    {
        timeLeft = timer;
        inTimer = true;
        if(timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        timerCoroutine =StartCoroutine(UpdateTimer());
        yield return new WaitForSeconds(timer);
        inTimer = false;
        timeText.text = "Time Left: 00:00";
        //Fader.FadeIn();
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene("GameScene"); // reloads the scene for next day
    }

    private IEnumerator UpdateTimer()
    {
        while (inTimer == true)
        {
            var bMin = Mathf.FloorToInt(timeLeft / 60);
            var bSec = Mathf.FloorToInt(timeLeft % 60);
            timeText.text = "Time Left: " + bMin.ToString("00") + ":" + bSec.ToString("00");
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }
    }
}
