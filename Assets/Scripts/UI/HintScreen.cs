using System;
using Core.ConditionSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HintScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleContainer;
        [SerializeField] private TMP_Text _textContainer;

        private Task _task;
        
        private void Awake()
        {
            _task = FindObjectOfType<Task>();
        }

        private void OnEnable()
        {
            if (_task)
            {
                _task.onOnConditionalChange += ChangeHint;
            }
        }

        private void OnDisable()
        {
            if (_task)
            {
                _task.onOnConditionalChange -= ChangeHint;
            }
        }

        private void ChangeHint(Conditional conditional)
        {
            _titleContainer.text = conditional.HintTitle;
            _textContainer.text = conditional.HintText;
        }
    }
}