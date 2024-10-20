using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ATKGenerator : MonoBehaviour
{

    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField] PlayerData statusdata;
    // �U������̒e�̃v���n�u
    [SerializeField] private GameObject _atkPrefab;
    // �e�𐶐�������W�̊
    [SerializeField] private Transform _atkCoordinate;
    // �e�𐶐�������W
    private Vector2 _atkPoint;
    // �e�𐶐�����p�x
    private Quaternion _atkRot;
    // ���ˊԊu(�b)
    [SerializeField] private float _fireRate; 
    // �U������
    [SerializeField]
    [Header("�U������")]
    [Header("1:�� 2:�� 3:�� 4:�E")]
    private int _atkDirection;
    private float timer;       // �^�C�}�[
    // �����ōU�����邩�蓮�ōU�����邩
    [SerializeField]
    [Header("�����U��")]
    private bool _autoAttack;

    GameObject gameManagerObj;
    Inoperable IAttacked;

    private bool ATKflg;

    private Rigidbody2D rb;
    private Animator _animator;
    float anim_speed;

    private void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        IAttacked = gameManagerObj.GetComponent<Inoperable>(); // �X�N���v�g���擾
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D�̎擾
        timer = 0;
        ATKflg = false;

        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // �U���������X�V
        GetDirection();
        anim_speed = statusdata.Attack_STIFFNESS;

        if (statusdata.PLAYER_PERSON != 0)
        {
            if (_autoAttack == true)
            {
                // �^�C�}�[���X�V
                timer += Time.deltaTime;

                // �w��̊Ԋu�Œe�𐶐����Ĕ���
                if (timer >= _fireRate)
                {
                    // �e�̐���
                    FireAtk();

                    timer = 0f; // �^�C�}�[�����Z�b�g
                }
            }

            else
            {
                // J�L�[��Z�L�[�ōU��
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
                {
                    ATKflg = true;
                }

                if (ATKflg == true)
                {
                    // �^�C�}�[���X�V
                    timer += Time.deltaTime;
                    // �e�̐���
                    if (timer >= statusdata.Attack_SPAN)
                    {
                        FireAtk();

                        _animator.SetInteger("Action", 5);
                        // �w�肳�ꂽ���ԃv���C���[����𖳌��ɂ���
                        IAttacked.CallInoperable(statusdata.Attack_STIFFNESS, 0);
                        // ���x���O�ɂ���
                        rb.velocity = new Vector2(0, 0);

                        // �^�C�}�[�����Z�b�g
                        timer = 0;
                        // �t���O�����ɖ߂�
                        ATKflg = false;
                    }
                }
            }
        }
    }

    void FireAtk()
    {
        // ���������
        if(_atkDirection == 1)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x, _atkCoordinate.position.y + 1f); 
            _atkRot = Quaternion.Euler(0, 0, 0);
        }
        // ����������
        else if (_atkDirection == 2)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x, _atkCoordinate.position.y - 1f);
            _atkRot = Quaternion.Euler(0, 0, 180);
        }
        // ����������
        else if (_atkDirection == 3)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x - 1f, _atkCoordinate.position.y);
            _atkRot = Quaternion.Euler(0, 0, 270);
        }
        // �E��������
        else if (_atkDirection == 4)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x + 1f, _atkCoordinate.position.y);
            _atkRot = Quaternion.Euler(0, 0, 90);
        }

        // �e�̐���
        Instantiate(_atkPrefab, _atkPoint, _atkRot);
    }

    private void GetDirection()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // �U����������ɐݒ�
            _atkDirection = 1;
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // �U�����������ɐݒ�
            _atkDirection = 2;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // �U�����������ɐݒ�
            _atkDirection = 3;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // �U���������E�ɐݒ�
            _atkDirection = 4;
        }
    }
}