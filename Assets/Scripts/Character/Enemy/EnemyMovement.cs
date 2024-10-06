using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject _god;
    private Vector3 _godPos;

    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField] StatusData statusdata;

    private Vector3 _diff;
    private Vector3 _vector;

    void Start()
    {
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_godPos);
    }
    void Update()
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