using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerData")]

public class PlayerData : ScriptableObject
{
    // プレイヤーの人格
    // 0:シスター 1:デビル
    public int PLAYER_PERSON;

    public float MAXHP; // 最大HP
    public float ATK; // 攻撃力(デビルのみのパラメータ)
    public float SISTER_DEF; // 防御力(シスター)
    public float DEVIL_DEF; // 防御力(デビル)
    public float SISTER_SPEED; // 移動速度(シスター)
    public float DEVIL_SPEED; // 移動速度(デビル)
    public float NockBack; // ノックバック値
    public float MUTEKI_SPAN; // 無敵時間
    public float Attack_SPAN; // 攻撃までの時間
    public float Attack_STIFFNESS; // 攻撃の硬直
    public float CHANGE_TRANSITION_TIME; // 変身までの時間
    public float CHANGE_COOL_TIME; // 再変身までのクールタイム
    public int EXP; //経験値


    // 祈っているかどうか
    public bool IsPrayed;
    // 祈りの消去時間
    public float DESTROY_PRAY;
    // 祈りの増加する強さ
    public float EXPAND_PRAY;
    // 祈りの範囲制限
    public float LIMIT_PRAY;
}
