using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayGenerator : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField] PlayerData statusdata;
    // 攻撃判定の弾のプレハブ
    [SerializeField] private GameObject _prayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        statusdata.IsPrayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (statusdata.PLAYER_PERSON != 1)
        {
            if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("祈り生成");
                Instantiate(_prayPrefab, transform.position, Quaternion.identity);
                Debug.Log("Pray");
            }
        }
    }
}
