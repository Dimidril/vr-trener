using System.Collections.Generic;
using System.Linq;
using Core.ConditionSystem;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _conditionalsText;

    private Task _task;
    
    private void Awake()
    {
        _task = FindObjectOfType<Task>();
        //_task.OnTaskComplete.AddListener(SetResultText);
        _conditionalsText.text = null;
    }

    private void SetResultText(List<Conditional> conditionals)
    {
        int doneConditionalCount = 0;
        foreach (var conditional in conditionals)
        {
            if (conditional.IsDone)
                doneConditionalCount++;

            string doneText = conditional.IsDone ? "Выполнено" : "Провалено";
            _conditionalsText.text += $"{conditional.HintTitle}: {doneText} \n";
        }

        _scoreText.text = $"{doneConditionalCount}/{conditionals.Count}";
    }

    public void SetResultText()
    {
        _conditionalsText.text = null;
        SetResultText(_task._conditionals.ToList());
    }
}