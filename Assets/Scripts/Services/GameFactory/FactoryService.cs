using Services.GameFactory.Factories;
using UnityEngine;

namespace Services.GameFactory
{
    public class FactoryService : MonoBehaviour
    {
        public static FactoryService instance { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private TreesFactory _treesFactory;
        [SerializeField] private LootFactory _lootFactory;

        public TreesFactory treesFactory => _treesFactory;
        public LootFactory lootFactory => _lootFactory;
    }
}