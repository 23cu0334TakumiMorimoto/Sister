using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create Enemy_Bat_Boss")]

public class Enemy_Bat_Boss : ScriptableObject
{
    //// ���
    //// 0:�ʏ� 1:����
    //public int ENEMY_STATE;

    public float MAXHP; //�ő�HP
    public float ATK; //�U���́@
    public float DEF; //�h���
    public float SPEED; //�ړ����x
    public float NockBack; //�m�b�N�o�b�N�l
    public float MUTEKI_SPAN; //���G����
    public float Attack_SPAN; // �U���܂ł̎���
    public float Attack_STIFFNESS; // �U���̍d��
    public float DEAD_TIME; // ������Ԃ̎���
    public int EXP; //�o���l
}
