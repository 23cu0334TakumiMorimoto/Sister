using UnityEngine;
using UnityEngine.Assertions;
using Sister.StateMachine;

// ---------------------------------------------------------------
// �v���C���[�A�N�V�����X�e�[�g�}�V��
// ---------------------------------------------------------------
public class PlayerActionStateMachine : StateMachine<PlayerActionStateMachine.EPlayerActionState>
{
    // �A�N�V�����X�e�[�g�񋓌^
    public enum EPlayerActionState
    {
        Idle = 0,       // �ҋ@
        Walk,           // ����
        KnockBack,     // �ӂ��Ƃ�
        Damaged,        // �_���[�W���󂯂�
        Dead,           // ���S
    }

    // �X�e�[�g�Ɋ֌W������̂̏W��
    private PlayerActionContext _context;

    // �v���C���[GameObject
    private GameObject _player;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private PlayerController _playerController;

    public string StateKey;

    void Awake()
    {

        _player = gameObject;
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();

        // ��O�`�F�b�N
        ValidateConstraints();

        _context = new PlayerActionContext(_player, _rigidbody, _animator, _playerController, this);

        // �e�X�e�[�g�̏�����
        InitializeStates();
    }

    private void LateUpdate()
    {
        {
            StateKey = _currentState.ToString();
        }
    }

    /// <summary>
    /// ��O�`�F�b�N
    /// </summary>
    private void ValidateConstraints()
    {
        Assert.IsNotNull(_player, "Player is not assigned");

        Assert.IsNotNull(_animator, "Player Animation is not assigned");
    }

    /// <summary>
    /// �e�X�e�[�g��������
    /// </summary>
    private void InitializeStates()
    {
        // �ҋ@
        _states.Add(EPlayerActionState.Idle, new PlayerIdleState(_context, EPlayerActionState.Idle));

        // ����
        _states.Add(EPlayerActionState.Walk, new PlayerWalkState(_context, EPlayerActionState.Walk));

        // �m�b�N�o�b�N
        _states.Add(EPlayerActionState.KnockBack, new PlayerKnockBackState(_context, EPlayerActionState.KnockBack));

        // �X�e�[�g�̏����l��ݒ�
        _currentState = _states[EPlayerActionState.Idle];
    }
}
