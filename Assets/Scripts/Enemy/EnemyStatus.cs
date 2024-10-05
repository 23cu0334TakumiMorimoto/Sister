using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    [Header("�L�����N�^�[�p�����[�^")]
    [Space(10)]
    [Header("�ړ����x")]
    public float _moveSpeed = 10;

    [SerializeField]
    [Header("�U����")]
    public float _atk;

    [SerializeField]
    [Header("�h���")]
    public float _def;

    [SerializeField]
    [Header("�̗�")]
    public float _hp;
}
