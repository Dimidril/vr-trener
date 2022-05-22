using Core.JointMechanic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    public abstract class Conditional: MonoBehaviour
    {
        public bool IsDone => IsDoneCheck(); 
        
        public UnityEvent OnConditionalDone;

        protected abstract bool IsDoneCheck();
    }
}