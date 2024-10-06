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
   // private Action onResetCallback = null;
    //private PlayerInputs _playerInputs;
    private Vector2 _moveInputValue;

    public PlayerInputs _playerInputs;
    //public int MoveDirection { get; private set; }


    private void Awake()
    {
        // 変数の初期化・値の取得
       // MoveDirection = 0;

        // Actionスクリプトのインスタンス生成
        _playerInputs = new PlayerInputs();

        // Actionイベント登録
        _playerInputs.Player.Move.started += OnMove;
        _playerInputs.Player.Move.performed += OnMove;
        _playerInputs.Player.Move.canceled += OnMove;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _playerInputs.Enable();
    }

    private void OnEnable()
    {
        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _playerInputs.Enable();
    }

    private void OnDispose()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _playerInputs?.Dispose();
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

    private void Update()
    {
        // アクション入力更新
        {
            // 移動方向を取得
            float moveInput = Input.GetAxis("Horizontal") + Input.GetAxisRaw("Keyboard Horizontal");
            if (Mathf.Abs(moveInput) < 0.1f)
            {
                //MoveDirection = 0;
            }
            else
            {
             //   MoveDirection = (int)Mathf.Sign(moveInput);
            }
        }

        // 反転できるようにする
        FlipSpriteRenderer();
    }

    private void FixedUpdate()
    {
        //// 位置を移動させる
        //_rigidbody.velocity = (new Vector3(
        //    _moveInputValue.x,
        //    _moveInputValue.y,
        //     0
        //) * _moveSpeed);
    }

    public void Move()
    {
        _rigidbody.velocity = new Vector2(_moveInputValue.x * _moveSpeed, _moveInputValue.y * _moveSpeed);
    }
}
