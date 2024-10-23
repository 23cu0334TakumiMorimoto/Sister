using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestFost : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    private NewGodData _statusdata;

    public GameObject TextDisplay;           //�\�����邽�߂̃e�L�X�g���w��

    public int SpriteNumber;                 //����邽�߂̔ԍ���ݒu
    public string SpriteText = "0123456789"; // �X�v���C�g�e�L�X�g�������Ŏw��
    public float Timespeed;                  //������萔�l�𑫂��Ă������߂̃X�s�[�h�ϐ�

    private TextMeshProUGUI _testtext;       //TextMeshProUGUI���i�[���邽�߂̕ϐ�
    private int _currentsoul;                //���݂̍��̐�
    private float _time;                     //���Ԍv�����邽�߂̕ϐ�
    // Start is called before the first frame update
    void Start()
    {
        _testtext = TextDisplay.GetComponent<TextMeshProUGUI>();
        SpriteNumber = 0;
        _time = 0;
        _statusdata.EXP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̍��𔽉f����
        _currentsoul = _statusdata.EXP;

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    _statusdata.EXP -= 10;
        //}

        // ���Ԍv��
        _time += Time.deltaTime;

        //�������Z����Ȃ��悤�ɂ��ăJ�E���^�[���i��ł���悤�Ɍ�����
        if (_time > Timespeed)
        {
            // 999�܂Ŏw�肵�Ă����B�܂����݂̍��̐���葝���Ă���Ȃ�ǉ�����
            if (SpriteNumber<_currentsoul && SpriteNumber < 999) // 0����999�܂�
            {
                //���l��������悤�Ɍ����邽�߂P�������Ă���
                SpriteNumber++;
                // ���Ԃ����Z�b�g
                _time = 0;
            }
            // 999�܂Ŏw�肵�Ă����B�܂����݂̍��̐���茸���Ă���Ȃ猸�Z����
            else if (SpriteNumber > _currentsoul && SpriteNumber < 999) // 0����999�܂�
            {
                //���l������悤�Ɍ����邽�߂P�������Ă���
                SpriteNumber--;
                // ���Ԃ����Z�b�g
                _time = 0;
            }
        }

        // ���l�������Ƃɕ\������
        _testtext.text = FormatNumber(SpriteNumber);
       
    }
    //���l�𕶎���ɕϊ����A�X�v���C�g�Ƃ��ĕ\������֐�
    private string FormatNumber(int number)
    {
        // ���l�𕶎���ɕϊ�
        //D3�̓t�H�[�}�b�g�w��q�B�ڂ������Ƃ͕׋�����
        string numberString = number.ToString("D3");
        
        // �e�����X�v���C�g�Ƃ��ĕ\�����邽�߂ɕ������ϊ�

        string result = "";//result�́A�ŏI�I�ɃX�v���C�g��\�����邽�߂̕������~����ϐ�

        //numberString�̊e�����i���j��������o�����߂̃��[�v
        foreach (char digit in numberString)
        {
            // �X�v���C�g�Ƃ��ĕ\�����邽�߂ɁA�e���ɑΉ�����X�v���C�g��ǉ�
            result += "<sprite=" + digit + ">";//"<sprite=" + digit + ">"�̕����́ATextMeshPro�ŃX�v���C�g��\�����邽��
        }
        return result;
    }
}
