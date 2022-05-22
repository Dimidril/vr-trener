using Core.JointMechanic;
using UnityEngine;

namespace Core.ConditionSystem.Conditionals
{
    public class ConnectConditional: Conditional
    {
        [SerializeField] private Socket _socket1;
        [SerializeField] private Socket _socket2;
        
        protected override bool IsDoneCheck()
        {
            if (_socket1 && _socket2) 
                if(_socket1.ConnectionPlug && _socket2.ConnectionPlug)
                    return _socket1.ConnectionPlug.Tube == _socket2.ConnectionPlug.Tube;
            
            return false;
        }
        
    }
}