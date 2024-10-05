using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    [SerializeField]
    [Header("最大体力")]
    //最大体力
    public float maxHealth = 100;

    [SerializeField]
    [Header("現在の体力")]
    //現在の体力
    private float _currentHealth;

    // 受けるダメージ
    private float _damage;

    //ヘルスバーを参照する
    public Health_Bar health_Bar;

    // 差し替え画像
    public Sprite newSprite;
    private SpriteRenderer image;

    [SerializeField]
    [Header("衝突してきた敵を破壊するかどうか")]
    private bool IsDestroyed;

    // Start is called before the first frame update
    private void Start()
    {
        // SpriteRendererを取得
        image = GetComponent<SpriteRenderer>();
        //最大HPを設定
        _currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

        // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") 
        { 
            _damage = col.gameObject.GetComponent<EnemyStatus>()._atk;
            //ダメージを受ける
            UpdateHp();
            IsDead();

            if (IsDestroyed == true)
            {
                Destroy(col.gameObject);
            }
        }
        Debug.Log("衝突");
    }

    private void UpdateHp()
    {
        _currentHealth-= _damage;

        //現在の体力を反映させる
        health_Bar.setHealth(_currentHealth);
    }

    private void IsDead()
    {
        if(_currentHealth < 0)
        {
            image.sprite = newSprite;
        }
    }
}
