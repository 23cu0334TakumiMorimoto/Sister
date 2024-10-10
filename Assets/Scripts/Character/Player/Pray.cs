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

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z))
        {
            if (_audio == false)
            {
                _audioSource.PlayOneShot(Sound);
                _audio = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Z))
        {
            _pray = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (_pray == true)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<IsDamaged>().Dead();
            }
        }
    }
}
