using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    [Header("弾の速度")]
    private float _speed;

    private Rigidbody2D _rb;

    // プレイヤーの位置を取得
    private GameObject _player;
    private Vector3 _playerPos;

    private float _timer;

    [SerializeField]
    [Header("破壊されるかどうか")]
    private bool IsDestroy;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = _playerPos - transform.position;
        _rb.velocity = vec;

        _timer += Time.deltaTime;

        if(_timer > 3 && IsDestroy != true)
        {
            Destroy(gameObject);
        }
    }
}
