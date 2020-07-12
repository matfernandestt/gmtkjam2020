using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayLoggerScript : MonoBehaviour
{
    public TextMeshProUGUI logText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI perfomanceText;
    public GameObject mark;
    private int currentDay = 0;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        currentDay++;
    //        SetDayLog(currentDay);
    //    }
    //}
    //private void Start()
    //{
    //        SetDayLog(currentDay);
    //}

    public void SetDayLog(int day)
    {
        currentDay = day;
        mark.SetActive(false);

        switch (day)
        {
            case 0:
                logText.text = "F.A.T.E. is looking for a new operator" +
                    "\nApply now!";
                break;

            case 1:
                logText.text = "Welcome to your first day at F.A.T.E. as intership!" +
                    "\nYour job today is to make the cars on the screen crash as much as you can." +
                    "\nThe more cars you crash, higher your perfomance will be." +
                    "\nGood Luck and remember that fate is at our hands!";
                break;

            case 2:
                logText.text ="For the second day, your task is to approve foreign alins to enter earth." +
                    "\n Approve the ones with the mark below." +
                    "\nAnd don't forget your previous tasks! We'll be checking your perfomance!" +
                    "\nGood Luck and remember that fate is at our hands!";

                mark.SetActive(true);
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
        }
                dayText.text = "Day: "+ day;
    }


}
