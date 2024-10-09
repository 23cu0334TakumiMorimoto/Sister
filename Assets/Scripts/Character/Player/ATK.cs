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

    //public void Shoot(Vector2 direction)
    //{

    //    // �e�� Rigidbody2D �R���|�[�l���g���A�^�b�`����Ă��邩�m�F�������
    //    if (TryGetComponent(out Rigidbody2D rb))
    //    {

    //        // Rigidbody2D �� AddForce ���\�b�h�𗘗p���āA�v���C���[�̐i�s�����Ɠ��������ɒe�𔭎˂���
    //        rb.AddForce(direction * bulletSpeed);
    //    }

    //    // ��莞�Ԍ�ɒe��j�󂷂�
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
