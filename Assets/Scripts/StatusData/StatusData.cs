using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]

public class StatusData : ScriptableObject
{
    //// 状態
    //// 0:通常 1:仮死
    //public int ENEMY_STATE;

    public float MAXHP; //最大HP
    public float ATK; //攻撃力　
    public float DEF; //防御力
    public float SPEED; //移動速度
    public float Weight; //重さ
    public float MUTEKI_SPAN; //無敵時間
    public float Attack_STIFFNESS; // 攻撃の硬直
    public float DEAD_TIME; // 仮死状態の時間
    public int EXP; //経験値

    public float CircleX; // 円運動の大きさX
    public float CircleY; // 円運動の大きさY

    public float ATK_Interval; // 攻撃インターバル
}
