using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public AudioClip SoundToPlay;

    public AudioClip SoundToPlay2;
    public float Volume;
    AudioSource audio;

    public bool flagZone = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public virtual void Update()
    {
        if(flagZone == true && Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    // Cuando se acerca a la caldera se escucha el fuego
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flagZone = true;
            Debug.Log("Entró");
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

    // Agrega un sonido de golpe a la caldera si es que hay un click
    public virtual void Interact()
    {
        audio.PlayOneShot(SoundToPlay2, Volume);
    }
}
