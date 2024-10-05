using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGeneratorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyPrefab;//生成する用の敵キャラPrefabを読み込む
    private GameObject Player;
    private Vector2 PlayerPos;//キャラクターの位置を代入する変数
    private Vector2 _enemySpawnPos;   //生成される位置
    private float _currentTime = 0f;
    [SerializeField]
    [Header("スポーンまでの時間")]
    public float SpawnTime;
    //[SerializeField]
    //[Header("敵をスポーンする座標のランダムの範囲")]
    //public float RandomSpawnRangeX = Random.Range(1.0f, 3.0f);
    //public float RandomSpawnRangeY = Random.Range(1.0f, 3.0f);

    // 設定されている生成方向
    private SpawnDirection _nowSpaenDirection;
    //ランダムで生成される方向を決める変数
    public enum SpawnDirection
    {
        DirectionX,//（X軸）
        DirectionY,//（Y軸）
    }
   
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//Playerというタグを検索し、見つかったオブジェクトを代入する
    }
    void Update()
    {
        _currentTime += Time.deltaTime;//時間経過をcurrentTimeに代入し時間を測る
        if (_currentTime > SpawnTime)//spanで設定した3秒を越えたら処理を実行
        {
            EnemyGenerate(EnemyPrefab);
            _currentTime = 0f;
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        //EnemyPrefabのスポーン位置を決める
        //PlayerPos = Player.transform.position;//Playerの現在位置を取得

        //上下どちらにスポーンするか
        //rndUD = Random.Range(0, 2);//0:上 1:下
        //                           //左右どちらになるか
        //rndLR = Random.Range(0, 2);//0:左 1:右

        //    switch(_nowSpaenDirection)
        //    {
        //        case SpawnDirection.DirectionX: // X軸で生成する場合
        //            _enemySpawnPos.
        //    }


        //    switch (rndUD)
        //    {
        //        case 0://rndUDが上の場合
        //            enemyspwnPos.y = rndPositiveY;//上方向の乱数を代入

        //            break;
        //        case 1://rndUDが下の場合
        //            enemyspwnPos.y = rndNegativeY;//下方向の乱数を代入
        //            break;
        //    }

        //    switch (rndLR)
        //    {
        //        case 0://rndLRが左の場合
        //            enemyspwnPos.x = rndPositiveX;//左方向の乱数を代入
        //            break;
        //        case 1://rndLRが右の場合
        //            enemyspwnPos.x = rndNegativeX;//右方向の乱数を代入
        //            break;
        //    }

        //    enemyspwnPos = enemyspwnPos + PlayerPos;//プレイヤーの位置に先ほどの乱数を足した位置に生成する
        //    var enemy = Instantiate(Enemy, enemyspwnPos, transform.rotation);//Prefabを生成する
    }

}