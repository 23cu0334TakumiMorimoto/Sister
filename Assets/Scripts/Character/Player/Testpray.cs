using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testpray : MonoBehaviour
{
    public GameObject Prayarea;       //エリアのオブジェクト
    public float Expandspeed;         //エリアが大きくなる速さ
    public float Areasize;            //エリアを徐々に大きくするための値を加算していくための変数


    private float _time;              //時間計測するための変数
    private Vector3 _infancysize;     //最初の大きさを保存するため
    Transform _ts;
    // Start is called before the first frame update
    void Start()
    {
        //初期の大きさを入れておく
        _infancysize = new Vector3(1.0f,1.0f,1.0f);
        _time = 0;
        Prayarea = GameObject.Find("Circle");
       // Instantiate(Prayarea, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        _time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            //エリアが大きくなる速さ
            if (_time > Expandspeed)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //徐々に加算
                    Areasize++;

                    //時間をリセットする
                    _time = 0;

                }
            }
            //値を加算し、大きくする
            Prayarea.transform.localScale = new Vector3(Areasize, Areasize, Areasize);
        }
       
        //元の大きさに戻す
        Prayarea.transform.localScale = _infancysize;
    }
    
}
