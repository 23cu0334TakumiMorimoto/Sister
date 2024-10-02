using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    private Vector2 player_pos;

    [SerializeField]
    [Header("X���̈ړ������̍ŏ��l")] 
    private float _minMovementLimitX;
    [SerializeField]
    [Header("X���̈ړ������̍ő�l")]
    private float _maxMovementLimitX;

    [SerializeField]
    [Header("Y���̈ړ������̍ŏ��l")]
    private float _minMovementLimitY;
    [SerializeField]
    [Header("Y���̈ړ������̍ő�l")]
    private float _maxMovementLimitY;

  
    // Update is called once per frame
    private void FixedUpdate()
    {
        player_pos = transform.position; //�v���C���[�̈ʒu���擾

        player_pos.x = Mathf.Clamp(player_pos.x, _minMovementLimitX, _maxMovementLimitX); //x�ʒu����ɔ͈͓����Ď�
        player_pos.y = Mathf.Clamp(player_pos.y, _minMovementLimitY, _maxMovementLimitY); //x�ʒu����ɔ͈͓����Ď�
        transform.position = new Vector2(player_pos.x, player_pos.y); //�͈͓��ł���Ώ�ɂ��̈ʒu�����̂܂ܓ���
    }
}
