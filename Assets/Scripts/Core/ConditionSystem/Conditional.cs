using Core.JointMechanic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    public abstract class Conditional: MonoBehaviour
    {
        public UnityEvent OnConditionalDone;

        public abstract bool IsDone();
    }
}