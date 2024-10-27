using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMover : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
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
        // ���݂̃L�[�{�[�h���
        var current = Keyboard.current;


        // �L�[�{�[�h�ڑ��`�F�b�N
        if (current == null)
        {
            // �L�[�{�[�h���ڑ�����Ă��Ȃ���
            // Keyboard.current��null�ɂȂ�
            return;
        }

        //// �L�[�̓��͏�Ԏ擾
        //var aKey = current.aKey;
        //var leftArrowKey = current.leftArrowKey;
        //var dKey = current.dKey;
        //var rightArrowKey = current.rightArrowKey;
        //// �Q�[���p�b�h�i�f�o�C�X�擾�j
        //var gamepad = Gamepad.current;
        //if (gamepad == null) return;
        //// �Q�[���p�b�h�̍��E�̃X�e�B�b�N�̓��͒l���擾
        //var x = gamepad.leftStick.x.ReadValue();
        //var y = gamepad.leftStick.y.ReadValue();

        //�΂߂̈ړ������𐳋K���������s���ψꉻ����
        Vector2 dir = new Vector2(_moveInputValue.x, _moveInputValue.y).normalized;

        //���݂̏�Ԃ��V�X�^�[�̎�
        if (statusdata.PLAYER_PERSON == 0)
        {
            // �F���Ă��Ȃ��Ȃ�
            if (statusdata.IsPrayed != true)
            {
                // �ʒu���ړ�������
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
            // �F���Ă���Ȃ�
            else
            {
                // ���x���O�ɂ���
                _rigidbody.velocity = new Vector2(0, 0);
                _animator.SetInteger("Action", 2);
            }
        }
        // ���݂̏�Ԃ��f�r���̎�
        if (statusdata.PLAYER_PERSON == 1)
        {
            // �ʒu���ړ�������
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
        var leftArrowKey = current.leftArrowKey;
        var dKey = current.dKey;
        var rightArrowKey = current.rightArrowKey;
        //// �Q�[���p�b�h�i�f�o�C�X�擾�j
        //var gamepad = Gamepad.current;
        //if (gamepad == null) return;
        //// �Q�[���p�b�h�̍��E�̃X�e�B�b�N�̓��͒l���擾
        //var x = gamepad.leftStick.x.ReadValue();
        //var y = gamepad.leftStick.y.ReadValue();

        // A�L�[�������͍��L�[��������Ă��邩�ǂ���
        if (aKey.isPressed || leftArrowKey.isPressed) //|| x < 0)
        {
            if (_sr.flipX == true)
            {
                _sr.flipX = false;
            }
        }

        // D�L�[�������͉E�L�[��������Ă��邩�ǂ���
        if (dKey.isPressed || rightArrowKey.isPressed) //|| x > 0)
        {
            if (_sr.flipX == false)
            {
                _sr.flipX = true;
            }
        }
    }
}