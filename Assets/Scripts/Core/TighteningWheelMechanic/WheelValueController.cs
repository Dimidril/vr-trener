using Tilia.Interactions.Controllables.AngularDriver;
using UnityEngine;

namespace Core.TighteningWheelMechanic
{
    public class WheelValueController : MonoBehaviour
    {
        [SerializeField] private AngularDriveFacade _angularDriveFacade;

        public float CurrentRotateValue { get; private set; }

        private void OnValidate()
        {
            _angularDriveFacade = GetComponent<AngularDriveFacade>();
        }

        private void Awake()
        {
            _angularDriveFacade.ValueChanged.AddListener(ChangeCurrentRotateValue);
        }

        private void ChangeCurrentRotateValue(float value)
        {
            CurrentRotateValue = value;
        }
    }
}
