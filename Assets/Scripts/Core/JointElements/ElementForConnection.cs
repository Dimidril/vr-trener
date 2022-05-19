using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.JointElements{ 

    [RequireComponent(typeof(Rigidbody))]
    public class ElementForConnection : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;
        [SerializeField] private Rigidbody _rigidbody;

        private FixedJoint _joint;

        public Rigidbody Rigidbody => _rigidbody;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out SocketForConnection socket))
                TryConnection(socket);
        }

        private void TryConnection(SocketForConnection socket)
        {
            if(socket.ConnectionType == _connectionType && _joint == null)
            {
                _joint = gameObject.AddComponent<FixedJoint>();
                _joint.connectedBody = socket.Rigidbody;
            }
        }
    }
}