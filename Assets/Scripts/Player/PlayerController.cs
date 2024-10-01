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
    // �p�x��������
    private Vector3 _worldAngle;

    public int MoveDirection { get; private set; }


    private void Awake()
    {
        // �ϐ��̏������E�l�̎擾
        MoveDirection = 0;

        // Action�X�N���v�g�̃C���X�^���X����
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        // Input Action���@�\�����邽�߂ɂ́A
        // �L��������K�v������
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        // ���g�ŃC���X�^���X������Action�N���X��IDisposable���������Ă���̂ŁA
        // �K��Dispose����K�v������
        _playerInputs?.Disable();
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

    private void FixedUpdate()
    {
        transform.position += new Vector3(_moveInputValue.x * _moveSpeed, _moveInputValue.y * _moveSpeed * Time.deltaTime, 0);
    }

}
