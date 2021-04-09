using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject pikachuButton;
    public Animator pikachuAnimation;

    // Start is called before the first frame update
    void Start()
    {
        pikachuButton = GameObject.Find("PikachuButton");
        pikachuButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        pikachuAnimation.GetComponent<Animator>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        pikachuAnimation.Play("PikachuAnimation");
        Debug.Log("Btn pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        pikachuAnimation.Play("None");
        Debug.Log("Btn released");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
