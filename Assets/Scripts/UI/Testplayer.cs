using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testplayer : MonoBehaviour
{
    //�ő�̗�
    public int maxHealth = 100;

    //���݂̗̑�
    public int currentHealth;

    //�w���X�o�[���Q�Ƃ���
    public Health_Bar health_Bar;
    // Start is called before the first frame update
    void Start()
    {
        //�ő�HP��ݒ�
        currentHealth = maxHealth;
        health_Bar.setmaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�L�[�������ꂽ��P�_���[�W������
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //�_���[�W
            damage(1);
        }
    }
    void damage(int damage)
    {
        currentHealth-= damage;

        //���݂̗̑͂𔽉f������
        health_Bar.setHealth(currentHealth);
    }
}
