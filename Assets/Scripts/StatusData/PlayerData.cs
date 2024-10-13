using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerData")]

public class PlayerData : ScriptableObject
{
    // �v���C���[�̐l�i
    // 0:�V�X�^�[ 1:�f�r��
    public int PLAYER_PERSON;

    public float MAXHP; // �ő�HP
    public float ATK; // �U����(�f�r���݂̂̃p�����[�^)
    public float SISTER_DEF; // �h���(�V�X�^�[)
    public float DEVIL_DEF; // �h���(�f�r��)
    public float SISTER_SPEED; // �ړ����x(�V�X�^�[)
    public float DEVIL_SPEED; // �ړ����x(�f�r��)
    public float NockBack; // �m�b�N�o�b�N�l
    public float MUTEKI_SPAN; // ���G����
    public float Attack_SPAN; // �U���܂ł̎���
    public float Attack_STIFFNESS; // �U���̍d��
    public float CHANGE_TRANSITION_TIME; // �ϐg�܂ł̎���
    public float CHANGE_COOL_TIME; // �ĕϐg�܂ł̃N�[���^�C��
    public int EXP; //�o���l


    // �F���Ă��邩�ǂ���
    public bool IsPrayed;
    // �F��̏�������
    public float DESTROY_PRAY;
    // �F��̑������鋭��
    public float EXPAND_PRAY;
    // �F��͈̔͐���
    public float LIMIT_PRAY;
}
