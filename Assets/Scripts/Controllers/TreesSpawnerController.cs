using System.Collections;
using Services;
using Services.GameFactory;
using UnityEngine;

namespace Controllers
{
    public class TreesSpawnerController : MonoBehaviour
    {
        [SerializeField] private int _initialTreesCount = 3;
        [SerializeField] private int _targetTreesCount = 25;
        [SerializeField] private float _spawnInterval = 10;
        [SerializeField] private float _radius = 10;
        
        private IEnumerator Start()
        {
            // Spawn initial trees
            for (int i = 0; i < _initialTreesCount; i++)
                CreateTree();
            
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                
                if (FactoryService.instance.treesFactory.instances.Count < _targetTreesCount)
                {
                    yield return new WaitForSeconds(1.0f);
                    CreateTree();
                }
            }

            void CreateTree()
            {
                LevelService.instance.CreateTrees(1, transform.position, _radius);
            }
        }
    }
}