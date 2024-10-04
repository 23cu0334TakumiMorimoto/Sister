using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testplayer : MonoBehaviour
{
    //最大体力
    public int maxHealth = 100;

    //現在の体力
    public int currentHealth;

    //ヘルスバーを参照する
    public Health_Bar health_Bar;
    // Start is called before the first frame update
    void Start()
    {
        //最大HPを設定
        currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されたら１ダメージうける
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //ダメージ
            damage(1);
        }
    }
    void damage(int damage)
    {
        currentHealth-= damage;

        //現在の体力を反映させる
        health_Bar.setHealth(currentHealth);
    }
}
