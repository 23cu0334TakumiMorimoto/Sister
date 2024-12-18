using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayStageNum : MonoBehaviour
{
    //TextMeshProUGUIを格納するための変数
    private TextMeshProUGUI _testtext;

    private int _spriteNumber;

    // Start is called before the first frame update
    void Start()
    {
        _testtext = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "TestMainGame")
        {
            _spriteNumber = 1;
            _testtext.text = FormatNumber(_spriteNumber);
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            _spriteNumber = 2;
            _testtext.text = FormatNumber(_spriteNumber);
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            _spriteNumber = 3;
            _testtext.text = FormatNumber(_spriteNumber);
        }
        else
        {
            _testtext.text = "?";
        }
    }

    private string FormatNumber(int number)
    {
        // 数値を文字列に変換
        //D3はフォーマット指定子。詳しいことは勉強する
        string numberString = number.ToString("D1");

        // 各桁をスプライトとして表示するために文字列を変換

        string result = "";//resultは、最終的にスプライトを表示するための文字列を蓄える変数

        //numberStringの各文字（桁）を一つずつ取り出すためのループ
        foreach (char digit in numberString)
        {
            // スプライトとして表示するために、各桁に対応するスプライトを追加
            result += "<sprite=" + digit + ">";//"<sprite=" + digit + ">"の部分は、TextMeshProでスプライトを表示するため
        }
        return result;
    }
}
