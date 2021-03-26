using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool flagZone = false;

    public void Update()
    {
        //if(flagZone == true && Input.GetButtonDown("PickUp"))
        /*if(flagZone == true)
        {
            Interact();
        }*/
    }

    public void OnMouseDown()
    {
        Interact();
        Debug.Log("Click");
    }

    // Cuando se acerca a la caldera se escucha el fuego
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flagZone = true;
        }
    }

    // Cuando se aleja de la caldera no se escucha el fuego
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flagZone = false;
        }
    }

    // Agrega un sonido de golpe a la caldera si es que hay un click
    public virtual void Interact()
    {

    }
}
