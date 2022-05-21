using UnityEngine;

namespace Core.ConditionSystem
{
    public class Task : MonoBehaviour
    {
        [SerializeField] private Conditional[] _conditionals;

        public bool IsTaskComplete()
        {
            foreach (var conditional in _conditionals)
            {
                if (!conditional.IsDone())
                    return false;
            }
            return true;
        }
    }
}