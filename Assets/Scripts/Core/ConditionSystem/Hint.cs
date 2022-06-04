using UnityEngine;

namespace Core.ConditionSystem
{
    [System.Serializable]
    public struct Hint
    {
        public string Title;
        [TextArea] public string Text;
    }
}