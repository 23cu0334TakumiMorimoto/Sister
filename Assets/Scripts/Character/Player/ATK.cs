using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    [SerializeField] private float bulletSpeed;�@// �e�̑��x
    [SerializeField] private float destroyTime;�@// �e�̐�������

    public AudioClip Sound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // ��莞�Ԍ�ɒe��j�󂷂�
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // ����炵�ă_���[�W��^����
            //_audioSource.PlayOneShot(Sound);
            col.gameObject.GetComponent<IsDamaged>().Damage(statusdata.ATK);
        }
    }
}
