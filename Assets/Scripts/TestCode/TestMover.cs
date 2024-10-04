using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMover : MonoBehaviour
{
    [SerializeField]
    [Header("�ړ��X�s�[�h")]
    private float _moveSpeed;

    private SpriteRenderer _sr;
    private Rigidbody2D _rigidbody;
    private PlayerInputs _gameInputs;
    private Vector2 _moveInputValue;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;

        // Action�X�N���v�g�̃C���X�^���X����
        _gameInputs = new PlayerInputs();

        // Action�C�x���g�o�^
        _gameInputs.Player.Move.started += OnMove;
        _gameInputs.Player.Move.performed += OnMove;
        _gameInputs.Player.Move.canceled += OnMove;

        // Input Action���@�\�����邽�߂ɂ́A
        // �L��������K�v������
        _gameInputs.Enable();
    }

    private void OnDestroy()
    {
        // ���g�ŃC���X�^���X������Action�N���X��IDisposable���������Ă���̂ŁA
        // �K��Dispose����K�v������
        _gameInputs?.Dispose();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Move�A�N�V�����̓��͎擾
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate()
    {
        // �ʒu���ړ�������
        _rigidbody.velocity = (new Vector2(
            _moveInputValue.x,
            _moveInputValue.y
        ) * _moveSpeed);
    }

    private void FlipSprite()
    {
        // ���݂̃L�[�{�[�h���
        var current = Keyboard.current;

        // �L�[�{�[�h�ڑ��`�F�b�N
        if (current == null)
        {
            // �L�[�{�[�h���ڑ�����Ă��Ȃ���
            // Keyboard.current��null�ɂȂ�
            return;
        }

        // �L�[�̓��͏�Ԏ擾
        var aKey = current.aKey;
        var dKey = current.dKey;

        // A�L�[��������Ă��邩�ǂ���
        if (aKey.isPressed)
        {
            if (_sr.flipX == true)
            {
                _sr.flipX = false;
            }
        }

        // D�L�[��������Ă��邩�ǂ���
        if (dKey.isPressed)
        {
            if (_sr.flipX == false)
            {
                _sr.flipX = true;
            }
        }
    }
}