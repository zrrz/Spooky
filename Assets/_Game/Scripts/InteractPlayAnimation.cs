using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayAnimation : MonoBehaviour, Interactable
{
    public string animName;

    public void Interact()
    {
        GetComponent<Animator>().Play(animName);
    }
}
