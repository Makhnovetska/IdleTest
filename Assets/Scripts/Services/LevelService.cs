using System.Collections.Generic;
using System.Linq;
using Controllers;
using Controllers.Loot;
using Services.GameFactory;
using UnityEngine;

namespace Services
{
    public class LevelService : MonoBehaviour
    {
        public static LevelService instance { get; private set; }
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
        
        public HouseController house { get; private set; }
        public PlayerController player { get; private set; }

        public IReadOnlyList<TreeController> trees 
            => FactoryService.instance.treesFactory.instances;
        public IReadOnlyList<LootController> lootFactory 
            => FactoryService.instance.lootFactory.instances;
        
        
        public void CreateHouse(HouseController housePrefab)
        {
            house = Instantiate(housePrefab, Vector3.zero, Quaternion.identity);
        }
        
        public void CreatePlayer(PlayerController playerPrefab)
        {
            player = Instantiate(
                playerPrefab, 
                new Vector3(2.0f, 0.0f, 0.0f), 
                Quaternion.identity);
        }
        
        
        public void CreateTrees(int count, Vector3 center, float radius)
        {
            for (int i = 0; i < count; i++)
            {
                bool isPositionValid = false;
                Vector3 position = Vector3.zero;
                
                while (!isPositionValid)
                {
                    position = GetDeltaPosition();
                    isPositionValid = IsPositionValid(position);
                }
                
                TreeController tree = FactoryService.instance.treesFactory.Create();
                tree.transform.position = position;
            }

            Vector3 GetDeltaPosition()
            {
                return new Vector3(center.x + Random.value * radius, center.y,  center.z + Random.value * radius);
            }
            
            bool IsPositionValid(Vector3 position)
            {
                IEnumerable<Transform> treesTransforms = FactoryService.instance.treesFactory.instances.Select(t => t.transform);
                return treesTransforms.All(t => Vector3.Distance(t.position, position) > 4.0f);
            }
        }

        public void DropLoot(Vector3 position)
        {
            LootController loot = FactoryService.instance.lootFactory.Create();
            loot.transform.position = position;
        }
    }
}