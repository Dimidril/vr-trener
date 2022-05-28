using System;
using Core.JointMechanic;
using UnityEngine;

namespace Core.ConditionSystem.Conditionals
{
    public class ConnectConditional: Conditional
    {
        [SerializeField] private Connector _socket1;
        [SerializeField] private Connector _socket2;
        
        private new void Awake()
        {
            base.Awake();
            _socket1.OnConnection.AddListener(OnConnected);
            _socket2.OnConnection.AddListener(OnConnected);
        }

        private void OnConnected()
        {
            if(ConnectedRequests.IsSocketsConnection(_socket1, _socket2))
            {
                OnConditionalDone.Invoke(true);
            }
        }
    }
}