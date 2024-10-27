using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]

public class StatusData : ScriptableObject
{
    //// ó‘Ô
    //// 0:’Êí 1:‰¼€
    //public int ENEMY_STATE;

    public float MAXHP; //Å‘åHP
    public float ATK; //UŒ‚—Í@
    public float DEF; //–hŒä—Í
    public float SPEED; //ˆÚ“®‘¬“x
    public float Weight; //d‚³
    public float MUTEKI_SPAN; //–³“GŠÔ
    public float Attack_STIFFNESS; // UŒ‚‚Ìd’¼
    public float DEAD_TIME; // ‰¼€ó‘Ô‚ÌŠÔ
    public int EXP; //ŒoŒ±’l

    public float CircleX; // ‰~‰^“®‚Ì‘å‚«‚³X
    public float CircleY; // ‰~‰^“®‚Ì‘å‚«‚³Y

    public float ATK_Interval; // UŒ‚ƒCƒ“ƒ^[ƒoƒ‹
}
