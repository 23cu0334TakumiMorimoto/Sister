using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]

public class StatusData : ScriptableObject
{
    //// ���
    //// 0:�ʏ� 1:����
    //public int ENEMY_STATE;

    public float MAXHP; //�ő�HP
    public float ATK; //�U���́@
    public float DEF; //�h���
    public float SPEED; //�ړ����x
    public float Weight; //�d��
    public float MUTEKI_SPAN; //���G����
    public float Attack_STIFFNESS; // �U���̍d��
    public float DEAD_TIME; // ������Ԃ̎���
    public int EXP; //�o���l

    public float CircleX; // �~�^���̑傫��X
    public float CircleY; // �~�^���̑傫��Y

    public float ATK_Interval; // �U���C���^�[�o��
}
