using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCalcDirection : MonoBehaviour
{
    private Vector2 lookDirection = new Vector2(0, -1.0f);      // キャラの向きの情報の設定用

    /// <summary>
    /// プレイヤーの進行方向の取得用
    /// </summary>
    /// <returns></returns>
    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }
}
