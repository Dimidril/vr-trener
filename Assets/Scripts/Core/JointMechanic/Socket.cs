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
        public Plug ConnectionPlug => _connectedPlug;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetConnection(Plug plug)
        {
            _connectedPlug = plug;
        }

        public void BreakConnection()
        {
            _connectedPlug = null;
        }
    }
}