using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EventDestroy : GameEvent
{
    [InfoBox("This Game Event will destroy a targeted GameObject")]
    [SerializeField] private GameObject objectToDestroy;

    public override void TriggerEvent()
    {
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        if(objectToDestroy == null)
        {
            objectToDestroy = this.gameObject;
        }
    }
}
