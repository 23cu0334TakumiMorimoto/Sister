using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestFost : MonoBehaviour
{
    public int SpriteNumber; //入れるための番号を設置
    public GameObject TextDisplay; //表示するためのテキストを指定
    private TextMeshProUGUI Testtext;
    public string SpriteText = "0123456789"; // スプライトテキストをここで指定

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
        // 時間計測
        time += Time.deltaTime;

        // 0.2より早く加算されないようにしてカウンターが進んでいるように見せる
        if (time > timeReset)
        {
            // 右矢印キーが押された場合、数値を増加
            if (SpriteNumber<currentsoul && SpriteNumber < 999) // 0から999まで
            {
                SpriteNumber++;
                // 時間をリセット
                time = 0;
            }
        }
        // 数値を桁ごとに表示する
        Testtext.text = FormatNumber(SpriteNumber);
        //string SpriteText = SpriteNumber.ToString();
        //TextDisplay.GetComponent<TextMeshProUGUI>().text = "";
        //for (int i = 0; i <= SpriteText.Length - 1; i++)
        //{
        //    TextDisplay.GetComponent<TextMeshProUGUI>().text += "<sprite=" + SpriteText[i] + ">";
        //}

        //時間計測
        //time += Time.deltaTime;

        ////0.01より早く加算されないようにしてカウンターが進んでいるように見せる
        //if (time > timeReset)
        //{
        //    //10の値を魂の獲得数として加算していく
        //    if (Input.GetKeyDown(KeyCode.RightArrow) && SpriteNumber < SpriteText.Length -1)
        //    {
        //        //1ずつ足していって増えているようにみせる
        //        SpriteNumber++;
        //        //時間をリセット
        //        time = 0;
        //    }
        //}
        //// SpriteTextの範囲内で表示
        //    Testtext.text = "<sprite=" + SpriteText[SpriteNumber] + ">";

        //SpriteText = SpriteNumber.ToString();
        //Testtext.text = "<sprite=" + SpriteText[SpriteNumber] + ">";
    }
    private string FormatNumber(int number)
    {
        // 数値を文字列に変換
        //D3はフォーマット指定子。
        string numberString = number.ToString("D3");

        // 各桁をスプライトとして表示するために文字列を変換
        string result = "";
        foreach (char digit in numberString)
        {
            // スプライトとして表示するために、各桁に対応するスプライトを追加
            result += "<sprite=" + digit + ">";
        }
        return result;
    }
}
