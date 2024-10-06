using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]

public class StatusData : ScriptableObject
{
    public float MAXHP; //最大HP
    public float ATK; //攻撃力　
    public float DEF; //防御力
    public float SPEED; //移動速度
    public float NockBack; //ノックバック値
    public float MUTEKI_SPAN; //無敵時間
    public float Attack_SPAN; // 攻撃までの時間
    public int EXP; //経験値
}
