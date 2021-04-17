using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool flagZone = false;

    public bool gazedAt = false;

    public float gazeInteractTime = 1.5f;
    public float gazeTimer = 0;

    public virtual void Update()
    {
        //if(flagZone == true && Input.GetButtonDown("PickUp"))
        /*if(flagZone == true)
        {
            Interact();
        }*/
        if (gazedAt)
        {
            if ((gazeTimer += Time.deltaTime) >= gazeInteractTime)
            {
                Interact();
                gazedAt = false;
                gazeTimer = 0f;
            }
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        if (!gazedAt)
        {
            gazeTimer = 0f;
        }
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

    public virtual void Interact()
    {

    }
}
