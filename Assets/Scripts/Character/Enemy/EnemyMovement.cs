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
    private Vector3 _godPos;

    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    public StatusData statusdata;

    private Vector3 _diff;
    private Vector3 _vector;

    IsDamaged Dead;

    Rigidbody2D rb;
    Animator _animator;

    // �^�C�}�[
    float t;

    private void Start()
    {
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_godPos);
        rb = GetComponent<Rigidbody2D>();
        Dead = gameObject.GetComponent<IsDamaged>();
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
}