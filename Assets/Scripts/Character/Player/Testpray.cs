using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testpray : MonoBehaviour
{
    public GameObject Prayarea;       //�G���A�̃I�u�W�F�N�g
    public float Expandspeed;         //�G���A���傫���Ȃ鑬��
    public float Areasize;            //�G���A�����X�ɑ傫�����邽�߂̒l�����Z���Ă������߂̕ϐ�


    private float _time;              //���Ԍv�����邽�߂̕ϐ�
    private Vector3 _infancysize;     //�ŏ��̑傫����ۑ����邽��
    Transform _ts;
    // Start is called before the first frame update
    void Start()
    {
        //�����̑傫�������Ă���
        _infancysize = new Vector3(1.0f,1.0f,1.0f);
        _time = 0;
        Prayarea = GameObject.Find("Circle");
       // Instantiate(Prayarea, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍv��
        _time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            //�G���A���傫���Ȃ鑬��
            if (_time > Expandspeed)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //���X�ɉ��Z
                    Areasize++;

                    //���Ԃ����Z�b�g����
                    _time = 0;

                }
            }
            //�l�����Z���A�傫������
            Prayarea.transform.localScale = new Vector3(Areasize, Areasize, Areasize);
        }
       
        //���̑傫���ɖ߂�
        Prayarea.transform.localScale = _infancysize;
    }
    
}
