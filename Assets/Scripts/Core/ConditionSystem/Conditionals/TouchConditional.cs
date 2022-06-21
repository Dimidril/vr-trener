using System.Collections;
using System.Collections.Generic;
using Core.ConditionSystem;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Interactables.Interactors;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TouchConditional : Conditional
{
    [SerializeField] private InteractableFacade _interactable;
    
    private new void Awake()
    {
        base.Awake();
        _interactable.Touched.AddListener(EventInvoked);
    }

    /// <summary>
    /// Вызываеться когда определённое событие выполненно
    /// </summary>
    /// <param name="value">Результат выполнения события</param>
    private void EventInvoked(InteractorFacade arg0)
    {
        OnConditionalDone.Invoke(true);
        Debug.Log($"{gameObject.name} - {true} {IsDone}");
    }
}