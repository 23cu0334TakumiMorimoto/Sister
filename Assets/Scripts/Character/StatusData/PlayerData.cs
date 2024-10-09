using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerData")]

public class PlayerData : ScriptableObject
{
    // プレイヤーの人格
    // 0:シスター 1:デビル
    public int PLAYER_PERSON;

    public float MAXHP; //最大HP
    public float ATK; //攻撃力　
    public float DEF; //防御力
    public float SPEED; //移動速度
    public float NockBack; //ノックバック値
    public float MUTEKI_SPAN; //無敵時間
    public float Attack_SPAN; // 攻撃までの時間
    public float Attack_STIFFNESS; // 攻撃の硬直
    public int EXP; //経験値
}
