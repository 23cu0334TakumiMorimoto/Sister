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

    GameObject gameManagerObj;
    Inoperable IChanged;
    private Rigidbody2D rb;
    // �^�C�}�[
    [SerializeField]
    [Header("�ϐg�̃N�[���^�C�}�[")]
    private float ChangeCoolTimer;       

    void Start()
    {
        // SpriteRenderer���擾
        image = GetComponent<SpriteRenderer>();
        // �X�N���v�g���擾
        gameManagerObj = GameObject.Find("GameManager");
        IChanged = gameManagerObj.GetComponent<Inoperable>();
        rb = GetComponent<Rigidbody2D>();//Rigidbody2D�̎擾
        ChangeCoolTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[���X�V
        ChangeCoolTimer += Time.deltaTime;

        // �ϐg�N�[���^�C���𖞂����Ă�����
        if (ChangeCoolTimer >= statusdata.CHANGE_COOL_TIME)
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
    }

    private void ChangeSister()
    {

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("�`�F���W�V�X�^�[");
            image.sprite = SisterSprite;
            // �w�肳�ꂽ���ԃv���C���[����𖳌��ɂ���
            IChanged.CallInoperable(statusdata.CHANGE_TRANSITION_TIME);
            // ���x���O�ɂ���
            rb.velocity = new Vector2(0, 0);
            // �l�i��؂�ւ��ăX�e�[�^�X��؂�ւ���
            statusdata.PLAYER_PERSON = 0;
            // �^�C�}�[��������
            ChangeCoolTimer = 0;

        }
    }

    private void ChangeDevil()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("�`�F���W�f�r��");
            image.sprite = DevilSprite;
            // �w�肳�ꂽ���ԃv���C���[����𖳌��ɂ���
            IChanged.CallInoperable(statusdata.CHANGE_TRANSITION_TIME);
            // ���x���O�ɂ���
            rb.velocity = new Vector2(0, 0);
            // �l�i��؂�ւ��ăX�e�[�^�X��؂�ւ���
            statusdata.PLAYER_PERSON = 1;
            // �^�C�}�[��������
            ChangeCoolTimer = 0;
        }
    }
}
