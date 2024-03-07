using UnityEngine;
using Utils;

namespace Controllers.Player.States
{
    public class DropOffState : State<PlayerController>
    {
        private readonly HouseController _house;
        private readonly float _dropOffInterval = 1.0f;
        private float _dropOffTimer;
        
        public DropOffState(PlayerController owner, HouseController house) : base(owner)
        {
            _house = house;
        }

        public override void OnEnter()
        {
            
        }

        public override void OnExit()
        {
            
        }

        public override void OnUpdate()
        {
            _dropOffTimer += Time.deltaTime;
            
            if (_dropOffTimer >= _dropOffInterval)
            {
                if (_owner.bag.TryRemoveLoot())
                {
                    _house.PutLoot();
                    Debug.Log("1 loot dropped off! Remaining: " + _owner.bag.count);
                }
                
                _dropOffTimer = 0.0f;
            }
            
            if (_owner.bag.isEmpty)
            {
                Debug.Log("Everything dropped off!");
                _owner.behavior.ChangeState(new IdleState(_owner));
            }
        }
    }
}