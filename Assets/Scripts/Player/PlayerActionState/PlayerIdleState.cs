using UnityEngine;
// ----------------------------------
// �v���C���[�ҋ@��ԃN���X
// ----------------------------------
public class PlayerIdleState : PlayerActionState
{
    // �R���X�g���N�^
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
