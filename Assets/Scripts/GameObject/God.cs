using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{

    [SerializeField] StatusData statusdata;

    [SerializeField]
    [Header("�ő�̗�")]
    //�ő�̗�
    public float maxHealth = 100;

    [SerializeField]
    [Header("���݂̗̑�")]
    //���݂̗̑�
    private float _currentHealth;

    [SerializeField]
    [Header("�m�b�N�o�b�N�l")]
    //���݂̗̑�
    private float _knockBack;

    // �󂯂�_���[�W
    private float _damage;

    //�w���X�o�[���Q�Ƃ���
    public Health_Bar health_Bar;

    // �����ւ��摜
    public Sprite newSprite;
    private SpriteRenderer image;

    [SerializeField]
    [Header("�Փ˂��Ă����G��j�󂷂邩�ǂ���")]
    private bool IsDestroyed;

    // Start is called before the first frame update
    private void Start()
    {
        // SpriteRenderer���擾
        image = GetComponent<SpriteRenderer>();
        //�ő�HP��ݒ�
        _currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

        // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") 
        {
            col.gameObject.GetComponent<IsDamaged>().NockBack(_knockBack, true);
            _damage = col.gameObject.GetComponent<EnemyMovement>().statusdata.ATK;
            //�_���[�W���󂯂�
            UpdateHp();
            IsDead();

            if (IsDestroyed == true)
            {
                Destroy(col.gameObject);
            }
        }
        Debug.Log("�Փ�");
    }

    private void UpdateHp()
    {
        _currentHealth-= _damage;

        //���݂̗̑͂𔽉f������
        health_Bar.setHealth(_currentHealth);
    }

    private void IsDead()
    {
        if(_currentHealth < 0)
        {
            image.sprite = newSprite;
        }
    }
}
