using UnityEngine;

namespace Core.JointElements
{
    [RequireComponent(typeof(Rigidbody))]
    public class Socket : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;
        [SerializeField] private Rigidbody _rigidbody;

        public ConnectionType ConnectionType => _connectionType;
        public Rigidbody Rigidbody => _rigidbody;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}