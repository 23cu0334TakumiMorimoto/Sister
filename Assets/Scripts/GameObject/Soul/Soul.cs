using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Soul : MonoBehaviour
{
    // プレイヤーを追尾する時の加速度、数値が大きいほどすぐ加速する
    private float m_followAccel = 0.01f;
    private bool m_isFollow; // プレイヤーを追尾するモードに入った場合 true
    private float m_followSpeed; // プレイヤーを追尾する速さ

    private float m_speed; // 散らばる時の速さ
    private float speedMin = 0.005f; //0.0125f; // 生成するアイテムの移動の速さ（最小値）
    private float speedMax = 0.1f; //0.075f; // 生成するアイテムの移動の速さ（最大値）
    private float m_brake = 0.9f; // 散らばる時の減速量、数値が小さいほどすぐ減速する
    private Vector3 m_direction;

    private GameObject _player;
    private Vector3 _playerPos;
    private float _distancePos;

    [SerializeField]
    [Header("吸収されるまでの時間")]
    private float _absorbTime;
    private float _timer;

    [SerializeField]
    private PlayerData _playerdata;

    private bool _absorb;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("God");
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _playerPos = _player.transform.localPosition;
        _distancePos = Vector3.Distance(_playerPos, transform.localPosition);

        if(_absorbTime < _timer)
        {
            // プレイヤーの現在位置へ向かうベクトルを作成する
            var direction = _playerPos - transform.localPosition;
            direction.Normalize();

            // アイテムをプレイヤーが存在する方向に移動する
            transform.localPosition += direction * m_followSpeed;

            // 加速しながら近づく
            m_followSpeed += m_followAccel;

            // フラグ更新
            _absorb = true;
        }
       

        // 散らばる速度を計算する
        var velocity = m_direction * m_speed;

        // 散らばる
        transform.localPosition += velocity;

        // だんだん減速する
        m_speed *= m_brake;
    }

    private void Init()
    {
        // アイテムがどの方向に散らばるかランダムに決定する
        var angle = Random.Range(0, 360);

        // 進行方向をラジアン値に変換する
        var f = angle * Mathf.Deg2Rad;

        // 進行方向のベクトルを作成する
        m_direction = new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0);

        // アイテムの散らばる速さをランダムに決定する
        m_speed = Mathf.Lerp(speedMin, speedMax, Random.value);

        // 8 秒後にアイテムを削除する
        Destroy(gameObject, 8);
    }

    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_absorb == true)
        {
            if (collision.gameObject.tag == "God")
            {
                // アイテムを削除する
                Destroy(gameObject);
            }
        }
        


    }
}
