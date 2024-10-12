using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class soulcounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;        //�e�L�X�g���i�[���邽�߂̕ϐ�
    private int count;                                //�������Ă��鍰�ɉ��Z�����茸�炵���肷�邽�߂̕ϐ�
    private float timeReset;                          //���Ԃŉ��Z�A���Z�̃X�s�[�h�𑀍�ł���悤�Ƀ^�C�}�[�����Z�b�g���邽�߂̕ϐ�
    private float time;                               //���݂̎��Ԃ̌o�߂��i�[���邽�߂̕ϐ�
    private int currentsoul;                          //���݂̍��̐����i�[���邽�߂̕ϐ�
    // Start is called before the first frame update
    void Start()
    {
        //����������
        count = 0;
        time = 0;
        timeReset = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̍��̐��������A��r�ł���悤�ɂ���
        count = currentsoul;

        //���L�[��10����
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            currentsoul+=10;
        }
        //�E�L�[��10����
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentsoul-=10;
        }

        //���݂̌o�߂���
        time += Time.deltaTime;

        //���X�ɉ��Z�A���Z���ł���悤�Ƀ��Z�b�g�̒l��葽���Ƃ��ɏ���
        if (time > timeReset)
        {
            //���Z���ꂽ�Ƃ��J�E���g�����݂̍��̐���菭�Ȃ��Ȃ�
            if (count < currentsoul)
            {
                //���X�ɉ��Z
                count++;
                time = 0;
            }
            //���Z���ꂽ�Ƃ��J�E���g�����݂̍��̐���葽���Ȃ�
            if (count>currentsoul)
            {
                //���X�Ɍ��Z
                count--;
                time = 0;
            }
        }
        //�e�L�X�g�ɑ������
        countText.text = count.ToString();
    }
}
