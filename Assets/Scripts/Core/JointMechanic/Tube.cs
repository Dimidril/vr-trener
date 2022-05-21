using UnityEngine;

namespace Core.JointMechanic
{
    public class Tube : MonoBehaviour
    {
        [SerializeField] private Plug _plug1;
        [SerializeField] private Plug _plug2;

        private void Awake()
        {
            InitPlugs();
        }

        public Plug GetSecondPlug(Plug plug)
        {
            if (plug == _plug1)
                return _plug2;
            
            if (plug == _plug2)
                return _plug1;
            
            return null;
        }
        
        private void InitPlugs()
        {
            _plug1.SetTube(this);
            _plug2.SetTube(this);
        }
    }
}