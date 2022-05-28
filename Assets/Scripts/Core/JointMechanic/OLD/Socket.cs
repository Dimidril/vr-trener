using UnityEngine;
using UnityEngine.Serialization;

namespace Core.JointMechanic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Socket : MonoBehaviour
    {
        [FormerlySerializedAs("_connectionType")] [SerializeField] private ConnectorType _connectorType;
        [SerializeField] private Rigidbody _rigidbody;

        private Plug _connectedPlug;

        public ConnectorType ConnectorType => _connectorType;
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