using UnityEngine;

namespace Controllers
{
    public abstract class LootController : MonoBehaviour
    {
        public virtual void PickUp(PlayerController player)
        {
            player.bag.AddLoot(this);
            Destroy(gameObject);
        }
    }
}