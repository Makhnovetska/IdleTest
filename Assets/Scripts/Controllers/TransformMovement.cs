using UnityEngine;

namespace Controllers
{
    public class TransformMovement : PlayerMovement
    {
        [SerializeField] private float _speed;
        
        public override void DoStep(Vector3 direction)
        {
            transform.position += direction * (_speed * Time.deltaTime);
        }
    }
}