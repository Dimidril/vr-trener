using UnityEngine;

namespace Core.JointElements{ 

    [RequireComponent(typeof(Rigidbody))]
    public class ElementForConnection : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private JointSettings _jointSettings;

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
                transform.rotation = socket.transform.rotation;
                _joint = gameObject.AddComponent<FixedJoint>();
                _joint.connectedBody = socket.Rigidbody;
                SetJointSettings();
            }
        }

        private void SetJointSettings()
        {
            if( _joint != null)
            {
                _joint.breakForce = _jointSettings.BreakForce;
                _joint.breakTorque = _jointSettings.BreakTorque;
                _joint.massScale = _jointSettings.MassScale;
                _joint.connectedMassScale = _jointSettings.ConectedMassScale;
            }
        }
    }

    [System.Serializable]
    struct JointSettings
    {
        public float BreakForce;
        public float BreakTorque;
        public float MassScale;
        public float ConectedMassScale;
    }
}

