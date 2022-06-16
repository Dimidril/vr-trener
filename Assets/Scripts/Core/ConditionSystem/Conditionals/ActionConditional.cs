using UnityEngine;
using Zinnia.Action;

namespace Core.ConditionSystem.Conditionals
{
    /// <summary>
    /// Условия выполнения события
    /// </summary>
    public class ActionConditional: Conditional
    {
        [SerializeField] private BooleanAction _event;

        private new void Awake()
        {
            base.Awake();
            _event.Activated.AddListener(EventInvoked);
        }

        /// <summary>
        /// Вызываеться когда определённое событие выполненно
        /// </summary>
        /// <param name="value">Результат выполнения события</param>
        private void EventInvoked(bool value)
        {
            OnConditionalDone.Invoke(value);
            Debug.Log($"{gameObject.name} - {value} {IsDone}");
        }
    }
}