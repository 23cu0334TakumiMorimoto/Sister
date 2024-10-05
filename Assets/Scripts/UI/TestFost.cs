using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestFost : MonoBehaviour
{
    public int SpriteNumber; //����邽�߂̔ԍ���ݒu
    public GameObject TextDisplay; //�\�����邽�߂̃e�L�X�g���w��
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        string SpriteText = SpriteNumber.ToString();
        TextDisplay.GetComponent<TextMeshProUGUI>().text = "";
        for (int i = 0; i <= SpriteText.Length - 1; i++)
        {
            TextDisplay.GetComponent<TextMeshProUGUI>().text += "<sprite=" + SpriteText[i] + ">";
        }
    }
}
