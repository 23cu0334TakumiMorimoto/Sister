using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayWaveNum : MonoBehaviour
{
    //TextMeshProUGUI���i�[���邽�߂̕ϐ�
    private TextMeshProUGUI _testtext;

    private GameObject _gameManager;
    private EnemyGeneratePattern1 _stage1;
    private EnemyGeneratePattern1 _stage2;
    private EnemyGeneratePattern1 _stage3;

    private int _spriteNumber;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _testtext = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "TestMainGame")
        {
            _stage1 = _gameManager.GetComponent<EnemyGeneratePattern1>();
            _spriteNumber = _stage1.NowWave;
            _testtext.text = FormatNumber(_spriteNumber);
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            //_stage2 = _gameManager.GetComponent<EnemyGeneratePattern2>();
            //_spriteNumber = _stage2.NowWave;
            //_testtext.text = FormatNumber(_spriteNumber);
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            //_stage3 = _gameManager.GetComponent<EnemyGeneratePattern3>();
            //_spriteNumber = _stage3.NowWave;
            //_testtext.text = FormatNumber(_spriteNumber);
        }
        else
        {
            _testtext.text = "?";
        }
    }

    //���l�𕶎���ɕϊ����A�X�v���C�g�Ƃ��ĕ\������֐�
    private string FormatNumber(int number)
    {
        // ���l�𕶎���ɕϊ�
        //D3�̓t�H�[�}�b�g�w��q�B�ڂ������Ƃ͕׋�����
        string numberString = number.ToString("D1");

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
