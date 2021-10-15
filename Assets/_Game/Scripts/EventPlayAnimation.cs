using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayAnimation : GameEvent
{
    public string animName;

    public override void TriggerEvent()
    {
        GetComponent<Animator>().Play(animName);
    }
}
