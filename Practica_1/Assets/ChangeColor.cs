using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : Interactable
{
    public Material inactiveMaterial;

    public Material gazedAtMaterial;

    private Renderer myRenderer;

    public GameObject Object;

    public void SetGazedAtColor(bool isGazedAt)
    {
        if(inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = isGazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }
    
    private void Start() {
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }

    public override void Interact()
    {
        myRenderer.material.color = Color.yellow;
        Debug.Log("Selected");
    }

    public override void Update()
    {
        base.Update();
    }
}