using UnityEngine;

namespace Core.JointMechanic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Socket : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;
        [SerializeField] private Rigidbody _rigidbody;

        private Plug _connectedPlug;

        public ConnectionType ConnectionType => _connectionType;
        public Rigidbody Rigidbody => _rigidbody;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetConnection(Plug plug)
        {
            _connectedPlug = plug;
            Debug.Log($"Socket connection with {plug.name}");
        }

        public void BreakConnection()
        {
            _connectedPlug = null;
        }

        public static bool IsConnection(Socket socket1, Socket socket2)
        {
            if (socket1 != null && socket2 != null) 
                if(socket1._connectedPlug && socket2._connectedPlug)
                    return socket1._connectedPlug.Tube == socket2._connectedPlug.Tube;
            
            return false;
        }
        
    }
}