using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDestroy : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
