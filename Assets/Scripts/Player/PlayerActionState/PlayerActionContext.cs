using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sister.StateMachine;

// -----------------------------------------
// プレイヤーの変数宣言をまとめたスクリプト
// -----------------------------------------

public class PlayerActionContext
{
    private GameObject _player;
    private Animator _animator;
    private PlayerController _playerController;
    private StateMachine<PlayerActionStateMachine.EPlayerActionState> _stateMachine;

    public PlayerActionContext(GameObject player,Animator animator, PlayerController playercontroller, StateMachine<PlayerActionStateMachine.EPlayerActionState> stateMachine)
    {
        _player = player;
        _animator = animator;
        _playerController = playercontroller;
        _stateMachine = stateMachine;
    }

    public GameObject PlayerGameObject => _player;
    public Animator PlayerAnimator => _animator;
    public PlayerController PlayerCtrl => _playerController;
    public StateMachine<PlayerActionStateMachine.EPlayerActionState> StateMachine => _stateMachine;
   
}
