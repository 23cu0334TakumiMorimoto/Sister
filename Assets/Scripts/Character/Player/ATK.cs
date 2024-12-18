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
        statusdata.KnockBack = 3;
    }

    private void Update()
    {
        // 一定時間後に弾を破壊する
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // 音を鳴らしてダメージを与える
            //_audioSource.PlayOneShot(Sound);
            col.gameObject.GetComponent<IsDamaged>().Damage(statusdata.ATK);
            col.gameObject.GetComponent<IsDamaged>().KnockBack(statusdata.KnockBack, false);

            Debug.Log("ATK!!!");
        }
    }
}
