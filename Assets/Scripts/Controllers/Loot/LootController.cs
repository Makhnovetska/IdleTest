using Services.GameFactory;
using UnityEngine;

namespace Controllers.Loot
{
    public abstract class LootController : MonoBehaviour
    {
        public virtual void PickUp(PlayerController player)
        {
            player.bag.AddLoot();
            FactoryService.instance.lootFactory.Destroy(this);
        }
    }
}