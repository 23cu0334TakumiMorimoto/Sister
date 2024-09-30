using UnityEngine;
// ----------------------------------
// プレイヤー待機状態クラス
// ----------------------------------
public class PlayerIdleState : PlayerActionState
{
    // コンストラクタ
    public PlayerIdleState(PlayerActionContext context,
                               PlayerActionStateMachine.EPlayerActionState stateKey
                          ) : base(context, stateKey) { }

    public override void EnterState()
    {
        _context.PlayerAnimator.Play("Idle");
    }

    public override void UpdateState()
    {
        if (_context.PlayerCtrl.MoveDirection != 0)
        {
            _context.StateMachine.SwitchNextState(PlayerActionStateMachine.EPlayerActionState.Walk);
        }

    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
