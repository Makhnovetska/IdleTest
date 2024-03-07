using UnityEngine;

namespace Controllers
{
    public class RigidbodyMovement : PlayerMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        public override void DoStep(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}