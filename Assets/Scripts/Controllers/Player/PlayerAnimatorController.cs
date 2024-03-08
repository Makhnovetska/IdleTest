using UnityEngine;

namespace Controllers.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly string _parameterKey = "actionID";
        private static readonly int _idleAnimValue = 11;
        private static readonly int _runningAnimValue = 21;
        private static readonly int _chopAnimValue = 101;
        private static readonly int _pickUpAnimValue = 12;
        private static readonly int _dropOffAnimValue = 12;
        
        public void SetIdle()
        {
            _animator.SetInteger(_parameterKey, _idleAnimValue);
        }
        
        public void SetRunning()
        {
            _animator.SetInteger(_parameterKey, _runningAnimValue);
        }

        public void SetChopping()
        {
            _animator.SetInteger(_parameterKey, _chopAnimValue);
        }
        
        public void SetPickUp()
        {
            _animator.SetInteger(_parameterKey, _pickUpAnimValue);
        }

        public void SetDropOff()
        {
            _animator.SetInteger(_parameterKey, _dropOffAnimValue);
        }
    }
}