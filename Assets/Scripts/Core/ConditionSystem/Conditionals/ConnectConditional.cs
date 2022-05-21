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
            if (_socket1 != null && _socket2 != null) 
                if(_socket1.ConnectionPlug && _socket2.ConnectionPlug)
                    return _socket1.ConnectionPlug.Tube == _socket2.ConnectionPlug.Tube;
            
            return false;
        }
    }
}