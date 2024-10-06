using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamaged : MonoBehaviour
{
    private GameObject _player;
    private Vector2 _playerPos;

    // ステータスデータを読み込む
    [SerializeField] StatusData statusdata;

    //攻撃を受けるかどうかの切り替えを行う
    bool MUTEKI;

    private float _currentHP;
    private float currentTime = 0f;
   
    private Rigidbody2D rb;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;
        this.transform.LookAt(_playerPos);
        _currentHP = statusdata.MAXHP;
        rb = GetComponent<Rigidbody2D>();//Rigidbody2Dの取得//☑
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
            }

        }
        if (_currentHP <= 0)//HPが0以下になったら消える
        {
            Destroy(this.gameObject);
        }
    }
    public void Damage(float damage)
    {
        if (!MUTEKI)
        {//無敵状態じゃないときに攻撃を受ける
            _currentHP -= damage;//HP減少
            Debug.Log(_currentHP);//現在のHPを表示
            MUTEKI = true;//無敵状態にする
        }
    }
    public void NockBack(float nockback)
    {
        Vector2 thisPos = transform.position;

        //Vector2 distination = new Vector2(thisPos.x - _playerPos.x, thisPos.y - _playerPos.y);//攻撃を受けて時点での敵キャラとプレイヤーとの位置関係   
        //Debug.Log(distination);
        //rb.AddForce(distination * nockback, ForceMode2D.Impulse);
        //// 初期化
        //distination = Vector2.zero;

        //攻撃を受けて時点での敵キャラとプレイヤーとの位置関係
        float distinationX = thisPos.x - _playerPos.x;
        float distinationY = thisPos.y - _playerPos.y;
        rb.velocity = new Vector2(distinationX * nockback, distinationY * nockback);//殴った方向に飛んでいく
        Debug.Log("ノックバック！");
    }
}