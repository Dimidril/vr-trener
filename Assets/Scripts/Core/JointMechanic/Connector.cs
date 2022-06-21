using System;
using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;
using UnityEngine.Events;

namespace Core.JointMechanic
{
    /// <summary>
    /// Класс для отслеживания и реализации физического и логического присоединения элементов
    /// </summary>
    public class Connector : MonoBehaviour
    {
        [SerializeField] private InteractableFacade _interactable;
        [SerializeField] private ConnectorType _type;
        [SerializeField] private JointSettings _jointSettings;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        
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
            _collider = GetComponent<Collider>();
        }

        private void Awake()
        {
            //_collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_type == ConnectorType.Plug)
            {
                if(other.gameObject.TryGetComponent(out Connector connector))
                    TryConnectionWith(connector);
            }
        }
        
        /// <summary>
        /// Вызываеться когда соединение обрываеться физически
        /// Разрывает соединение и логически
        /// </summary>
        /// <param name="breakForce">Сила разрыва</param>
        private void OnJointBreak(float breakForce)
        {
            Debug.Log("Break");
            _collider.enabled = true;
            BreakConnection();
        }

        /// <summary>
        /// Инициализация Шланга
        /// </summary>
        /// <param name="tube"></param>
        public void SetTube(Tube tube)
        {
            ConnectedTube = tube;
        }
        
        /// <summary>
        /// Производит лоическое соединение
        /// </summary>
        /// <param name="connector">К чему присоединять</param>
        public void SetLogicConnection(Connector connector)
        {
            ConnectedConnector = connector;
            OnConnection?.Invoke();
        }
        
        /// <summary>
        /// Попытка соединения
        /// </summary>
        /// <param name="connector"></param>
        private void TryConnectionWith(Connector connector)
        {
            if (connector.Type == ConnectorType.Socket)
            {
                _collider.enabled = false;
                //SetTransform(); 
                SetJointConnectionWith(connector);
                SetLogicConnection(connector);
                connector.SetLogicConnection(this);
            }
        }

        private void SetTransform()
        {
            if (_targetTransform)
            {
                transform.SetPositionAndRotation(_targetTransform.position, _targetTransform.rotation);
            }
        }

        /// <summary>
        /// Создание физического соединения
        /// </summary>
        /// <param name="connector"></param>
        private void SetJointConnectionWith(Connector connector)
        {
            
            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.connectedBody = connector.Rigidbody;
            SetJointSettings();
        }

        /// <summary>
        /// Задаёт параметры физического соединения
        /// </summary>
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
        
        /// <summary>
        /// Разрывает логическое соединения
        /// </summary>
        private void BreakConnection()
        {
            _joint = null;
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