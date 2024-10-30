using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInit : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    private PlayerData _playerdata;

    public bool IsTutorial;

    // Start is called before the first frame update
    void Start()
    {
        if(IsTutorial != true)
        {
            _playerdata.PLAYER_PERSON = 1;
            _playerdata.MAXHP = 100;
            _playerdata.ATK = 1;
            _playerdata.SISTER_SPEED = 2;
            _playerdata.DEVIL_SPEED = 1f;
            _playerdata.KnockBack = 3;
            _playerdata.Attack_SPAN = 0.3f;
            _playerdata.Attack_STIFFNESS = 0.5f;
            _playerdata.CHANGE_TRANSITION_TIME = 0.5f;
            _playerdata.CHANGE_COOL_TIME = 1;
            _playerdata.EXP = 0;
            _playerdata.DESTROY_PRAY = 0.1f;
            _playerdata.EXPAND_PRAY = 0.01f;
            _playerdata.LIMIT_PRAY = 3;
        }
        else
        {
            _playerdata.PLAYER_PERSON = 0;
            _playerdata.MAXHP = 100;
            _playerdata.ATK = 1;
            _playerdata.SISTER_SPEED = 3;
            _playerdata.DEVIL_SPEED = 1.5f;
            _playerdata.KnockBack = 3;
            _playerdata.Attack_SPAN = 0.3f;
            _playerdata.Attack_STIFFNESS = 0.5f;
            _playerdata.CHANGE_TRANSITION_TIME = 0.5f;
            _playerdata.CHANGE_COOL_TIME = 1;
            _playerdata.EXP = 0;
            _playerdata.DESTROY_PRAY = 0.3f;
            _playerdata.EXPAND_PRAY = 0.05f;
            _playerdata.LIMIT_PRAY = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
