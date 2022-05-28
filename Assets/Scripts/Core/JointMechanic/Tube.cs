using System;
using UnityEngine;

namespace Core.JointMechanic
{
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