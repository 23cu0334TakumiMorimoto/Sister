using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMover : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField] PlayerData statusdata;

    private SpriteRenderer _sr;
    private Rigidbody2D _rigidbody;
    private PlayerInputs _gameInputs;
    private Vector2 _moveInputValue;

    private Animator _animator;

   


    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;

        _animator = GetComponent<Animator>();
        _animator.SetInteger("Action", 0);

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
        // 現在のキーボード情報
        var current = Keyboard.current;


        // キーボード接続チェック
        if (current == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }

        //// キーの入力状態取得
        //var aKey = current.aKey;
        //var leftArrowKey = current.leftArrowKey;
        //var dKey = current.dKey;
        //var rightArrowKey = current.rightArrowKey;
        //// ゲームパッド（デバイス取得）
        //var gamepad = Gamepad.current;
        //if (gamepad == null) return;
        //// ゲームパッドの左右のスティックの入力値を取得
        //var x = gamepad.leftStick.x.ReadValue();
        //var y = gamepad.leftStick.y.ReadValue();

        //斜めの移動距離を正規化処理を行い均一化する
        Vector2 dir = new Vector2(_moveInputValue.x, _moveInputValue.y).normalized;

        //現在の状態がシスターの時
        if (statusdata.PLAYER_PERSON == 0)
        {
            // 祈っていないなら
            if (statusdata.IsPrayed != true)
            {
                // 位置を移動させる
                _rigidbody.velocity = dir * statusdata.SISTER_SPEED;
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
                    Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    //|| x > 0 || x < 0 || y > 0 || y < 0)
                {
                    _animator.SetInteger("Action", 1);
                }
                else
                {
                    _animator.SetInteger("Action", 0);
                }

            }
            // 祈っているなら
            else
            {
                // 速度を０にする
                _rigidbody.velocity = new Vector2(0, 0);
                _animator.SetInteger("Action", 2);
            }
        }
        // 現在の状態がデビルの時
        if (statusdata.PLAYER_PERSON == 1)
        {
            // 位置を移動させる
            _rigidbody.velocity = dir * statusdata.DEVIL_SPEED;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
                    Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.J))
                    //|| x > 0 || x < 0 || y > 0 || y < 0)
            {

                _animator.SetInteger("Action", 4);

            }
            else
            {
                _animator.SetInteger("Action", 3);
            }
        }
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
        var leftArrowKey = current.leftArrowKey;
        var dKey = current.dKey;
        var rightArrowKey = current.rightArrowKey;
        //// ゲームパッド（デバイス取得）
        //var gamepad = Gamepad.current;
        //if (gamepad == null) return;
        //// ゲームパッドの左右のスティックの入力値を取得
        //var x = gamepad.leftStick.x.ReadValue();
        //var y = gamepad.leftStick.y.ReadValue();

        // Aキーもしくは左キーが押されているかどうか
        if (aKey.isPressed || leftArrowKey.isPressed) //|| x < 0)
        {
            if (_sr.flipX == true)
            {
                _sr.flipX = false;
            }
        }

        // Dキーもしくは右キーが押されているかどうか
        if (dKey.isPressed || rightArrowKey.isPressed) //|| x > 0)
        {
            if (_sr.flipX == false)
            {
                _sr.flipX = true;
            }
        }
    }
}