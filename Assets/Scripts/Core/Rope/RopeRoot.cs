using System.Collections.Generic;
using UnityEngine;

namespace Core.Rope
{
    public class RopeRoot : MonoBehaviour
    {
        public float RigidbodyMass = 1f;
        public float ColliderRadius = 0.1f;
        public float JointSpring = 0.1f;
        public float JointDamper = 5f;
        public Vector3 RotationOffset;
        public Vector3 PositionOffset;

        protected List<Transform> CopySource;
        protected List<Transform> CopyDestination;
        protected static GameObject RigidBodyContainer;

        void Awake()
        {
            if(RigidBodyContainer == null)
                RigidBodyContainer = new GameObject("RopeRigidbodyContainer");

            CopySource = new List<Transform>();
            CopyDestination = new List<Transform>();
            
            AddChildren(transform);
        }

        
        public void Update()
        {
            for (int i = 0; i < CopySource.Count; i++)
            {
                CopyDestination[i].position = CopySource[i].position + PositionOffset;
                CopyDestination[i].rotation = CopySource[i].rotation * Quaternion.Euler(RotationOffset);
            }
        }
        
        private void AddChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                var representative = new GameObject(child.gameObject.name);
                representative.transform.parent = RigidBodyContainer.transform;
                
                AddRigidbodyTo(representative);
                AddColliderTo(representative);
                AddJointTo(representative, parent, child);
                
                //add copy source
                CopySource.Add(representative.transform);
                CopyDestination.Add(child);

                AddChildren(child);
            }
        }

        private void AddRigidbodyTo(GameObject representative)
        {
            var childRigidbody = representative.AddComponent<Rigidbody>();
            childRigidbody.useGravity = true;
            childRigidbody.isKinematic = false;
            childRigidbody.freezeRotation = true;
            childRigidbody.mass = RigidbodyMass;
        }

        private void AddColliderTo(GameObject representative)
        {
            var collider = representative.AddComponent<SphereCollider>();
            collider.center = Vector3.zero;
            collider.radius = ColliderRadius;
        }

        private void AddJointTo(GameObject representative, Transform parent, Transform child)
        {
            var joint = representative.AddComponent<DistanceJoint3D>();
            joint.ConnectedRigidbody = parent;
            joint.DetermineDistanceOnStart = true;
            joint.Spring = JointSpring;
            joint.Damper = JointDamper;
            joint.DetermineDistanceOnStart = false;
            joint.Distance = Vector3.Distance(parent.position, child.position);
        }
    }
}