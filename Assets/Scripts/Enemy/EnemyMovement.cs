using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject God;
    Vector3 GodPos;

    private float speed = 0.5f;

    Vector3 diff;
    Vector3 vector;

    void Start()
    {
        God = GameObject.FindGameObjectWithTag("God");
        GodPos = God.transform.position;
        this.transform.LookAt(GodPos);

    }
    void Update()
    {
        //�_�̌��݈ʒu���擾
        GodPos = God.transform.position;
        //���݈ʒu����_�̈ʒu�Ɍ����Ĉړ�
        transform.position = Vector2.MoveTowards(transform.position, GodPos, speed * Time.deltaTime);
        //�_�ƓG�L������X���̈ʒu�֌W���擾����
        diff.x = GodPos.x - this.transform.position.x;
        if (diff.x > 0)
        {
            // God���G�L�����̉E���ɂ��鎞�E��������
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        if (diff.x < 0)
        {
            // God���G�L�����̍����ɂ��鎞����������
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }
    }

}