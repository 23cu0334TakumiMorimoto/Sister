using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    //�C���X�y�N�^�̃X���C�_�[�̏����󂯎��
    public Slider Health_slider;
    //�ő�̗�
    public void setmaxHealth(int Health)
    {
        Health_slider.maxValue = Health;
        Health_slider.value = Health;
    }

    //HP�̏��
    public void setHealth(int HP)
    {
        Health_slider.value = HP;
    }
  
}
