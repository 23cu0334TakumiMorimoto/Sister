using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCalcDirection : MonoBehaviour
{
    private Vector2 lookDirection = new Vector2(0, -1.0f);      // �L�����̌����̏��̐ݒ�p

    /// <summary>
    /// �v���C���[�̐i�s�����̎擾�p
    /// </summary>
    /// <returns></returns>
    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }
}
