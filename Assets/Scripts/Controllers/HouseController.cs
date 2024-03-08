using System.Collections.Generic;
using Contracts.Interfaces;
using UnityEngine;

namespace Controllers
{
    public class HouseController : MonoBehaviour, IPlayerTarget
    {
        [SerializeField] private Material _builtMat;
        [SerializeField] private Material _lockedMat;
        [Space] 
        [SerializeField] private List<MeshRenderer> _partsMeshes;
        
        private int _lootCount = 0;

        private void Awake()
        {
            RefreshLook();
        }

        public void PutLoot(int count = 1)
        {
            _lootCount += count;
            RefreshLook();
        }

        private void RefreshLook()
        {
            for (int i = 0; i < _partsMeshes.Count; i++)
            {
                bool isBuilt = _lootCount >= i * 3 + 3;
                _partsMeshes[i].material = isBuilt ? _builtMat : _lockedMat;
            }
        }
    }
}