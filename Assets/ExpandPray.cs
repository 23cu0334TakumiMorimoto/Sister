using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPray : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;
    public float ExpandPower;
    public float ExpandSpeed;
    public float AreaSize;
    public float ExpandLimit;
    public float _destroyTime;
    private float _expandTimer;              //時間計測するための変数

    // プレイヤーの位置を取得
    private GameObject _player;
    private Transform _pray;

    GameObject gameManagerObj;
    Inoperable IPrayed;

    // Start is called before the first frame update
    void Start()
    {
        _expandTimer = 0;
        _player = GameObject.FindGameObjectWithTag("Player");
        gameManagerObj = GameObject.Find("GameManager");
        IPrayed = gameManagerObj.GetComponent<Inoperable>(); // スクリプトを取得
        _pray = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z))
        {
            // 指定された時間プレイヤー操作を無効にする
            IPrayed.CallInoperable(_expandTimer, 2);

            if (ExpandLimit >= AreaSize)
            {
                // 時間計測
                _expandTimer += Time.deltaTime;
                if (_expandTimer > ExpandSpeed)
                {
                    AreaSize += ExpandPower;
                }
            }
        }
            transform.localScale = new Vector3(AreaSize, AreaSize, AreaSize);
    }

    private void FixedUpdate()
    {
        _pray.position = _player.transform.position;
    }
}
