using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestATK : MonoBehaviour
{
    [SerializeField] StatusData statusdata;

    public AudioClip Sound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
