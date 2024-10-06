using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    [Header("キャラクターパラメータ")]
    [Space(10)]
    [Header("移動速度")]
    public float _moveSpeed = 10;

    [SerializeField]
    [Header("攻撃力")]
    public float _atk;

    [SerializeField]
    [Header("防御力")]
    public float _def;

    [SerializeField]
    [Header("体力")]
    public float _hp;
}
