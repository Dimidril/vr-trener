using System;
using Core.ConditionSystem;
using Tilia.Interactions.Controllables.AngularDriver;
using Tilia.Interactions.SpatialButtons;
using UnityEngine;
using Zinnia.Data.Type;

namespace UI
{
    public class DoneButton : MonoBehaviour
    {
        [SerializeField] private Task _task;
        [SerializeField] private SpatialButtonFacade _buttonFacade;

        private void OnValidate()
        {
            _buttonFacade = GetComponent<SpatialButtonFacade>();
        }

        private void Awake()
        {
            _buttonFacade.Activated.AddListener(Done);
        }

        private void Done(SurfaceData data)
        {
            Debug.Log(_task.IsTaskComplete());
        }
    }
}