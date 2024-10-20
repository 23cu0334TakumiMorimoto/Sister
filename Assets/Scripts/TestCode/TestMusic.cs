using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMusic : MonoBehaviour
{
    public AudioClip Sound;
    private AudioSource _audioSource;
    private bool _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_audio == false)
        {
            _audioSource.PlayOneShot(Sound);
            _audio = true;
        }
    }
}
