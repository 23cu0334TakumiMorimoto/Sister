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
        // �ϐ��̏������E�l�̎擾
       // MoveDirection = 0;

        // Action�X�N���v�g�̃C���X�^���X����
        _playerInputs = new PlayerInputs();

        // Action�C�x���g�o�^
        _playerInputs.Player.Move.started += OnMove;
        _playerInputs.Player.Move.performed += OnMove;
        _playerInputs.Player.Move.canceled += OnMove;

        // Input Action���@�\�����邽�߂ɂ́A
        // �L��������K�v������
        _playerInputs.Enable();
    }

    private void OnEnable()
    {
        // Input Action���@�\�����邽�߂ɂ́A
        // �L��������K�v������
        _playerInputs.Enable();
    }

    private void OnDispose()
    {
        // ���g�ŃC���X�^���X������Action�N���X��IDisposable���������Ă���̂ŁA
        // �K��Dispose����K�v������
        _playerInputs?.Dispose();
    }

    private void Start()
    {
        _actionStateMachine = gameObject.GetOrAddComponent<PlayerActionStateMachine>();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Move�A�N�V�����̓��͎擾
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // �A�N�V�������͍X�V
        {
            // �ړ��������擾
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

        // ���]�ł���悤�ɂ���
        FlipSpriteRenderer();
    }

    private void FixedUpdate()
    {
        //// �ʒu���ړ�������
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
