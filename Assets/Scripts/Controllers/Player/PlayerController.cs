using Controllers;
using Controllers.Player;
using Controllers.Player.States;
using UnityEngine;
using Utils;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimatorController _anim;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerBagController _bag;

    private StateMachine<PlayerController> _behavior;

    public PlayerAnimatorController anim => _anim;
    public PlayerMovement movement => _movement;
    public PlayerBagController bag => _bag;
    public StateMachine<PlayerController> behavior => _behavior;
    
    
    private void Awake()
    {
        _behavior = new StateMachine<PlayerController>(new IdleState(this));
    }

    private void Update()
    {
        _behavior.Update();
    }
}
