using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{
    //public Interactable interactableObject;
    public Animator animation; 
    private VirtualButtonBehaviour virtualButton;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //interactableObject.Interact();
        animation.Play("Animation");
        Debug.Log("Se presionó");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        animation.Play("None");
        Debug.Log("Se levantó");
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        virtualButton = GetComponent<VirtualButtonBehaviour>();
        animation.GetComponent<Animator>();
    }

    void Start()
    {
        if (virtualButton != null)
        {
            virtualButton.RegisterEventHandler(this);
        }
    }
}


