using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static System.Collections.Specialized.BitVector32;

public class PlayerController : CharacterBase
{
    private BoxCollider2D _boxCollider2D;
    private PlayerActionStateMachine _actionStateMachine;
    private SpriteRenderer _playerSpriteRenderer;
    private Action onResetCallback = null;
    private PlayerInputs _playerInputs;
    private Vector2 _moveInputValue;
    // 角度を代入する
    private Vector3 _worldAngle;

    public int MoveDirection { get; private set; }


    private void Awake()
    {
        // 変数の初期化・値の取得
        MoveDirection = 0;

        // Actionスクリプトのインスタンス生成
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _playerInputs?.Disable();
    }
    private void Start()
    {
        _actionStateMachine = gameObject.GetOrAddComponent<PlayerActionStateMachine>();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Moveアクションの入力取得
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_moveInputValue.x * _moveSpeed, _moveInputValue.y * _moveSpeed * Time.deltaTime, 0);
    }

}
