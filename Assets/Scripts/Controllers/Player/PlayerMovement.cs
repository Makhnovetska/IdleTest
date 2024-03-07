using UnityEngine;

namespace Controllers
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        public abstract void DoStep(Vector3 direction);
    }
}