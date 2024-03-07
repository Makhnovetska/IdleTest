using Contracts.Interfaces;
using Services;
using Services.GameFactory;
using UnityEngine;

namespace Controllers
{
    public class TreeController : MonoBehaviour, IPlayerTarget
    {
        [SerializeField] private int _health = 3;
        public int health => _health;
        
        public void Chop()
        {
            _health--;
            Debug.Log("Chopping tree");

            if (_health <= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 randomPosition = new Vector3(
                        Random.value * 10,
                        transform.position.y,
                        Random.value * 10);
                    
                    LevelService.instance.DropLoot(randomPosition);
                    FactoryService.instance.treesFactory.Destroy(this);
                }
            }
        }
    }
}