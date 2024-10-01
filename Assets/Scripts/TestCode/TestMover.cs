using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMover: MonoBehaviour
{
    int speed = 2;//�ړ��X�s�[�h
    Vector3 worldAngle;//�p�x��������

    void Start() { }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {//���オ������Ă��鎞�Ɏ��s�����
            if (this.transform.position.y < 5)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {//��󉺂�������Ă��鎞�Ɏ��s�����
            if (this.transform.position.y > -5)
            {
                transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {//��󍶂�������Ă��鎞�Ɏ��s�����
            if (this.transform.position.x > -3)
            {
                worldAngle.y = 0f;//�ʏ�̌���
                this.transform.localEulerAngles = worldAngle;//�����̊p�x�ɑ������
                transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {//���E��������Ă��鎞�Ɏ��s�����
            if (this.transform.position.x < 3)
            {
                worldAngle.y = -180f;//�E�����̊p�x
                this.transform.localEulerAngles = worldAngle;//�����̊p�x�ɑ��
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}