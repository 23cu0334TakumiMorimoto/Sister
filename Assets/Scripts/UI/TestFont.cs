using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestFost : MonoBehaviour
{
    public int SpriteNumber; //����邽�߂̔ԍ���ݒu
    public GameObject TextDisplay; //�\�����邽�߂̃e�L�X�g���w��
    private TextMeshProUGUI Testtext;
    public string SpriteText = "0123456789"; // �X�v���C�g�e�L�X�g�������Ŏw��

    private int currentsoul;
    private float timeReset;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        Testtext = TextDisplay.GetComponent<TextMeshProUGUI>();
        SpriteNumber = 0;
        time = 0;
        timeReset = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentsoul += 10;
        }
        // ���Ԍv��
        time += Time.deltaTime;

        // 0.2��葁�����Z����Ȃ��悤�ɂ��ăJ�E���^�[���i��ł���悤�Ɍ�����
        if (time > timeReset)
        {
            // �E���L�[�������ꂽ�ꍇ�A���l�𑝉�
            if (SpriteNumber<currentsoul && SpriteNumber < 999) // 0����999�܂�
            {
                SpriteNumber++;
                // ���Ԃ����Z�b�g
                time = 0;
            }
        }
        // ���l�������Ƃɕ\������
        Testtext.text = FormatNumber(SpriteNumber);
        //string SpriteText = SpriteNumber.ToString();
        //TextDisplay.GetComponent<TextMeshProUGUI>().text = "";
        //for (int i = 0; i <= SpriteText.Length - 1; i++)
        //{
        //    TextDisplay.GetComponent<TextMeshProUGUI>().text += "<sprite=" + SpriteText[i] + ">";
        //}

        //���Ԍv��
        //time += Time.deltaTime;

        ////0.01��葁�����Z����Ȃ��悤�ɂ��ăJ�E���^�[���i��ł���悤�Ɍ�����
        //if (time > timeReset)
        //{
        //    //10�̒l�����̊l�����Ƃ��ĉ��Z���Ă���
        //    if (Input.GetKeyDown(KeyCode.RightArrow) && SpriteNumber < SpriteText.Length -1)
        //    {
        //        //1�������Ă����đ����Ă���悤�ɂ݂���
        //        SpriteNumber++;
        //        //���Ԃ����Z�b�g
        //        time = 0;
        //    }
        //}
        //// SpriteText�͈͓̔��ŕ\��
        //    Testtext.text = "<sprite=" + SpriteText[SpriteNumber] + ">";

        //SpriteText = SpriteNumber.ToString();
        //Testtext.text = "<sprite=" + SpriteText[SpriteNumber] + ">";
    }
    private string FormatNumber(int number)
    {
        // ���l�𕶎���ɕϊ�
        //D3�̓t�H�[�}�b�g�w��q�B
        string numberString = number.ToString("D3");

        // �e�����X�v���C�g�Ƃ��ĕ\�����邽�߂ɕ������ϊ�
        string result = "";
        foreach (char digit in numberString)
        {
            // �X�v���C�g�Ƃ��ĕ\�����邽�߂ɁA�e���ɑΉ�����X�v���C�g��ǉ�
            result += "<sprite=" + digit + ">";
        }
        return result;
    }
}
