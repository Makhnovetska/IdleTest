using Services;
using UnityEngine;

namespace Controllers
{
    public class LoaderController : MonoBehaviour
    {
        [SerializeField] private HouseController _housePrefab;
        [SerializeField] private PlayerController _playerPrefab;
        
        private void Start()
        {
            LevelService.instance.CreateHouse(_housePrefab);
            LevelService.instance.CreatePlayer(_playerPrefab);
            LevelService.instance.CreateTrees(5, Vector3.zero, 20f);
        }
    }
}