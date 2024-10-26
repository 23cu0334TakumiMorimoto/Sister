using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyMovement[] _enemyMove;       //メニューなどのボタンを格納するための配列変数

    private enum _movement
    {
        Bat,
        Goat,
        Cow
    }
    [SerializeField] _movement EnemyMove;　　　　//プルダウン化

    private GameObject _god;
    private Vector3 _godPos;

    // ステータスデータを読み込む
    [SerializeField]
    public StatusData statusdata;

    private Vector3 _diff;
    private Vector3 _vector;

    IsDamaged Dead;

    Rigidbody2D rb;
    Animator _animator;

    // タイマー
    float t;

    private void Start()
    {
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_godPos);
        rb = GetComponent<Rigidbody2D>();
        Dead = gameObject.GetComponent<IsDamaged>();
    }

    private void Update()
    {
        // コウモリ
        if(EnemyMove == _movement.Bat)
        {
            DevilBat();
        }
        // ヤギ
        else if (EnemyMove == _movement.Goat)
        {
            DevilGoat();
        }
        // 牛
        else if (EnemyMove == _movement.Cow)
        {
            DevilCow();
        }
    }

    private void DevilBat()
    {
        // 仮死状態ではないなら処理
        if (Dead.IsDead == false)
        {
            //神の現在位置を取得
            _godPos = _god.transform.position;
            //現在位置から神の位置に向けて移動
            transform.position = Vector2.MoveTowards(transform.position, _godPos, statusdata.SPEED * Time.deltaTime);
            //神と敵キャラのX軸の位置関係を取得する
            _diff.x = _godPos.x - this.transform.position.x;

            if (_diff.x > 0)
            {
                // Godが敵キャラの右側にいる時右側を向く
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // Godが敵キャラの左側にいる時左側を向く
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }
        }
    }

    private void DevilGoat()
    {
        // 仮死状態ではないなら処理
        if (Dead.IsDead == false)
        {
            //神の現在位置を取得
            _godPos = _god.transform.position;
            t += Time.deltaTime;
            float x = statusdata.CircleX * Mathf.Cos(t * statusdata.SPEED);
            float y = statusdata.CircleY * Mathf.Sin(t * statusdata.SPEED);
            transform.position
                = new Vector3(_godPos.x + x, _godPos.y + y, 0.0f);
            transform.rotation = Quaternion.identity;

            if (_diff.x > 0)
            {
                // Godが敵キャラの右側にいる時右側を向く
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // Godが敵キャラの左側にいる時左側を向く
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }
        }
    }

    private void DevilCow()
    {
        // 仮死状態ではないなら処理
        if (Dead.IsDead == false)
        {
            //神の現在位置を取得
            _godPos = _god.transform.position;
            //現在位置から神の位置に向けて移動
            transform.position = Vector2.MoveTowards(transform.position, _godPos, statusdata.SPEED * Time.deltaTime);
            //神と敵キャラのX軸の位置関係を取得する
            _diff.x = _godPos.x - this.transform.position.x;

            if (_diff.x > 0)
            {
                // Godが敵キャラの右側にいる時右側を向く
                _vector = new Vector3(0, -180, 0);
                this.transform.eulerAngles = _vector;
            }
            if (_diff.x < 0)
            {
                // Godが敵キャラの左側にいる時左側を向く
                _vector = new Vector3(0, 0, 0);
                this.transform.eulerAngles = _vector;
            }
        }
    }
}