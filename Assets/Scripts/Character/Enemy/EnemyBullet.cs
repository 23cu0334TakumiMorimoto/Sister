using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    [Header("弾の速度")]
    private float _speed;

    private Rigidbody2D _rb;

    // プレイヤーの位置を取得
    private GameObject _player;
    private Vector3 _playerPos;

    // 発射角度
    private float angle;

    private float _timer;

    [SerializeField]
    [Header("破壊されるかどうか")]
    private bool IsDestroy;

    private float rotateX, rotateY, rotateZ;
    private float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;

        ////  発射角度を求める
        //float angle = GetAngle(gameObject.transform.position, _playerPos);

        _rb.AddForce(_playerPos.normalized - transform.position.normalized * _speed,ForceMode2D.Impulse);
        ////メーターのZ軸の数値をボールのX軸の角度へ。-1かけると丁度良い具合になる
        //transform.rotation = Quaternion.Euler(angle * -1, 0, 0);

        rotateX = 0;
        rotateY = 0;
        rotateZ = 30;
        _rotateSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > 5 && IsDestroy != true)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        ////メーターのZ軸の数値をボールのX軸の角度へ。-1かけると丁度良い具合になる
        //transform.rotation = Quaternion.Euler(angle * -1, 0, 0);

        // 回転し続ける。
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime * _rotateSpeed);
    }

    private void OnTriggrEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "God")
        {
            Destroy(gameObject);
        }
    }

    //    float GetAngle(Vector2 start, Vector2 target)
    //{
    //    Vector2 dt = target - start;
    //    float rad = Mathf.Atan2(dt.y, dt.x);
    //    float degree = rad * Mathf.Rad2Deg;

    //    return degree;
    //}
}
