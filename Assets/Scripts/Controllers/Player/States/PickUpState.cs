using Utils;

namespace Controllers.Player.States
{
    public class PickUpState : State<PlayerController>
    {
        private readonly LootController _loot;
        
        public PickUpState(PlayerController owner, LootController loot) : base(owner)
        {
            _loot = loot;
        }

        public override void OnEnter()
        {
            _loot.PickUp(_owner);
            _owner.anim.SetPickUp();
            _owner.behavior.ChangeState(new IdleState(_owner));
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}