using UnityEngine;

namespace Controllers
{
    public class TransformMovement : PlayerMovement
    {
        [SerializeField] private float _speed;
        
        public override void DoStep(Vector3 direction)
        {
            transform.LookAt(transform.position + direction);
            transform.position += direction * (_speed * Time.deltaTime);
        }
    }
}