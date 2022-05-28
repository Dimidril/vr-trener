using UnityEngine;
using UnityEngine.Serialization;

namespace Core.JointMechanic{ 

    [RequireComponent(typeof(Rigidbody))]
    public class Plug : MonoBehaviour
    {
        [FormerlySerializedAs("_connectionType")] [SerializeField] private ConnectorType _connectorType;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private JointSettings _jointSettings;

        private FixedJoint _joint;
        private Socket _connectedSocket;
        private TubeOld _tubeOld; 

        public Rigidbody Rigidbody => _rigidbody;

        public Socket ConnectedSocket => _connectedSocket;
        public TubeOld TubeOld => _tubeOld;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTrigOngerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Socket socket))
                TryConnection(socket);
        }

        private void OnJointBreak(float breakForce)
        {
            BreakConnection();
        }

        public void SetTube(TubeOld tubeOld)
        {
            _tubeOld = tubeOld;
        }

        public Plug GetSecondEnd()
        {
            return _tubeOld.GetSecondPlug(this);
        }

        private void BreakConnection()
        {
            _connectedSocket.BreakConnection();
            _joint = null;
            _connectedSocket = null;
        }

        private void TryConnection(Socket socket)
        {
            if(socket.ConnectorType == _connectorType && _joint == null)
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
}