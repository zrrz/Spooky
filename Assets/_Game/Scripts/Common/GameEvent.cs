using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
[ExecuteInEditMode]
public abstract class GameEvent : MonoBehaviour
{
    abstract public void TriggerEvent();

    [HideLabel]
    [InfoBox("Only have one GameEvent per GameObject", InfoMessageType.Error, "CheckMultipleGameEvents")]
    [InfoBox("This object should be on the Interactable layer", InfoMessageType.Error, "CheckInteractiveLayer")]
    [ShowInInspector]
    private bool ignoreMe;

#if UNITY_EDITOR
    private bool CheckInteractiveLayer()
    {
        return gameObject.layer != LayerMask.NameToLayer("Interactable");
    }

    private bool CheckMultipleGameEvents()
    {
        return GetComponents<GameEvent>().Length > 1;
    }

    private void FixObjectName()
    {
        if (gameObject.name != GetType().ToString())
        {
            gameObject.name = GetType().ToString();
        }
    }

    private void ValidateEventData()
    {
        CheckMultipleGameEvents();
        FixObjectName();
    }

    private void Reset()
    {
        ValidateEventData();
    }

    private void OnValidate()
    {
        ValidateEventData();
    }

    //private void OnDestroy()
    //{
    //    foreach(var gameEvent in GetComponents<GameEvent>())
    //    {
    //        gameEvent.enabled = false;
    //        gameEvent.enabled = true;
    //        gameEvent.ValidateEventData();
    //    }
    //}
#endif
}
