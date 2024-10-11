using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayGenerator : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField] PlayerData statusdata;
    // �U������̒e�̃v���n�u
    [SerializeField] private GameObject _prayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        statusdata.IsPrayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (statusdata.PLAYER_PERSON != 1)
        {
            if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("�F�萶��");
                Instantiate(_prayPrefab, transform.position, Quaternion.identity);
                Debug.Log("Pray");
            }
        }
    }
}
