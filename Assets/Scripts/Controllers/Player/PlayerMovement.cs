using UnityEngine;

namespace Controllers
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        public abstract void DoStep(Vector3 direction);
        
        public bool IsPlayerNear(Vector3 position)
        {
            float distance = Vector3.Distance(transform.position, position);
            return distance < 1.0f;
        }
    }
}