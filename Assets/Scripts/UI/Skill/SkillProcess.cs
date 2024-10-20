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
    // 1
    public void LowSpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED += 0.2f; ;
    }
    // 2
    public void SpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED += 0.5f; ;
    }
    // 3
    public void HighSpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED ++;
    }
    // 4
    public void LowSpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED += 0.3f;
    }
    // 5
    public void SpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED+= 0.5f;
    }
    // 6
    public void HighSpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED++;
    }
    // 7
    public void PowerUp_Devil()
    {
        _playerdata.ATK += 0.5f;
    }
    // 8
    public void HighPowerUp_Devil()
    {
        _playerdata.ATK++;
    }
    // 9
    public void LowLimitOverPray_Sister()
    {
        _playerdata.LIMIT_PRAY += 0.2f;
    }
    // 10
    public void HighLimitOverPray_Sister()
    {
        _playerdata.LIMIT_PRAY += 0.5f;
    }
    // 11
    public void LowExpandOverPray_Sister()
    {
        _playerdata.EXPAND_PRAY += 0.02f;
    }
    // 12
    public void HighExpandOverPray_Sister()
    {
        _playerdata.EXPAND_PRAY += 0.05f;
    }
    // 13
    public void KnockBackOver_Devil()
    {
        _playerdata.KnockBack += 0.5f;
    }

}
