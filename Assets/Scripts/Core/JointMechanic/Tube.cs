using UnityEngine;

namespace Core.JointMechanic
{
    /// <summary>
    /// Шланг. Прослойка между двумя Connector
    /// (Объединяющее звено)
    /// </summary>
    public class Tube : MonoBehaviour
    {
        [SerializeField] private Connector _connectorA;
        [SerializeField] private Connector _connectorB;

        private void Awake()
        {
            _connectorA.SetTube(this);
            _connectorB.SetTube(this);
        }
    }
}