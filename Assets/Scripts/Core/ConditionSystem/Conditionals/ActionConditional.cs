using UnityEngine;
using Zinnia.Action;

namespace Core.ConditionSystem.Conditionals
{
    public class ActionConditional: Conditional
    {
        [SerializeField] private BooleanAction _event;

        private new void Awake()
        {
            base.Awake();
            _event.Activated.AddListener(EventInvoked);
        }

        private void EventInvoked(bool value)
        {
            OnConditionalDone.Invoke(value);
            Debug.Log($"{gameObject.name} - {value} {IsDone}");
        }
    }
}