using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAttack : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField]
    public StatusData statusdata;

    // 敵の種類
    private enum _movement
    {
        Bat,
        Goat
    }
    [SerializeField] _movement EnemyMove;    //プルダウン化

    // 死亡状況を取得
    public GameObject Enemy;
    private IsDamaged Dead;

    //// プレイヤーの位置を取得
    //private GameObject _player;
    //private Vector3 _playerPos;

    [SerializeField]
    [Header("ヤギの攻撃弾")]
    private GameObject _bulletGoat;
    private float _bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        Dead = Enemy.GetComponent<IsDamaged>();
        //_player = GameObject.FindGameObjectWithTag("Player");
        //_playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer += Time.deltaTime;
        // コウモリ
        if (EnemyMove == _movement.Goat)
        {
            DevilGoat();
        }
    }

    private void DevilGoat()
    {
        // 仮死状態ではないなら処理
        if (Dead.IsDead == false)
        {
            if(_bulletTimer > statusdata.ATK_Interval)
            {
                Instantiate(_bulletGoat, transform.position, Quaternion.identity);
                _bulletTimer = 0;
            }
        }
    }
}
