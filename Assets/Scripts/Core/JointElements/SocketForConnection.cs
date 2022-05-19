using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SocketForConnection : MonoBehaviour
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