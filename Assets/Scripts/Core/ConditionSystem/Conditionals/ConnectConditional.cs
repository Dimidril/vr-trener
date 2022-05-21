using Core.JointMechanic;
using UnityEngine;

namespace Core.ConditionSystem.Conditionals
{
    public class ConnectConditional: Conditional
    {
        [SerializeField] private Socket _socket1;
        [SerializeField] private Socket _socket2;
        
        public override bool IsDone()
        {
            return Socket.IsConnection(_socket1, _socket2);
        }
    }
}