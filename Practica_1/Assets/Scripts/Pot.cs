using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public AudioClip SoundToPlay2;
    public float Volume;
    AudioSource audio;
    public bool flagZone = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(flagZone == true && Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(SoundToPlay2, Volume);
        }
    }

    // Cuando se acerca a la caldera se escucha el fuego
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audio.PlayOneShot(SoundToPlay, Volume);
        }
    }

    // Cuando se aleja de la caldera no se escucha el fuego
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flagZone = false;
            audio.Stop();
        }
    }
}
