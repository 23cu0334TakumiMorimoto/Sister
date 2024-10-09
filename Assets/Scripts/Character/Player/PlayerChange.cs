using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField] PlayerData statusdata;

    // �����ւ��摜
    public Sprite SisterSprite;
    public Sprite DevilSprite;
    public Sprite ChangeSprite;
    private SpriteRenderer image;

    void Start()
    {
        // SpriteRenderer���擾
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (statusdata.PLAYER_PERSON == 1)
        {
            ChangeSister();
        }
        else
        {
            ChangeDevil();
        }
    }

    private void ChangeSister()
    {
        if (statusdata.PLAYER_PERSON == 1)
        {
            
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("�`�F���W�V�X�^�[");
                image.sprite = SisterSprite;
                statusdata.PLAYER_PERSON = 0;
            }
        }
    }

    private void ChangeDevil()
    {
        if (statusdata.PLAYER_PERSON == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("�`�F���W�f�r��");
                image.sprite = DevilSprite;
                statusdata.PLAYER_PERSON = 1;
            }
        }
    }
}
