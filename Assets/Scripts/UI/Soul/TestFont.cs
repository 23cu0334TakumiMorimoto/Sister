using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestFost : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField]
    private NewGodData _statusdata;

    public GameObject TextDisplay;           //表示するためのテキストを指定

    public int SpriteNumber;                 //入れるための番号を設置
    public string SpriteText = "0123456789"; // スプライトテキストをここで指定
    public float Timespeed;                  //ゆっくり数値を足していくためのスピード変数

    private TextMeshProUGUI _testtext;       //TextMeshProUGUIを格納するための変数
    private int _currentsoul;                //現在の魂の数
    private float _time;                     //時間計測するための変数
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
        // プレイヤーの魂を反映する
        _currentsoul = _statusdata.EXP;

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    _statusdata.EXP -= 10;
        //}

        // 時間計測
        _time += Time.deltaTime;

        //早く加算されないようにしてカウンターが進んでいるように見せる
        if (_time > Timespeed)
        {
            // 999まで指定しておく。また現在の魂の数より増えているなら追加する
            if (SpriteNumber<_currentsoul && SpriteNumber < 999) // 0から999まで
            {
                //数値が増えるように見せるため１ずつ足していく
                SpriteNumber++;
                // 時間をリセット
                _time = 0;
            }
            // 999まで指定しておく。また現在の魂の数より減っているなら減算する
            else if (SpriteNumber > _currentsoul && SpriteNumber < 999) // 0から999まで
            {
                //数値が減るように見せるため１ずつ引いていく
                SpriteNumber--;
                // 時間をリセット
                _time = 0;
            }
        }

        // 数値を桁ごとに表示する
        _testtext.text = FormatNumber(SpriteNumber);
       
    }
    //数値を文字列に変換し、スプライトとして表示する関数
    private string FormatNumber(int number)
    {
        // 数値を文字列に変換
        //D3はフォーマット指定子。詳しいことは勉強する
        string numberString = number.ToString("D3");
        
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
