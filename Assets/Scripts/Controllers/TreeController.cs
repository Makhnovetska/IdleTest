using Contracts.Interfaces;
using Services;
using Services.GameFactory;
using UnityEngine;

namespace Controllers
{
    public class TreeController : MonoBehaviour, IPlayerTarget
    {
        [SerializeField] private int _health = 3;
        [SerializeField] private int _dropLootCount = 3;
        [SerializeField] private float _dropRadius = 3.0f;
        public int health => _health;
        
        public void Chop()
        {
            _health--;

            if (_health <= 0)
            {
                for (int i = 0; i < _dropLootCount; i++)
                {
                    Vector3 randomDelta = new Vector3(
                        Random.Range(-_dropRadius, _dropRadius),
                        0.0f,
                        Random.Range(-_dropRadius, _dropRadius));
                    
                    LevelService.instance.DropLoot(transform.position + randomDelta);
                    FactoryService.instance.treesFactory.Destroy(this);
                }
            }
        }
    }
}