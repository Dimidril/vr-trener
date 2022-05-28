using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ConditionSystem
{
    public class Task : MonoBehaviour
    {
        [SerializeField] private Conditional[] _conditionals;
        
        private Queue<Conditional> _conditionalsQueue;
        private Conditional _currentConditional;

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
        }

        private void OnCurrentConditionalDone(bool result)
        {
            _currentConditional.OnConditionalDone.RemoveAllListeners();
            _currentConditional = _conditionalsQueue.Dequeue();
            _currentConditional.OnConditionalDone.AddListener(OnCurrentConditionalDone);
        }

        public bool IsTaskComplete()
        {
            foreach (var conditional in _conditionals)
            {
                if (!conditional.IsDone)
                    return false;
            }
            return true;
        }
    }
}