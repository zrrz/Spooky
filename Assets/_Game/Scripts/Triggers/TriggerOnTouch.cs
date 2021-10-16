using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnTouch : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] GameEvent[] events;

    private void OnTriggerEnter(Collider other)
    {
        if ((triggerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            foreach (var gameEvent in events)
            {
                gameEvent.TriggerEvent();
            }
        }
    }
}
