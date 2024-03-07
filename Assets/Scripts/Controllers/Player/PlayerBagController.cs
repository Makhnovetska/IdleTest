using UnityEngine;

namespace Controllers.Player
{
    public class PlayerBagController : MonoBehaviour
    {
        [SerializeField] private int _capacity = 3;
        public int capacity => _capacity;
        public int count { get; private set; }
        public bool isFull => count >= _capacity;
        public bool isEmpty => count == 0;

        public void AddLoot()
        {
            if (count < _capacity)
            {
                count++;
            }
        }

        public bool TryRemoveLoot(int count = 1)
        {
            if (this.count >= count)
            {
                this.count -= count;
                return true;
            }

            return false;
        }
    }
}