using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    //�w���X�o�[���Q�Ƃ���
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

    // ���G
    IEnumerator Invincible(bool dead)
    {
        Debug.Log("���G");

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
            // �_���[�W��L����
            _damage = false;
        }
    }

    IEnumerator KnockBack(Transform target, bool dead)
    {
        Debug.Log("�m�b�N�o�b�N");;

        if (dead != true && _knockback == false)
        {
            _knockback = true;
            _audioSource.PlayOneShot(Sound);

            // ���얳����
            _pray.enabled = false;
            _atk.enabled = false;
            _move.enabled = false;

            //�U�����󂯂����_�ł̓G�L�����ƃv���C���[�Ƃ̈ʒu�֌W
            float distinationX = gameObject.transform.position.x - target.position.x;
            float distinationY = gameObject.transform.position.y - target.position.y;

            _rb.velocity = new Vector2(distinationX * 5, distinationY * 5);

            // �҂��Ă��瑀��L����
            yield return new WaitForSeconds(0.2f);
            _move.enabled = true;
            yield return new WaitForSeconds(1.8f);
            _pray.enabled = true;
            _atk.enabled = true;
        }
    }
}
