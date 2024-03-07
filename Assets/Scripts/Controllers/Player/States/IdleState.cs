using UnityEngine;
using Utils;

namespace Controllers.Player.States
{
    public class IdleState : State<PlayerController>
    {
        public IdleState(PlayerController owner) : base(owner) { }

        public override void OnEnter()
        {
            _owner.anim.SetIdle();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            if (_owner.bag.isFull)
            {
                
            }
            
            if (TryFindLootNearby(out LootController loot))
            {
                float distance = Vector3.Distance(_owner.transform.position, loot.transform.position);
                if (distance < 1.0f)
                {
                    _owner.behavior.ChangeState(new PickUpState(_owner, loot));
                }
                else
                {
                    _owner.behavior.ChangeState(new MoveState(_owner, loot.transform.position));
                }
            }
            
            
            if (TryFindTreesNearby(out TreeController tree))
            {
                float distance = Vector3.Distance(_owner.transform.position, tree.transform.position);
                if (distance < 1.0f)
                {
                    _owner.behavior.ChangeState(new ChopState(_owner, tree));
                }
                else
                {
                    _owner.behavior.ChangeState(new MoveState(_owner, tree.transform.position));
                }
            }
        }

        private bool TryFindLootNearby(out LootController loot)
        {
            loot = default;
            return true;
        }
        
        private bool TryFindTreesNearby(out TreeController tree)
        {
            tree = default;
            return true;
        }
    }
}