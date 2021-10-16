using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUnityEvent : GameEvent
{
    [InfoBox("This Game Event will call a generic Unity Event")]
    [SerializeField] UnityEngine.Events.UnityEvent eventToTrigger;

    public override void TriggerEvent()
    {
        eventToTrigger.Invoke();
    }
}
