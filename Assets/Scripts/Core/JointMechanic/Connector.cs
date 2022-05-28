using UnityEngine;
using UnityEngine.Events;

namespace Core.JointMechanic
{
    public class Connector : MonoBehaviour
    {
        [SerializeField] private ConnectorType _type;
        [SerializeField] private JointSettings _jointSettings;
        [SerializeField] private Rigidbody _rigidbody;
        
        private FixedJoint _joint;
        
        public Connector ConnectedConnector { get; private set; }
        public Tube ConnectedTube { get; private set; }
        public ConnectorType Type => _type;
        public Rigidbody Rigidbody => _rigidbody;

        public UnityEvent OnConnection;
        public UnityEvent OnDisconnection;
        
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_type == ConnectorType.Plug)
            {
                if(other.gameObject.TryGetComponent(out Connector connector))
                    TryConnectionWith(connector);
            }
        }
        
        private void OnJointBreak(float breakForce)
        {
            BreakConnection();
        }

        public void SetTube(Tube tube)
        {
            ConnectedTube = tube;
        }
        
        public void SetLogicConnection(Connector connector)
        {
            ConnectedConnector = connector;
            OnConnection?.Invoke();
        }
        
        private void TryConnectionWith(Connector connector)
        {
            if (connector.Type == ConnectorType.Socket)
            {
                SetJointConnectionWith(connector);
                SetLogicConnection(connector);
                connector.SetLogicConnection(this);
            }
        }

        private void SetJointConnectionWith(Connector connector)
        {
            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.connectedBody = connector.Rigidbody;
            SetJointSettings();
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
        
        private void BreakConnection()
        {
            _joint = null;
            ConnectedConnector.SetLogicConnection(null);
            SetLogicConnection(null);
            OnDisconnection?.Invoke();
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