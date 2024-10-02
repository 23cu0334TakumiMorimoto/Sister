using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMover : MonoBehaviour
{
    [SerializeField] private float _moveForce = 5;

    private SpriteRenderer _sr;
    private Rigidbody2D _rigidbody;
    private PlayerInputs _gameInputs;
    private Vector2 _moveInputValue;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;

        // Actionスクリプトのインスタンス生成
        _gameInputs = new PlayerInputs();

        // Actionイベント登録
        _gameInputs.Player.Move.started += OnMove;
        _gameInputs.Player.Move.performed += OnMove;
        _gameInputs.Player.Move.canceled += OnMove;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _gameInputs?.Dispose();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Moveアクションの入力取得
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate()
    {
        // 位置を移動させる
        _rigidbody.velocity = (new Vector2(
            _moveInputValue.x,
            _moveInputValue.y
        ) * _moveForce);
    }

    private void FlipSprite()
    {
        // 現在のキーボード情報
        var current = Keyboard.current;

        // キーボード接続チェック
        if (current == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }

        // キーの入力状態取得
        var aKey = current.aKey;
        var dKey = current.dKey;

        // Aキーが押されているかどうか
        if (aKey.isPressed)
        {
            if (_sr.flipX == true)
            {
                _sr.flipX = false;
            }
        }

        // Dキーが押されているかどうか
        if (dKey.isPressed)
        {
            if (_sr.flipX == false)
            {
                _sr.flipX = true;
            }
        }
    }
}