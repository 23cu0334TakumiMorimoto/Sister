using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    [SerializeField]
    [Header("最大体力")]
    //最大体力
    public float maxHealth = 100;

    [SerializeField]
    [Header("現在の体力")]
    //現在の体力
    public float _currentHealth;

    // 受けるダメージ
    private float _damage;

    //ヘルスバーを参照する
    public Health_Bar health_Bar;

    // Start is called before the first frame update
    void Start()
    {
        //最大HPを設定
        _currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        _currentHealth -= _damage;

        //現在の体力を反映させる
        health_Bar.setHealth(_currentHealth);
    }

    private void IsDead()
    {
        if (_currentHealth < 0)
        {
            
        }
    }
}
