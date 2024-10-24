using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevel : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField]
    private NecessarySoul _lvData;
    [SerializeField]
    private NewGodData _godData;

    //表示するためのテキストを指定
    public GameObject TextDisplay;
    //TextMeshProUGUIを格納するための変数
    private TextMeshProUGUI _testtext;
    //入れるための番号を設置
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


    //数値を文字列に変換し、スプライトとして表示する関数
    private string FormatNumber(int number)
    {
        // 数値を文字列に変換
        //D3はフォーマット指定子。詳しいことは勉強する
        string numberString = number.ToString("D4");

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
