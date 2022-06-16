using UnityEngine;

namespace Core.ConditionSystem
{
    /// <summary>
    /// Структура подсказки
    /// </summary>
    [System.Serializable]
    public struct Hint
    {
        public string Title;
        [TextArea] public string Text;
    }
}