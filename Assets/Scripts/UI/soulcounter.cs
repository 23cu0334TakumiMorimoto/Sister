using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class soulcounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;        //テキストを格納するための変数
    private int count;                                //今持っている魂に加算したり減らしたりするための変数
    private float timeReset;                          //時間で加算、減算のスピードを操作できるようにタイマーをリセットするための変数
    private float time;                               //現在の時間の経過を格納するための変数
    private int currentsoul;                          //現在の魂の数を格納するための変数
    // Start is called before the first frame update
    void Start()
    {
        //初期化する
        count = 0;
        time = 0;
        timeReset = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //現在の魂の数を代入し、比較できるようにする
        count = currentsoul;

        //左キーで10足す
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            currentsoul+=10;
        }
        //右キーで10引く
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentsoul-=10;
        }

        //現在の経過を代入
        time += Time.deltaTime;

        //徐々に加算、減算ができるようにリセットの値より多いときに処理
        if (time > timeReset)
        {
            //加算されたときカウントが現在の魂の数より少ないなら
            if (count < currentsoul)
            {
                //徐々に加算
                count++;
                time = 0;
            }
            //減算されたときカウントが現在の魂の数より多いなら
            if (count>currentsoul)
            {
                //徐々に減算
                count--;
                time = 0;
            }
        }
        //テキストに代入する
        countText.text = count.ToString();
    }
}
