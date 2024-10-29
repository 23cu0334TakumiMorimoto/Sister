using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    //ヘルスバーを参照する
    public Health_Bar health_Bar;

    private bool _damage;
    private bool _knockback;

    PrayGenerator _pray;
    TestMover _move;
    ATKGenerator _atk;

    private Rigidbody2D _rb;

    public AudioClip Sound;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _pray = gameObject.GetComponent<PrayGenerator>();
        _move = gameObject.GetComponent<TestMover>();
        _atk = gameObject.GetComponent<ATKGenerator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void IsDead()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Bullet" && _damage != true)
        {
            _damage = true;
            StartCoroutine(KnockBack(col.transform, col.gameObject.GetComponent<IsDamaged>().IsDead));
            StartCoroutine(Invincible(col.gameObject.GetComponent<IsDamaged>().IsDead));
        }
    }

    // 無敵
    IEnumerator Invincible(bool dead)
    {
        Debug.Log("無敵");

        if(dead != true)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.1f);
                //spriteRenderer
                GetComponent<SpriteRenderer>().enabled = false;
                //flashInterval
                yield return new WaitForSeconds(0.1f);
                //spriteRenderer
                GetComponent<SpriteRenderer>().enabled = true;
            }
            _knockback = false;
            // ダメージを有効化
            _damage = false;
        }
    }

    IEnumerator KnockBack(Transform target, bool dead)
    {
        Debug.Log("ノックバック");;

        if (dead != true && _knockback == false)
        {
            _knockback = true;
            _audioSource.PlayOneShot(Sound);

            // 操作無効化
            _pray.enabled = false;
            _atk.enabled = false;
            _move.enabled = false;

            //攻撃を受けた時点での敵キャラとプレイヤーとの位置関係
            float distinationX = gameObject.transform.position.x - target.position.x;
            float distinationY = gameObject.transform.position.y - target.position.y;

            _rb.velocity = new Vector2(distinationX * 5, distinationY * 5);

            // 待ってから操作有効化
            yield return new WaitForSeconds(0.2f);
            _move.enabled = true;
            yield return new WaitForSeconds(1.8f);
            _pray.enabled = true;
            _atk.enabled = true;
        }
    }
}
