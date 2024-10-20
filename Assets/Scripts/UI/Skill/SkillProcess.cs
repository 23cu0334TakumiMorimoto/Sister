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

    public void SpeedUp_Sister()
    {
        _playerdata.SISTER_SPEED++;
    }
    public void SpeedUp_Devil()
    {
        _playerdata.DEVIL_SPEED++;
    }
    public void PowerUp_Devil()
    {
        _playerdata.ATK++;
    }
   
}
