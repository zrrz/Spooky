using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDestroy : GameEvent
{
    public override void TriggerEvent()
    {
        Destroy(gameObject);
    }
}
