using Controllers.Loot;
using Services;
using Services.GameFactory;
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
                HouseController house = LevelService.instance.house;

                if (_owner.movement.IsPlayerNear(house.transform.position))
                    _owner.behavior.ChangeState(new DropOffState(_owner, house));
                else
                    _owner.behavior.ChangeState(new MoveState(_owner, house.transform.position));

                return;
            }
            
            if (TryFindLootNearby(out LootController loot))
            {
                if (_owner.movement.IsPlayerNear(loot.transform.position))
                    _owner.behavior.ChangeState(new PickUpState(_owner, loot));
                else
                    _owner.behavior.ChangeState(new MoveState(_owner, loot.transform.position));
                
                return;
            }
            
            
            if (TryFindTreesNearby(out TreeController tree))
            {
                if (_owner.movement.IsPlayerNear(tree.transform.position))
                    _owner.behavior.ChangeState(new ChopState(_owner, tree));
                else
                    _owner.behavior.ChangeState(new MoveState(_owner, tree.transform.position));
                
                return;
            }
        }

        private bool TryFindLootNearby(out LootController loot)
        {
            loot = default;
            float closestDistance = float.MaxValue;
            
            foreach (LootController l in FactoryService.instance.lootFactory.instances)
            {
                if (l.isPickedUp) continue;
                
                float distance = Vector3.Distance(_owner.transform.position, l.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    loot = l;
                }
            }
            
            return loot != default;
        }
        
        private bool TryFindTreesNearby(out TreeController tree)
        {
            tree = default;
            float closestDistance = float.MaxValue;
            
            foreach (TreeController t in FactoryService.instance.treesFactory.instances)
            {
                float distance = Vector3.Distance(_owner.transform.position, t.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    tree = t;
                }
            }
            
            return tree != default;
        }
    }
}