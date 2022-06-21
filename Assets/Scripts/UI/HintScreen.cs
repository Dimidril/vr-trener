using System;
using System.Collections;
using Core.ConditionSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HintScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleContainer;
        [SerializeField] private TMP_Text _textContainer;
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private TMP_Text _timerText;

        private Task _task;
        
        private void Awake()
        {
            _task = FindObjectOfType<Task>();
        }

        private void OnEnable()
        {
            StartCoroutine(TimeTick());
            
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

        /// <summary>
        /// Смена подсказки
        /// </summary>
        /// <param name="hint">Новая подсказка</param>
        private void ChangeHint(Hint hint)
        {
            _titleContainer.text = hint.Title;
            _textContainer.text = hint.Text;
        }

        /// <summary>
        /// Обновление Времени
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimeTick()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                _timerText.text = "s";
                _timeText.text = DateTime.Now.ToShortTimeString();
            }
        }
    }
}