using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerBagController : MonoBehaviour
    {
        [SerializeField] private int _capacity = 3;
        public int capacity => _capacity;

        private readonly List<LootController> _items = new();
        public IReadOnlyList<LootController> items => _items;
        
        public bool isFull => _items.Count >= _capacity;
        
        public void AddLoot(LootController loot)
        {
            if (_items.Count < _capacity)
            {
                _items.Add(loot);
            }
        }
    }
}