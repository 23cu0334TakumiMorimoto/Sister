using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVCount : MonoBehaviour
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

    private int _nowLevel;

    private GameObject _gameManager;
    private CallUI _callUI;


    void Start()
    {
        // �_�̑��̃X�e�[�^�X������
        _godData.LV = 1;
        _godData.EXP = 0;

        _testtext = TextDisplay.GetComponent<TextMeshProUGUI>();
        SpriteNumber = 0;
        _nowLevel = 1;

        _gameManager = GameObject.Find("GameManager");
        _callUI = _gameManager.GetComponent<CallUI>();
    }

    void Update()
    {
        SpriteNumber = _godData.LV;
        CaluculateSoul();
        // ���l�������Ƃɕ\������
        _testtext.text = FormatNumber(SpriteNumber);
    }

    private void CaluculateSoul ()
    {
        if (_godData.EXP >= _lvData.playerExpTable[_nowLevel].exp)
        {
            _godData.LV += 1;
            _nowLevel += 1;

            // ���x���A�b�v�E�B���h�E���Ăяo��
            _callUI.LVUP();
        }
    }

    //���l�𕶎���ɕϊ����A�X�v���C�g�Ƃ��ĕ\������֐�
    private string FormatNumber(int number)
    {
        // ���l�𕶎���ɕϊ�
        //D3�̓t�H�[�}�b�g�w��q�B�ڂ������Ƃ͕׋�����
        string numberString = number.ToString("D2");

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
