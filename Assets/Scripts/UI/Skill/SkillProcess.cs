using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProcess : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerdata;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseSkill(int SkillNum)
    {
        if(SkillNum == 1)
        {
            LowSpeedUp_Sister();
        }
        else if (SkillNum == 2)
        {
            SpeedUp_Sister();
        }
        else if (SkillNum == 3)
        {
            HighSpeedUp_Sister();
        }
        else if (SkillNum == 4)
        {
            LowSpeedUp_Devil();
        }
        else if (SkillNum == 5)
        {
            SpeedUp_Devil();
        }
        else if (SkillNum == 6)
        {
            HighSpeedUp_Devil();
        }
        else if (SkillNum == 7)
        {
            LowPowerUp_Devil();
        }
        else if (SkillNum == 8)
        {
            PowerUp_Devil();
        }
        else if (SkillNum == 9)
        {
            HighPowerUp_Devil();
        }
        else if (SkillNum == 10)
        {
            LowLimitOverPray_Sister();
        }
        else if (SkillNum == 11)
        {
            HighLimitOverPray_Sister();
        }
        else if (SkillNum == 12)
        {
            LowExpandOverPray_Sister();
        }
        else if (SkillNum == 13)
        {
            HighExpandOverPray_Sister();
        }
        else if (SkillNum == 14)
        {
            KnockBackOver_Devil();
        }
    }

    // 1
    private void LowSpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED += 0.2f;
        Debug.Log("�V�X�^�[���[�X�s�[�h");
    }
    // 2
    private void SpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED += 0.5f;
        Debug.Log("�V�X�^�[�X�s�[�h");
    }
    // 3
    private void HighSpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED ++;
        Debug.Log("�V�X�^�[�n�C�X�s�[�h");
    }
    // 4
    private void LowSpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED += 0.3f;
        Debug.Log("�f�r�����[�X�s�[�h");
    }
    // 5
    private void SpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED+= 0.5f;
        Debug.Log("�f�r���X�s�[�h");
    }
    // 6
    private void HighSpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED++;
        Debug.Log("�f�r���n�C�X�s�[�h");
    }
    // 7
    private void LowPowerUp_Devil()
    {
        _playerdata.ATK += 0.3f;
        Debug.Log("�f�r�����[�A�^�b�N");
    }
    // 8
    private void PowerUp_Devil()
    {
        _playerdata.ATK += 0.5f;
        Debug.Log("�f�r���A�^�b�N");
    }
    // 9
    private void HighPowerUp_Devil()
    {
        _playerdata.ATK ++;
        Debug.Log("�f�r���n�C�A�^�b�N");
    }
    // 10
    private void LowLimitOverPray_Sister()
    {
        _playerdata.LIMIT_PRAY += 0.2f;
        Debug.Log("�V�X�^�[�v���C���[���~�b�g");
    }
    // 11
    private void HighLimitOverPray_Sister()
    {
        _playerdata.LIMIT_PRAY += 0.5f;
        Debug.Log("�V�X�^�[�v���C�n�C���~�b�g");
    }
    // 12
    private void LowExpandOverPray_Sister()
    {
        _playerdata.EXPAND_PRAY += 0.02f;
        Debug.Log("�V�X�^�[�v���C���[�G�N�X�p���h");
    }
    // 13
    private void HighExpandOverPray_Sister()
    {
        _playerdata.EXPAND_PRAY += 0.05f;
        Debug.Log("�V�X�^�[�v���C�n�C�G�N�X�p���h");
    }
    // 14
    private void KnockBackOver_Devil()
    {
        _playerdata.KnockBack += 0.5f;
        Debug.Log("�f�r���m�b�N�o�b�N");
    }

}
