using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Utils;

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
                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public HouseController house { get; private set; }
        public PlayerController player { get; private set; }
        
        public Factory<TreeController> treeFactory { get; private set; }
        public Factory<LootController> lootFactory { get; private set; }


        private void Init()
        {
        }
        
        public void CreateHouse(HouseController housePrefab)
        {
            house = Instantiate(housePrefab);
        }
        
        public void CreatePlayer(PlayerController playerPrefab)
        {
            player = Instantiate(playerPrefab);
        }
        
    }
}