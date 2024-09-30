using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ----------------------------------
// �v���C���[������ԃN���X
// ----------------------------------
public class PlayerWalkState : PlayerActionState
{

    public PlayerWalkState(
                                                         PlayerActionContext context,
                                PlayerActionStateMachine.EPlayerActionState stateKey
                          ) : base(context, stateKey) { }

    public override void EnterState()
    {
        _context.PlayerAnimator.Play("Walk");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

       
    }

    public override void FixedUpdateState()
    {
        
    }
}
