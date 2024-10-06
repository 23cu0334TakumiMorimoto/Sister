using Sister.StateMachine;

// ---------------------------------------
// プレイヤーアクションステートベースクラス
// ---------------------------------------
public abstract class PlayerActionState : BaseState<PlayerActionStateMachine.EPlayerActionState>
{
    // ステートに関係するものの集合
    protected PlayerActionContext _context;

    // コンストラクタ
    public PlayerActionState(PlayerActionContext context,
                                PlayerActionStateMachine.EPlayerActionState stateKey
                            ) : base(stateKey)
    {
        _context = context;
    }
}
