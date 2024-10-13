using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField]
    private PlayerData _playerdata;

    // 現在の魂
    public int _currentSoul;

    // Start is called before the first frame update
    void Start()
    {
        _currentSoul = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            DevoteSoul();
        }
    }

    private void DevoteSoul()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            _currentSoul += _playerdata.EXP;
            _playerdata.EXP = 0;
        }
    }
}
