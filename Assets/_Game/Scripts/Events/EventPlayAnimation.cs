using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayAnimation : GameEvent
{
    [InfoBox("This Game Event will play animName on target Animator")]
    [SerializeField] private string animName;

    [SerializeField] private Animator animator;

    public override void TriggerEvent()
    {
        animator.Play(animName);
    }

    private void OnValidate()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
}
