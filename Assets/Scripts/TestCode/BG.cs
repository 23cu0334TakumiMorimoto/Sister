using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------
// 作成者:森本匠
// 背景スクロールをするスクリプト
// transformで動かしています
// -----------------------------------------

public class Background : MonoBehaviour
{
    [SerializeField]
    [Header("スクロールスピード")]
    public float scrollSpeed;

    private Vector3 _cameraRectMin;

    void Start()
    {
        // カメラの範囲を取得
        _cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        // X軸方向にスクロール
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);  
        // カメラの左端から完全に出たら、右端に瞬間移動
        if (transform.position.x < (_cameraRectMin.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = new Vector2((Camera.main.transform.position.x - _cameraRectMin.x) * 2 + 5, transform.position.y);
        }
    }
}