using Services.GameFactory.Factories;
using UnityEngine;

namespace Services.GameFactory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private TreesFactory _treesFactory;
        [SerializeField] private LootFactory _lootFactory;

        public TreesFactory treesFactory => _treesFactory;
        public LootFactory lootFactory => _lootFactory;
    }
}