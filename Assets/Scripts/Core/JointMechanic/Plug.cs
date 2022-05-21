using UnityEngine;

namespace Core.JointMechanic{ 

    [RequireComponent(typeof(Rigidbody))]
    public class Plug : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private JointSettings _jointSettings;

        private FixedJoint _joint;
        private Socket _connectedSocket;
        private Tube _tube; 

        public Rigidbody Rigidbody => _rigidbody;

        public Socket ConnectedSocket => _connectedSocket;
        public Tube Tube => _tube;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Socket socket))
                TryConnection(socket);
        }

        private void OnJointBreak(float breakForce)
        {
            BreakConnection();
        }

        public void SetTube(Tube tube)
        {
            _tube = tube;
        }

        public Plug GetSecondEnd()
        {
            return _tube.GetSecondPlug(this);
        }

        private void BreakConnection()
        {
            _connectedSocket.BreakConnection();
            _joint = null;
            _connectedSocket = null;
        }

        private void TryConnection(Socket socket)
        {
            if(socket.ConnectionType == _connectionType && _joint == null)
                SetConnection(socket);
        }

        private void SetConnection(Socket socket)
        {
            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.connectedBody = socket.Rigidbody;
            SetJointSettings();
            socket.SetConnection(this);
            _connectedSocket = socket;
        }

        private void SetJointSettings()
        {
            if( _joint != null)
            {
                _joint.breakForce = _jointSettings.BreakForce;
                _joint.breakTorque = _jointSettings.BreakTorque;
                _joint.massScale = _jointSettings.MassScale;
                _joint.connectedMassScale = _jointSettings.ConnectedMassScale;
            }
        }
    }

    [System.Serializable]
    internal struct JointSettings
    {
        public float BreakForce;
        public float BreakTorque;
        public float MassScale;
        public float ConnectedMassScale;
    }
}