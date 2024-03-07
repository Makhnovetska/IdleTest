using Contracts.Interfaces;
using UnityEngine;

namespace Controllers
{
    public class HouseController : MonoBehaviour, IPlayerTarget
    {
        private int _lootCount = 0;
        
        public void PutLoot(int count = 1)
        {
            _lootCount += count;
        }
    }
}