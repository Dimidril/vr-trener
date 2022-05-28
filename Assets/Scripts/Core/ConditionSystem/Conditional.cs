using System;
using Core.JointMechanic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    public class Conditional: MonoBehaviour
    {
        public bool IsDone { get; protected set; }

        public UnityEventBool OnConditionalDone;

        protected void Awake()
        {
            OnConditionalDone.AddListener(OnDone);
        }

        private void OnDone(bool value)
        {
            Debug.Log(value);
            IsDone = value;
        }
    }

    [Serializable]
    public class UnityEventBool : UnityEvent<bool> { }
}