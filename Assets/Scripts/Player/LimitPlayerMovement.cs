using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    private Vector2 player_pos;

    [SerializeField]
    [Header("X軸の移動制限の最小値")] 
    private float _minMovementLimitX;
    [SerializeField]
    [Header("X軸の移動制限の最大値")]
    private float _maxMovementLimitX;

    [SerializeField]
    [Header("Y軸の移動制限の最小値")]
    private float _minMovementLimitY;
    [SerializeField]
    [Header("Y軸の移動制限の最大値")]
    private float _maxMovementLimitY;

  
    // Update is called once per frame
    private void FixedUpdate()
    {
        player_pos = transform.position; //プレイヤーの位置を取得

        player_pos.x = Mathf.Clamp(player_pos.x, _minMovementLimitX, _maxMovementLimitX); //x位置が常に範囲内か監視
        player_pos.y = Mathf.Clamp(player_pos.y, _minMovementLimitY, _maxMovementLimitY); //x位置が常に範囲内か監視
        transform.position = new Vector2(player_pos.x, player_pos.y); //範囲内であれば常にその位置がそのまま入る
    }
}
