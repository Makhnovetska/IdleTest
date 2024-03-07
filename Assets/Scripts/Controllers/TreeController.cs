using Contracts.Interfaces;
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
        }
    }
}