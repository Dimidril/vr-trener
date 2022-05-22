using Core.TighteningWheelMechanic;
using UnityEngine;

namespace Core.ConditionSystem.Conditionals
{
    public abstract class WheelRotateConditional: Conditional
    {
        [SerializeField] private WheelValueController _wheelValueController;
        [SerializeField] private float _value;
        
        protected override bool IsDoneCheck()
        {
            return Compare(_wheelValueController.CurrentRotateValue, _value);
        }

        protected abstract bool Compare(float currentValue, float compareValue);
    }
}