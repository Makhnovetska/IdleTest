using System.Collections.Generic;
using System.Linq;
using Controllers.Loot;
using Services.GameFactory;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerBagController : MonoBehaviour
    {
        [SerializeField] private Transform _lootPoint;
        [SerializeField] private int _capacity = 3;

        private readonly List<LootController> _lootItems = new();
        public IReadOnlyList<LootController> lootItems => _lootItems;
        public int count => _lootItems.Count;
        public bool isFull => count >= _capacity;
        public bool isEmpty => count == 0;

        public void AddLoot()
        {
            if (count < _capacity)
            {
                LootController loot = FactoryService.instance.lootFactory.Create();
                _lootItems.Add(loot);
                loot.isPickedUp = true;
                loot.transform.SetParent(_lootPoint, false);
                loot.transform.localPosition = GetLootPosition(count, true);
            }
        }

        public bool TryRemoveLoot(int count = 1)
        {
            if (this.count >= count)
            {
                for (int i = 0; i < count; i++)
                {
                    LootController loot = _lootItems.Last();
                    _lootItems.Remove(loot);
                    FactoryService.instance.lootFactory.Destroy(loot);
                }
                return true;
            }

            return false;
        }
        
        public Vector3 GetLootPosition(int count, bool isLocalPosition = false)
        {
            Vector3 localPos = new Vector3(0, 0.4f * (count - 1), 0);
            if (isLocalPosition)
                return localPos;
            
            return _lootPoint.position + localPos;
        }
        
        public Vector3 GetLootRotation()
        {
            return _lootPoint.rotation.eulerAngles;
        }
    }
}