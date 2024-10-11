using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pray : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    public AudioClip Sound;
    private AudioSource _audioSource;

    private bool _pray;
    private bool _audio;
    private bool _colEnemy;

    public float _destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _colEnemy = false;
        _pray = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z))
        {
            if (_audio == false)
            {
                statusdata.IsPrayed = true;
                _audioSource.PlayOneShot(Sound);
                _audio = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Z))
        {
            if (statusdata.IsPrayed == true)
            {
                statusdata.IsPrayed = false;
            }

            // 祈りが敵に接触しているか
            if(_colEnemy == true)
            {
                _pray = true;
            }
            else
            {
                // 祈り攻撃を破棄
                OnDestroy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_pray == true)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Debug.Log("祈り開始");
                col.gameObject.GetComponent<IsDamaged>().Dead();
                // 祈り攻撃を破棄
                OnDestroy();
                _pray = false;
            }
        }
        if (col.gameObject.tag == "Enemy")
        {
            _colEnemy = true;
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject, _destroyTime);
    }
}
