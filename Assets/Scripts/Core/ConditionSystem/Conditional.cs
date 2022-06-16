using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    /// <summary>
    /// Класс условия (Эллементарная единица задания)
    /// </summary>
    public class Conditional: MonoBehaviour
    {
        [SerializeField] private Hint _hint;


        public string HintTitle => _hint.Title;
        public string HintText => _hint.Text;
        public bool IsDone { get; protected set; }
        
        public UnityEventBool OnConditionalDone;

        protected void Awake()
        {
            OnConditionalDone.AddListener(OnDone);
        }

        /// <summary>
        /// Вызываеться по выполнению условия
        /// </summary>
        /// <param name="value">результат выполнения условия</param>
        private void OnDone(bool value)
        {
            Debug.Log(value);
            IsDone = value;
        }
    }

    [Serializable]
    public class UnityEventBool : UnityEvent<bool> { }
}