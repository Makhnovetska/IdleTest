using UnityEngine;
using Utils;

namespace Controllers.Player.States
{
    public class DropOffState : State<PlayerController>
    {
        private readonly HouseController _house;
        private readonly float _dropOffInterval = 0.5f;
        private float _dropOffTimer;
        
        public DropOffState(PlayerController owner, HouseController house) : base(owner)
        {
            _house = house;
        }

        public override void OnEnter()
        {
            _owner.anim.SetDropOff();
        }

        public override void OnExit()
        {
            _owner.transform.LookAt(Vector3.right);
        }

        public override void OnUpdate()
        {
            _dropOffTimer += Time.deltaTime;
            
            if (_dropOffTimer >= _dropOffInterval)
            {
                if (_owner.bag.TryRemoveLoot())
                    _house.PutLoot();
                
                _dropOffTimer = 0.0f;
            }
            
            if (_owner.bag.isEmpty)
                _owner.behavior.ChangeState(new IdleState(_owner));
        }
    }
}