using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDelayEvent : GameEvent
{
    [InfoBox("This Game Event will call another Game Event after a delay")]
    [SerializeField] float delay;
    [SerializeField] GameEvent gameEvent;

    public override void TriggerEvent()
    {
        Invoke(nameof(CallDelayedEvent), delay);
    }

    private void CallDelayedEvent()
    {
        gameEvent.TriggerEvent();
    }
}
