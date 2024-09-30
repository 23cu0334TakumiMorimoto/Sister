using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ----------------------------------
// プレイヤー歩く状態クラス
// ----------------------------------
public class PlayerWalkState : PlayerActionState
{

    public PlayerWalkState(
                                                         PlayerActionContext context,
                                PlayerActionStateMachine.EPlayerActionState stateKey
                          ) : base(context, stateKey) { }

    public override void EnterState()
    {
        //_context.PlayerAnimator.Play("Walk");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if (_context.PlayerCtrl.MoveDirection == 0)
        {
            _context.StateMachine.SwitchNextState(PlayerActionStateMachine.EPlayerActionState.Idle);
        }

    }

    public override void FixedUpdateState()
    {
       // _context.PlayerCtrl.Move();
    }
}
