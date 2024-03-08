using UnityEngine;
using Utils;

namespace Controllers.Player.States
{
    public class ChopState : State<PlayerController>
    {
        private readonly float _chopInterval = 1.0f;
        
        private TreeController _tree;
        private float _chopTimer;

        public ChopState(PlayerController owner, TreeController tree) : base(owner)
        {
            _tree = tree;
        }

        public override void OnEnter()
        {
            _owner.anim.SetChopping();
        }

        public override void OnExit()
        {
            _tree = default;
            _chopTimer = 0.0f;
        }

        public override void OnUpdate()
        {
            _chopTimer += Time.deltaTime;
            
            if (_chopTimer >= _chopInterval)
            {
                Chop();
                _chopTimer = 0.0f;
            }
            
            if (_tree.health <= 0)
                _owner.behavior.ChangeState(new IdleState(_owner));
        }
        
        private void Chop()
        {
            _tree.Chop();
        }
    }
}