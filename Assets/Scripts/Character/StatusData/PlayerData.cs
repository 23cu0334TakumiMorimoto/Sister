using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerData")]

public class PlayerData : ScriptableObject
{
    // �v���C���[�̐l�i
    // 0:�V�X�^�[ 1:�f�r��
    public int PLAYER_PERSON;

    public float MAXHP; //�ő�HP
    public float ATK; //�U���́@
    public float DEF; //�h���
    public float SPEED; //�ړ����x
    public float NockBack; //�m�b�N�o�b�N�l
    public float MUTEKI_SPAN; //���G����
    public float Attack_SPAN; // �U���܂ł̎���
    public float Attack_STIFFNESS; // �U���̍d��
    public int EXP; //�o���l
}
