using System;
using System.Collections;
using UnityEngine;

public class Minigame2_TrafficLight : MonoBehaviour
{
    [SerializeField] private CarColor thisColor = CarColor.green;
    [SerializeField] private Minigame2_Car[] cars;
    [SerializeField] private Transform stopPoint;
    [SerializeField] private Transform respawnPoint;

    private void OnEnable()
    {
        for (var i = 0; i < cars.Length; i++)
        {
            cars[i].gameObject.SetActive(true);
            cars[i].getRespawnPoint = respawnPoint;
            cars[i].isLaneStopped = false;
        }
    }

    public void MoveLane()
    {
        IEnumerator Wait()
        {
            for (var i = 0; i < cars.Length; i++)
            {
                cars[i].getRespawnPoint = respawnPoint;
                cars[i].isLaneStopped = false;
                if (cars[i].gameObject.activeSelf)
                {
                    cars[i].MoveCar();
                    yield return new WaitForSeconds(.3f);
                }
            }
        }
        StartCoroutine(Wait());
    }

    public void StopLane()
    {
        for (var i = 0; i < cars.Length; i++)
        {
            cars[i].isLaneStopped = true;
        }
    }
}
