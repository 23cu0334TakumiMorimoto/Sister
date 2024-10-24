using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevel : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    private NecessarySoul _lvData;
    [SerializeField]
    private NewGodData _godData;

    //�\�����邽�߂̃e�L�X�g���w��
    public GameObject TextDisplay;
    //TextMeshProUGUI���i�[���邽�߂̕ϐ�
    private TextMeshProUGUI _testtext;
    //����邽�߂̔ԍ���ݒu
    public int SpriteNumber;


    // Start is called before the first frame update
    void Start()
    {
        _testtext = TextDisplay.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteNumber = _lvData.playerExpTable[_godData.LV].exp;
        _testtext.text = FormatNumber(SpriteNumber);
    }


    //���l�𕶎���ɕϊ����A�X�v���C�g�Ƃ��ĕ\������֐�
    private string FormatNumber(int number)
    {
        // ���l�𕶎���ɕϊ�
        //D3�̓t�H�[�}�b�g�w��q�B�ڂ������Ƃ͕׋�����
        string numberString = number.ToString("D4");

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
