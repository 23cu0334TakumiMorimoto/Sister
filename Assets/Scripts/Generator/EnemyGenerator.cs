using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    [Header("自動出現用の敵プレハブ")]
    private GameObject EnemyPrefab;//生成する用の敵キャラPrefabを読み込む
    private Vector2 _myPos;
    private Vector2 _enemySpawnPos;   //生成される位置
    private float _currentTime = 0f;
    [SerializeField]
    [Header("スポーンまでの時間(自動出現）")]
    private float SpawnTime;

    [Header("自動出現するかどうか")]
    public bool IsSpawn;
    [SerializeField]
    [Header("敵をスポーンする座標のランダムの範囲")]
    public float RandomSpawnMinX;
    public float RandomSpawnMaxX;
    public float RandomSpawnMinY;
    public float RandomSpawnMaxY;
    // ランダムの範囲を代入する変数
    private float RandomSpawnRangeX;
    private float RandomSpawnRangeY;


    //ランダムで生成される方向を決める変数
    public enum SpawnDirection
    {
        DirectionX,//（X軸）
        DirectionY,//（Y軸）
    }
    [SerializeField]
    [Header("設定されている生成方向")]
    private SpawnDirection _nowSpaenDirection;

    void Start()
    {
        // ジェネレーターの現在の座標を取得する
        _myPos = this.transform.position;
    }
    void Update()
    {
        // 自動出現させるなら
        if (IsSpawn == true)
        {
            _currentTime += Time.deltaTime;//時間経過をcurrentTimeに代入し時間を測る
            if (_currentTime > SpawnTime)//spanで設定した時間を越えたら処理を実行
            {
                // ジェネレートする
                EnemyGenerate(EnemyPrefab);
                _currentTime = 0f;
            }
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        // ランダムで数字を代入
        RandomSpawnRangeX = Random.Range(RandomSpawnMinX, RandomSpawnMaxX);
        RandomSpawnRangeY = Random.Range(RandomSpawnMinY, RandomSpawnMaxY);

        switch (_nowSpaenDirection)
        {
            case SpawnDirection.DirectionX: // X軸で生成する場合
                _enemySpawnPos.x = RandomSpawnRangeX;
                break;

            case SpawnDirection.DirectionY: // Y軸で生成する場合
                _enemySpawnPos.y = RandomSpawnRangeY;
                break;
        }

        _enemySpawnPos = _enemySpawnPos + _myPos;//プレイヤーの位置に先ほどの乱数を足した位置に生成する
        var enemy = Instantiate(Enemy, _enemySpawnPos, transform.rotation);//Prefabを生成する
        // 変数の初期化                                                                   
        _enemySpawnPos = Vector2.zero;
        //Debug.Log(_enemySpawnPos);
    }

}