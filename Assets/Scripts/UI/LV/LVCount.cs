using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVCount : MonoBehaviour
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

    private int _nowLevel;

    private GameObject _gameManager;
    private CallUI _callUI;


    void Start()
    {
        // 神の像のステータス初期化
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
        // 数値を桁ごとに表示する
        _testtext.text = FormatNumber(SpriteNumber);
    }

    private void CaluculateSoul ()
    {
        if (_godData.EXP >= _lvData.playerExpTable[_nowLevel].exp)
        {
            _godData.LV += 1;
            _nowLevel += 1;

            // レベルアップウィンドウを呼び出す
            _callUI.LVUP();
        }
    }

    //数値を文字列に変換し、スプライトとして表示する関数
    private string FormatNumber(int number)
    {
        // 数値を文字列に変換
        //D3はフォーマット指定子。詳しいことは勉強する
        string numberString = number.ToString("D2");

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
