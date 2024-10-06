using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject _god;
    private Vector3 _godPos;

    // ステータスデータを読み込む
    [SerializeField] StatusData statusdata;

    private Vector3 _diff;
    private Vector3 _vector;

    void Start()
    {
        _god = GameObject.FindGameObjectWithTag("God");
        _godPos = _god.transform.position;
        this.transform.LookAt(_godPos);
    }
    void Update()
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