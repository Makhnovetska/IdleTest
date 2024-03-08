using Services.GameFactory;
using UnityEngine;

namespace Controllers.Loot
{
    public abstract class LootController : MonoBehaviour
    {
        public bool isPickedUp;
        
        public virtual void PickUp(PlayerController player)
        {
            player.bag.AddLoot();
            isPickedUp = true;
            FactoryService.instance.lootFactory.Destroy(this);
        }
    }
}