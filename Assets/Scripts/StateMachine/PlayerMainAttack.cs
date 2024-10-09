using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainAttack : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    Vector3 worldAngle;//角度を代入する
    public SpriteRenderer spriteRenderer;
    private float currentTime;
    [SerializeField] GameObject punch;
    [SerializeField] Sprite imageIdle;
    [SerializeField] Sprite imagePunch;

    void Start()
    {
        spriteRenderer.sprite = imageIdle;//待機状態の画像
        punch.GetComponent<BoxCollider2D>().enabled = false;//Punchの当たり判定をなくす
    }

    void Update()
    {

        //if (currentTime > statusdata.SPAN)//2秒ごとに実行される
        //{
        //    spriteRenderer.sprite = imagePunch;//Playerの画像を攻撃用の画像に切り替える
        //    punch.GetComponent<BoxCollider2D>().enabled = true;//あたり判定をつける
        //    StartCoroutine("Punchswitch");//攻撃を持続させるためのコルーチンを起動する
        //    currentTime = 0f;
        //}

    }

    IEnumerator Punchswitch()
    {
        yield return new WaitForSeconds(5);//5秒後に下の2行を実行する
        spriteRenderer.sprite = imageIdle;//待機状態の画像に切り替える
        punch.GetComponent<BoxCollider2D>().enabled = false;//あたり判定をなくす
    }
}
