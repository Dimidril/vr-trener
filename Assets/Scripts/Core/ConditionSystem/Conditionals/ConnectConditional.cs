using Core.JointMechanic;
using UnityEngine;

namespace Core.ConditionSystem.Conditionals
{
    public class ConnectConditional : Conditional
    {
        [SerializeField] private Connector _socket1;
        [SerializeField] private Connector _socket2;
        
        private new void Awake()
        {
            base.Awake();
            _socket1.OnConnection.AddListener(OnConnected);
            _socket2.OnConnection.AddListener(OnConnected);
        }

        /// <summary>
        /// Вызываеться когда один из Connector был присоединён
        /// Проверка на соединение двух коннекторов и вызов соответствующего события
        /// </summary>
        private void OnConnected()
        {
            if(ConnectedRequests.IsConnection(_socket1, _socket2))
            {
                OnConditionalDone.Invoke(true);
            }
        }
    }
}