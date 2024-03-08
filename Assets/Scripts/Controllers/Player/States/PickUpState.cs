using Controllers.Loot;
using DG.Tweening;
using Utils;

namespace Controllers.Player.States
{
    public class PickUpState : State<PlayerController>
    {
        private readonly float _pickUpTime = 0.3f;
        private readonly LootController _loot;
        
        private Sequence _tween;
        
        public PickUpState(PlayerController owner, LootController loot) : base(owner)
        {
            _loot = loot;
        }

        public override void OnEnter()
        {
            _tween = DOTween.Sequence();
            
            _tween.Append(_loot.transform.DOJump(
                _owner.bag.GetLootPosition(_owner.bag.count)
                , 3.0f
                , 1
                , _pickUpTime));
            _tween.Join(_loot.transform.DORotate(
                _owner.bag.GetLootRotation()
                , _pickUpTime));

            _tween.Play();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            if (!_tween.active || _tween.IsComplete())
            {
                _loot.PickUp(_owner);
                _owner.anim.SetPickUp();
                _owner.behavior.ChangeState(new IdleState(_owner));   
            }
        }
    }
}