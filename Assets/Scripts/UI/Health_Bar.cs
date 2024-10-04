using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    //インスペクタのスライダーの情報を受け取る
    public Slider Health_slider;
    //最大体力
    public void setmaxHealth(int Health)
    {
        Health_slider.maxValue = Health;
        Health_slider.value = Health;
    }

    //HPの状態
    public void setHealth(int HP)
    {
        Health_slider.value = HP;
    }
  
}
