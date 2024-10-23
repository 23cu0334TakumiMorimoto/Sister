using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Soul : MonoBehaviour
{
    // �v���C���[��ǔ����鎞�̉����x�A���l���傫���قǂ�����������
    private float m_followAccel = 0.01f;
    private bool m_isFollow; // �v���C���[��ǔ����郂�[�h�ɓ������ꍇ true
    private float m_followSpeed; // �v���C���[��ǔ����鑬��

    private float m_speed; // �U��΂鎞�̑���
    private float speedMin = 0.005f; //0.0125f; // ��������A�C�e���̈ړ��̑����i�ŏ��l�j
    private float speedMax = 0.1f; //0.075f; // ��������A�C�e���̈ړ��̑����i�ő�l�j
    private float m_brake = 0.9f; // �U��΂鎞�̌����ʁA���l���������قǂ�����������
    private Vector3 m_direction;

    private GameObject _player;
    private Vector3 _playerPos;
    private float _distancePos;

    [SerializeField]
    [Header("�z�������܂ł̎���")]
    private float _absorbTime;
    private float _timer;

    [SerializeField]
    private PlayerData _playerdata;

    private bool _absorb;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("God");
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _playerPos = _player.transform.localPosition;
        _distancePos = Vector3.Distance(_playerPos, transform.localPosition);

        if(_absorbTime < _timer)
        {
            // �v���C���[�̌��݈ʒu�֌������x�N�g�����쐬����
            var direction = _playerPos - transform.localPosition;
            direction.Normalize();

            // �A�C�e�����v���C���[�����݂�������Ɉړ�����
            transform.localPosition += direction * m_followSpeed;

            // �������Ȃ���߂Â�
            m_followSpeed += m_followAccel;

            // �t���O�X�V
            _absorb = true;
        }
       

        // �U��΂鑬�x���v�Z����
        var velocity = m_direction * m_speed;

        // �U��΂�
        transform.localPosition += velocity;

        // ���񂾂񌸑�����
        m_speed *= m_brake;
    }

    private void Init()
    {
        // �A�C�e�����ǂ̕����ɎU��΂邩�����_���Ɍ��肷��
        var angle = Random.Range(0, 360);

        // �i�s���������W�A���l�ɕϊ�����
        var f = angle * Mathf.Deg2Rad;

        // �i�s�����̃x�N�g�����쐬����
        m_direction = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0);

        // �A�C�e���̎U��΂鑬���������_���Ɍ��肷��
        m_speed = Mathf.Lerp(speedMin, speedMax, Random.value);

        // 8 �b��ɃA�C�e�����폜����
        Destroy(gameObject, 8);
    }

    // ���̃I�u�W�F�N�g�ƏՓ˂������ɌĂяo�����֐�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_absorb == true)
        {
            if (collision.gameObject.tag == "God")
            {
                // �A�C�e�����폜����
                Destroy(gameObject);
            }
        }
        


    }
}
