using UnityEngine;

namespace Controllers.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int _idleKey = Animator.StringToHash("IDLE_KEY");
        private static readonly int _runningKey = Animator.StringToHash("RUNNING_KEY");
        private static readonly int _chopKey = Animator.StringToHash("CHOP_KEY");
        private static readonly int _pickUpKey = Animator.StringToHash("PICK_UP_KEY");
        
        public void SetIdle()
        {
            _animator.Play(_idleKey);
        }
        
        public void SetRunning()
        {
            _animator.Play(_runningKey);
        }

        public void SetChopping()
        {
            _animator.Play(_chopKey);
        }
        
        public void SetPickUp()
        {
            _animator.Play(_pickUpKey);
        }
    }
}