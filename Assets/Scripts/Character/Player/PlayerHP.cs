using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;

    [SerializeField]
    [Header("�ő�̗�")]
    //�ő�̗�
    public float maxHealth = 100;

    [SerializeField]
    [Header("���݂̗̑�")]
    //���݂̗̑�
    public float _currentHealth;

    // �󂯂�_���[�W
    private float _damage;

    //�w���X�o�[���Q�Ƃ���
    public Health_Bar health_Bar;

    // Start is called before the first frame update
    void Start()
    {
        //�ő�HP��ݒ�
        _currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        _currentHealth -= _damage;

        //���݂̗̑͂𔽉f������
        health_Bar.setHealth(_currentHealth);
    }

    private void IsDead()
    {
        if (_currentHealth < 0)
        {
            
        }
    }
}
