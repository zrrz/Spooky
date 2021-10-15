using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObjects : MonoBehaviour
{
    public LayerMask layerMask;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hit, 100f, layerMask))
        {
            if(Input.GetButton("Fire1"))
            {
                if(hit.transform)
                {
                    Interactable interactable = hit.transform.GetComponent<Interactable>();
                    interactable.Interact();
                }
            }
        }
    }
}
