using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamaged : MonoBehaviour
{
    // 他オブジェクトの位置を取得
    private GameObject _player;
    private Vector2 _playerPos;
    private GameObject _god;
    private Vector2 _godPos;

    // ステータスデータを読み込む
    [SerializeField] StatusData statusdata;

    // 攻撃を受けたときに出す画像
    [SerializeField]
    private GameObject Hitmark;
    private Vector3 Hitpos;


    //攻撃を受けるかどうかの切り替えを行う
    bool MUTEKI;

    private float _currentHP;
    private float currentTime = 0f;
   
    private Rigidbody2D rb;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_playerPos);
        _currentHP = statusdata.MAXHP;
        rb = GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
    }
    void Update()
    {
        if (MUTEKI)//攻撃を受けてから0.2秒後にする処理
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.MUTEKI_SPAN)
            {
                currentTime = 0f;
                MUTEKI = false;//無敵状態終わらせる
                rb.velocity = new Vector2(0, 0);//ノックバックをとめる
                Hitmark.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        if (_currentHP <= 0)//HPが0以下になったら消える
        {
            Hitpos = this.transform.position;
            Hitpos.z = -2f;
            Hitmark.transform.position = Hitpos;
            Hitmark.GetComponent<SpriteRenderer>().enabled = true;
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }
    public void Damage(float damage)
    {
        if (!MUTEKI)
        {//無敵状態じゃないときに攻撃を受ける

            Hitpos = this.transform.position;
            Hitpos.z = -2f;//Z軸を敵キャラよりも手前に設定
            Hitmark.transform.position = Hitpos;//ヒットマークの画像位置を移動させる
            Hitmark.GetComponent<SpriteRenderer>().enabled = true; //ヒットマーク画像を表示する

            _currentHP -= damage;//HP減少
            Debug.Log(_currentHP);//現在のHPを表示
            MUTEKI = true;//無敵状態にする
        }
    }
    // 引数１：ノックバックの強さ
    // 引数２：神像に触れたかどうか
    public void NockBack(float nockback, bool IsGod)
    {
        Vector2 thisPos = transform.position;

        //Vector2 distination = new Vector2(thisPos.x - _playerPos.x, thisPos.y - _playerPos.y);//攻撃を受けて時点での敵キャラとプレイヤーとの位置関係   
        //Debug.Log(distination);
        //rb.AddForce(distination * nockback, ForceMode2D.Impulse);
        //// 初期化
        //distination = Vector2.zero;

        if(IsGod == true)
        {
            //攻撃を受けた時点での敵キャラと神像との位置関係
            float distinationX = thisPos.x - _godPos.x;
            float distinationY = thisPos.y - _godPos.y;
            rb.velocity = new Vector2(distinationX * nockback, distinationY * nockback);//殴った方向に飛んでいく
        }

        else
        {
            //攻撃を受けた時点での敵キャラとプレイヤーとの位置関係
            float distinationX = thisPos.x - _playerPos.x;
            float distinationY = thisPos.y - _playerPos.y;
            rb.velocity = new Vector2(distinationX * nockback, distinationY * nockback);//殴った方向に飛んでいく
        }
        MUTEKI = true;//無敵状態にする
        Debug.Log("ノックバック！");
    }
}