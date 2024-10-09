using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]

public class StatusData : ScriptableObject
{
    public float MAXHP; //Å‘åHP
    public float ATK; //UŒ‚—Í@
    public float DEF; //–hŒä—Í
    public float SPEED; //ˆÚ“®‘¬“x
    public float NockBack; //ƒmƒbƒNƒoƒbƒN’l
    public float MUTEKI_SPAN; //–³“GŠÔ
    public float Attack_SPAN; // UŒ‚‚Ü‚Å‚ÌŠÔ
    public float Attack_STIFFNESS; // UŒ‚‚Ìd’¼
    public int EXP; //ŒoŒ±’l
}
