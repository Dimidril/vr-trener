using System.Collections.Generic;
using Core.JointMechanic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    /// <summary>
    /// Класс отвечает за выполнение поставленой задачи, отслеживая выполение всех условий
    /// </summary>
    public class Task : MonoBehaviour
    {
        [SerializeField] public Conditional[] _conditionals;
        [SerializeField] private Hint _endTaskHint;
        
        private Queue<Conditional> _conditionalsQueue;
        private Conditional _currentConditional;

        public event UnityAction<Hint> onOnConditionalChange;

        private void Awake()
        {
            Debug.Log(_conditionals.Length);
            _conditionalsQueue = new Queue<Conditional>();
            
            foreach (var conditional in _conditionals)
            {
                _conditionalsQueue.Enqueue(conditional);
            }

            _currentConditional = _conditionalsQueue.Dequeue();
            _currentConditional.OnConditionalDone.AddListener(OnCurrentConditionalDone);
            onOnConditionalChange?.Invoke(_currentConditional.Hint);
        }

        /// <summary>
        /// Вызываеться когда очередое условие выполнено 
        /// </summary>
        /// <param name="result">Результат выполнения условия</param>
        private void OnCurrentConditionalDone(bool result)
        {
            Debug.Log($"{_currentConditional} - DONE {result}");
            _currentConditional.OnConditionalDone.RemoveAllListeners();

            if (_conditionalsQueue.TryDequeue(out _currentConditional))
            {
                _currentConditional.OnConditionalDone.AddListener(OnCurrentConditionalDone);
                onOnConditionalChange?.Invoke(_currentConditional.Hint);
            }
            else
            {
                _currentConditional = null;
                onOnConditionalChange?.Invoke(_endTaskHint);
            }
        }

        /// <summary>
        /// Проверка на то, выполнена ли задача
        /// </summary>
        /// <returns></returns>
        public bool IsTaskComplete()
        {
            foreach (var conditional in _conditionals)
            {
                Debug.Log(conditional.IsDone);
                if (!conditional.IsDone)
                    return false;
            }
            return true;
        }
    }

    public class UnityEventWithResult : UnityEvent<List<Conditional>>
    {
    }
}