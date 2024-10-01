using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------
// �L�����N�^�[�N���X
// �G�ƃv���C���[�͂��̃N���X���p�����Ďg��
// �p�����[�^���������i�K�{�j
// -----------------------------------------

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    [Header("�L�����N�^�[�p�����[�^")]
    [Space(10)]
    [Header("�ړ����x")]
    protected float _moveSpeed;

    [SerializeField]
    [Header("�U����")]
    protected float _atk;

    [SerializeField]
    [Header("�h���")]
    protected float _def;

    [SerializeField]
    [Header("�̗�")]
    protected float _hp;

    protected Rigidbody2D _rigidbody;

    // �摜�����E���]����
    protected virtual void FlipSpriteRenderer() { }

}
