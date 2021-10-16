using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnStart : MonoBehaviour
{
    [SerializeField] GameEvent[] events;

    void Start()
    {
        foreach(var gameEvent in events)
        {
            gameEvent.TriggerEvent();
        }
    }
}
