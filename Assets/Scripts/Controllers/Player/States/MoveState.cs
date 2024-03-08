using UnityEngine;
using Utils;

namespace Controllers.Player.States
{
    public class MoveState : State<PlayerController>
    {
        private readonly Vector3 _targetPos;
        
        public MoveState(PlayerController owner, Vector3 targetPos) : base(owner)
        {
            _targetPos = targetPos;
        }

        public override void OnEnter()
        {
            _owner.anim.SetRunning();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            Vector3 direction = Vector3.Normalize(_targetPos - _owner.transform.position);
            _owner.movement.DoStep(direction);
            
            if (_owner.movement.IsPlayerNear(_targetPos))
                _owner.behavior.ChangeState(new IdleState(_owner));
        }
    }
}