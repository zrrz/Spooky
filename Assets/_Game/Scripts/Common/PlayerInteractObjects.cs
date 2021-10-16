using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObjects : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float interactRange = 3f;

    private Outline highlighted = null;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hit, interactRange, layerMask))
        {
            var outline = hit.collider.GetComponent<Outline>();
            if (outline != null && outline != highlighted)
            {
                UpdateHighlighted(outline);
            }
            if(Input.GetButton("Fire1"))
            {
                if(hit.transform)
                {
                    GameEvent gameEvent = hit.transform.GetComponent<GameEvent>();
                    gameEvent.TriggerEvent();
                }
            }
        }
        else
        {
            if(highlighted)
            {
                UpdateHighlighted(null);
            }
        }
    }

    private void UpdateHighlighted(Outline newHighlighted)
    {
        print("Updated highlight");
        if(highlighted != null)
        {
            highlighted.enabled = false;
        }
        highlighted = newHighlighted;
        if(highlighted)
        {
            highlighted.enabled = true;
        }
    }
}
