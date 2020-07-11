using System;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Minigame2_Car : MonoBehaviour
{
    public bool isLaneStopped;
    public Transform getRespawnPoint;
    
    [SerializeField] private CarColor carColor;

    private Coroutine movementCoroutine;
    private Coroutine patiencecoroutine;

    public CarColor color => carColor;
    
    private void OnEnable()
    {
        //StopCar();
    }

    private void StopCar()
    {
        if(movementCoroutine != null)
            StopCoroutine(movementCoroutine);
        
        /*IEnumerator Patience()
        {
            yield return new WaitForSeconds(7f);
            MoveCar();
        }
        if(patiencecoroutine != null)
            StopCoroutine(patiencecoroutine);
        patiencecoroutine = StartCoroutine(Patience());*/
    }
    
    public void MoveCar()
    {
        if(patiencecoroutine != null)
            StopCoroutine(patiencecoroutine);
        if(movementCoroutine != null)
            StopCoroutine(movementCoroutine);
        if(gameObject.activeSelf)
            movementCoroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            transform.Translate(transform.forward * 10f * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DisapwnPoint"))
        {
            if (getRespawnPoint != null)
                transform.position = getRespawnPoint.position;
        }

        if (isLaneStopped)
        {
            if (other.CompareTag("StopPoint"))
            {
                StopCar();
            }
        }
        
        var car = other.GetComponent<Minigame2_Car>();
        if (car != null)
        {
            if (car.color != color)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}