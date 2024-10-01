using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------
// キャラクタークラス
// 敵とプレイヤーはこのクラスを継承して使う
// パラメータを初期化（必須）
// -----------------------------------------

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    [Header("キャラクターパラメータ")]
    [Space(10)]
    [Header("移動速度")]
    protected float _moveSpeed;

    [SerializeField]
    [Header("攻撃力")]
    protected float _atk;

    [SerializeField]
    [Header("防御力")]
    protected float _def;

    [SerializeField]
    [Header("体力")]
    protected float _hp;

    protected Rigidbody2D _rigidbody;

    // 画像を左右反転する
    protected virtual void FlipSpriteRenderer() { }

}
