using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject God;
    Vector3 GodPos;

    private float speed = 0.5f;

    Vector3 diff;
    Vector3 vector;

    void Start()
    {
        God = GameObject.FindGameObjectWithTag("God");
        GodPos = God.transform.position;
        this.transform.LookAt(GodPos);

    }
    void Update()
    {
        //神の現在位置を取得
        GodPos = God.transform.position;
        //現在位置から神の位置に向けて移動
        transform.position = Vector2.MoveTowards(transform.position, GodPos, speed * Time.deltaTime);
        //神と敵キャラのX軸の位置関係を取得する
        diff.x = GodPos.x - this.transform.position.x;
        if (diff.x > 0)
        {
            // Godが敵キャラの右側にいる時右側を向く
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        if (diff.x < 0)
        {
            // Godが敵キャラの左側にいる時左側を向く
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }
    }

}