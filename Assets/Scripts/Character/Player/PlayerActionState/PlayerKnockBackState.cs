using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBackState : PlayerActionState
{
    private float _lockOnMoveTimer;
    // �R���X�g���N�^
    public PlayerKnockBackState(PlayerActionContext context,
                                 PlayerActionStateMachine.EPlayerActionState statekey) : base(context, statekey) { }

    public override void EnterState()
    {
        _lockOnMoveTimer = 1.0f;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        // �_���[�W���󂯂Ă���ۂ͑��삳���Ȃ�
        _lockOnMoveTimer -= Time.deltaTime;

        if (_lockOnMoveTimer <= 0.0f)
        {
            _context.StateMachine.SwitchNextState(PlayerActionStateMachine.EPlayerActionState.Idle);
        }

    }

    public override void FixedUpdateState()
    {
        
    }
}
