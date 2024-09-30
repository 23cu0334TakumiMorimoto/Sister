using Sister.StateMachine;

// ---------------------------------------
// �v���C���[�A�N�V�����X�e�[�g�x�[�X�N���X
// ---------------------------------------
public abstract class PlayerActionState : BaseState<PlayerActionStateMachine.EPlayerActionState>
{
    // �X�e�[�g�Ɋ֌W������̂̏W��
    protected PlayerActionContext _context;

    // �R���X�g���N�^
    public PlayerActionState(PlayerActionContext context,
                                PlayerActionStateMachine.EPlayerActionState stateKey
                            ) : base(stateKey)
    {
        _context = context;
    }
}
