using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyMovement[] _enemyMove;       //���j���[�Ȃǂ̃{�^�����i�[���邽�߂̔z��ϐ�

    private enum _movement
    {
        Bat,
        Goat,
        Cow
    }
    [SerializeField] _movement EnemyMove;�@�@�@�@//�v���_�E����

    private GameObject _god;
    private GameObject _player;
    private Vector3 _godPos;
    private Vector3 _playerPos;

    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    public StatusData statusdata;

    private Vector3 _diff;
    private Vector3 _vector;

    IsDamaged Dead;

    private Rigidbody2D _rb;
    Animator _animator;

    // �^�C�}�[
    float t;
    private float _bossTimer;

    // �t���O
    private bool _bossAttack;

    private float _speed = 3.5f;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_godPos);
        _rb = GetComponent<Rigidbody2D>();
        Dead = gameObject.GetComponent<IsDamaged>();

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �R�E����
        if(EnemyMove == _movement.Bat)
        {
            DevilBat();
        }
        // ���M
        else if (EnemyMove == _movement.Goat)
        {
            DevilGoat();
        }
        // ��
        else if (EnemyMove == _movement.Cow)
        {
            DevilCow();
        }
    }

    private void DevilBat()
    {
        // ������Ԃł͂Ȃ��Ȃ珈��
        if (Dead.IsDead == false)
        {
            //�_�̌��݈ʒu���擾
            _godPos = _god.transform.position;
            //���݈ʒu����_�̈ʒu�Ɍ����Ĉړ�
            transform.position = Vector2.MoveTowards(transform.position, _godPos, statusdata.SPEED * Time.deltaTime);
            //�_�ƓG�L������X���̈ʒu�֌W���擾����
            _diff.x = _godPos.x - this.transform.position.x;

            if (_diff.x > 0)
            {
                // God���G�L�����̉E���ɂ��鎞�E��������
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // God���G�L�����̍����ɂ��鎞����������
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }
        }
    }

    private void DevilGoat()
    {
        // ������Ԃł͂Ȃ��Ȃ珈��
        if (Dead.IsDead == false)
        {
            //�_�̌��݈ʒu���擾
            _godPos = _god.transform.position;
            t += Time.deltaTime;
            float x = statusdata.CircleX * Mathf.Cos(t * statusdata.SPEED);
            float y = statusdata.CircleY * Mathf.Sin(t * statusdata.SPEED);
            transform.position
                = new Vector3(_godPos.x + x, _godPos.y + y, 0.0f);
            transform.rotation = Quaternion.identity;

            if (_diff.x > 0)
            {
                // God���G�L�����̉E���ɂ��鎞�E��������
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // God���G�L�����̍����ɂ��鎞����������
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }
        }
    }

    private void DevilCow()
    {
        // ������Ԃł͂Ȃ��Ȃ珈��
        if (Dead.IsDead == false)
        {
            _bossTimer += Time.deltaTime;
            //�v���C���[�̌��݈ʒu���擾
            _playerPos = _player.transform.position;

            if (_bossAttack != true)
            {
                //���݈ʒu����v���C���[�̈ʒu�Ɍ����Ĉړ�
                transform.position = Vector2.MoveTowards(transform.position, _playerPos, statusdata.SPEED * Time.deltaTime);
                //�_�ƓG�L������X���̈ʒu�֌W���擾����
                _diff.x = _godPos.x - this.transform.position.x;

            }

            if (_diff.x > 0)
            {
                // God���G�L�����̉E���ɂ��鎞�E��������
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // God���G�L�����̍����ɂ��鎞����������
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }

            // �ːi�U��
            if (_bossTimer >= 10)
            {
                _bossAttack = true;
                _animator.SetInteger("Action", 2);
            }

            if (_bossTimer >= 15 && _bossAttack == true)
            {
                Debug.Log("�U��");
                _bossTimer = 0;
                _bossAttack = false;
                _rb.velocity = (_playerPos - transform.position).normalized * _speed;
                //_rb.AddForce(_playerPos.normalized - transform.position.normalized * _speed, ForceMode2D.Impulse);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            _rb.velocity = Vector2.zero;
            _animator.SetInteger("Action", 0);
        }
        else if (col.gameObject.tag == "God")
        {
            _animator.SetInteger("Action", 0);
        }

    }
}