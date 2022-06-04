using System.Collections.Generic;
using Core.JointMechanic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.ConditionSystem
{
    public class Task : MonoBehaviour
    {
        [SerializeField] private Conditional[] _conditionals;
        
        private Queue<Conditional> _conditionalsQueue;
        private Conditional _currentConditional;

        public event UnityAction<Conditional> onOnConditionalChange;

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
            onOnConditionalChange?.Invoke(_currentConditional);
        }

        private void OnCurrentConditionalDone(bool result)
        {
            Debug.Log($"{_currentConditional} - DONE {result}");
            _currentConditional.OnConditionalDone.RemoveAllListeners();

            if (_conditionalsQueue.Peek())
            {
                _currentConditional = _conditionalsQueue.Dequeue();
                _currentConditional.OnConditionalDone.AddListener(OnCurrentConditionalDone);
            }
            else
            {
                _currentConditional = null;
            }
            
            onOnConditionalChange?.Invoke(_currentConditional);
        }

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
}