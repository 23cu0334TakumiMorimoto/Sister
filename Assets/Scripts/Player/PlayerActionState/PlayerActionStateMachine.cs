using UnityEngine;
using UnityEngine.Assertions;
using Sister.StateMachine;

// ---------------------------------------------------------------
// プレイヤーアクションステートマシン
// ---------------------------------------------------------------
public class PlayerActionStateMachine : StateMachine<PlayerActionStateMachine.EPlayerActionState>
{
    // アクションステート列挙型
    public enum EPlayerActionState
    {
        Idle = 0,       // 待機
        Walk,           // 歩く
        KnockBack,     // ふっとぶ
        Damaged,        // ダメージを受ける
        Dead,           // 死亡
    }

    // ステートに関係するものの集合
    private PlayerActionContext _context;

    // プレイヤーGameObject
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

        // 例外チェック
        ValidateConstraints();

        _context = new PlayerActionContext(_player, _rigidbody, _animator, _playerController, this);

        // 各ステートの初期化
        InitializeStates();
    }

    private void LateUpdate()
    {
        {
            StateKey = _currentState.ToString();
        }
    }

    /// <summary>
    /// 例外チェック
    /// </summary>
    private void ValidateConstraints()
    {
        Assert.IsNotNull(_player, "Player is not assigned");

        Assert.IsNotNull(_animator, "Player Animation is not assigned");
    }

    /// <summary>
    /// 各ステートを初期化
    /// </summary>
    private void InitializeStates()
    {
        // 待機
        _states.Add(EPlayerActionState.Idle, new PlayerIdleState(_context, EPlayerActionState.Idle));

        // 歩く
        _states.Add(EPlayerActionState.Walk, new PlayerWalkState(_context, EPlayerActionState.Walk));

        // ノックバック
        _states.Add(EPlayerActionState.KnockBack, new PlayerKnockBackState(_context, EPlayerActionState.KnockBack));

        // ステートの初期値を設定
        _currentState = _states[EPlayerActionState.Idle];
    }
}
