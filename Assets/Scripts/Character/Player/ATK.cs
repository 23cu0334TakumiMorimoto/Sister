using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    [SerializeField] private float bulletSpeed;@// ’e‚Ì‘¬“x
    [SerializeField] private float destroyTime;@// ’e‚Ì¶‘¶ŠúŠÔ

    public AudioClip Sound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // ˆê’èŠÔŒã‚É’e‚ğ”j‰ó‚·‚é
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // ‰¹‚ğ–Â‚ç‚µ‚Äƒ_ƒ[ƒW‚ğ—^‚¦‚é
            //_audioSource.PlayOneShot(Sound);
            col.gameObject.GetComponent<IsDamaged>().Damage(statusdata.ATK);
        }
    }
}
