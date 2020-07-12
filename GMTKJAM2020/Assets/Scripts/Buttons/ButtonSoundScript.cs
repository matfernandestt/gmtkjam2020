using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip clip;
    public void PlaySound()
    {
        audioS.clip = clip;
        audioS.pitch = Random.Range(.95f, 1.1f);
        audioS.Play();
    }
}
