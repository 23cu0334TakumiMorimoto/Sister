using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    [SerializeField] private float bulletSpeed;　// 弾の速度
    [SerializeField] private float destroyTime;　// 弾の生存期間

    public AudioClip Sound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 一定時間後に弾を破壊する
        Destroy(gameObject, destroyTime);
    }

    //public void Shoot(Vector2 direction)
    //{

    //    // 弾に Rigidbody2D コンポーネントがアタッチされているか確認した上で
    //    if (TryGetComponent(out Rigidbody2D rb))
    //    {

    //        // Rigidbody2D の AddForce メソッドを利用して、プレイヤーの進行方向と同じ方向に弾を発射する
    //        rb.AddForce(direction * bulletSpeed);
    //    }

    //    // 一定時間後に弾を破壊する
    //    Destroy(gameObject, destroyTime);
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            _audioSource.PlayOneShot(Sound);
            col.gameObject.GetComponent<IsDamaged>().Damage(statusdata.ATK);
            col.gameObject.GetComponent<IsDamaged>().NockBack(statusdata.NockBack,false);
        }
    }
}
