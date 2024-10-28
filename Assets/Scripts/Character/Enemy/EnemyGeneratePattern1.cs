using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratePattern1 : MonoBehaviour
{
    // ジェネレーターを取得
    [SerializeField] private GameObject _upGene;
    [SerializeField] private GameObject _downGene;
    [SerializeField] private GameObject _leftGene;
    [SerializeField] private GameObject _rightGene;
    private EnemyGenerator _up;
    private EnemyGenerator _down;
    private EnemyGenerator _left;
    private EnemyGenerator _right;

    // 敵プレハブ
    [Header("敵プレハブ")]
    [SerializeField] private GameObject _Enemy1;
    [Header("敵プレハブ")]
    [SerializeField] private GameObject _Enemy2;
    [Header("敵ボスプレハブ")]
    [SerializeField] private GameObject _BossEnemy;
    [Header("敵プレハブ")]
    [SerializeField] private GameObject _EnemyGoat;
    [Header("敵ボスプレハブ")]
    [SerializeField] private GameObject _EnemyCow;

    // 敵の出現を管理するフラグ
    private List<bool> _wave1Flag = new List<bool>();
    // 敵の出現を管理する時間
    [SerializeField]
    private List<float> _wave1Time = new List<float>();
    // 出現タイミングをカウントする変数
    private int _wave1Count;

    private float currentTime = 0f;

    public int NowWave;

    // Start is called before the first frame update
    void Start()
    {
        // スクリプトを取得
        _up = _upGene.GetComponent<EnemyGenerator>();
        _down = _downGene.GetComponent<EnemyGenerator>();
        _left = _leftGene.GetComponent<EnemyGenerator>();
        _right = _rightGene.GetComponent<EnemyGenerator>();

        // リストの要素数を取得
        _wave1Count = _wave1Time.Count;
        for (int i = 0; i < _wave1Count; ++i)
        {
            _wave1Flag.Add(false);
        }

        NowWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
            Wave1();
    }

    void Wave1()
    {
        // 1
        if (_wave1Flag[0] == false && _wave1Time[0] < currentTime)
        {
            _up.EnemyGenerate(_Enemy1);
            _wave1Flag[0] = true;
        }
        // 2
        if (_wave1Flag[1] == false && _wave1Time[1] < currentTime)
        {
            _down.EnemyGenerate(_Enemy1);
            _wave1Flag[1] = true;
            NowWave = 2;
        }
        // 3
        if (_wave1Flag[2] == false && _wave1Time[2] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[2] = true;
            NowWave = 3;
        }
        // 4
        if (_wave1Flag[3] == false && _wave1Time[3] < currentTime)
        {
            _right.EnemyGenerate(_Enemy1);
            _wave1Flag[3] = true;
            NowWave = 4;
        }
        // 5
        if (_wave1Flag[4] == false && _wave1Time[4] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[4] = true;
            NowWave = 5;
        }
        // 6
        if (_wave1Flag[5] == false && _wave1Time[5] < currentTime)
        {
            _right.EnemyGenerate(_Enemy1);
            _down.EnemyGenerate(_Enemy1);
            _wave1Flag[5] = true;
            NowWave = 6;
        }
        // 7
        if (_wave1Flag[6] == false && _wave1Time[6] < currentTime)
        {
            _up.EnemyGenerate(_Enemy1);
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[6] = true;
            NowWave = 7;
        }
        // 8
        if (_wave1Flag[7] == false && _wave1Time[7] < currentTime)
        {
            _up.EnemyGenerate(_Enemy1);
            _right.EnemyGenerate(_Enemy1);
            _down.EnemyGenerate(_Enemy1);
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[7] = true;
            NowWave = 8;
        }
        // 9
        if (_wave1Flag[8] == false && _wave1Time[8] < currentTime)
        {
            _up.EnemyGenerate(_Enemy2);
            _wave1Flag[8] = true;
            NowWave = 9;
        }
        // 10
        if (_wave1Flag[9] == false && _wave1Time[9] < currentTime)
        {
            _down.EnemyGenerate(_Enemy2);
            _wave1Flag[9] = true;
            NowWave = 10;
        }
        // 11
        if (_wave1Flag[10] == false && _wave1Time[10] < currentTime)
        {
            _left.EnemyGenerate(_Enemy2);
            _wave1Flag[10] = true;
            NowWave = 11;
        }
        // 12
        if (_wave1Flag[11] == false && _wave1Time[11] < currentTime)
        {
            _right.EnemyGenerate(_BossEnemy);
            _wave1Flag[11] = true;
            NowWave = 12;
        }
        //13
        if (_wave1Flag[12] == false && _wave1Time[12] < currentTime)
        {
            _down.EnemyGenerate(_Enemy1);
            _up.EnemyGenerate(_Enemy2);
            _wave1Flag[12] = true;
            NowWave = 13;
        }
        //14
        if (_wave1Flag[13] == false && _wave1Time[13] < currentTime)
        {
            _down.EnemyGenerate(_Enemy1);
            _up.EnemyGenerate(_Enemy2);
            _wave1Flag[13] = true;
            NowWave = 14;
        }
        //15
        if (_wave1Flag[14] == false && _wave1Time[14] < currentTime)
        {
            _left.EnemyGenerate(_Enemy2);
            _wave1Flag[14] = true;
            NowWave = 15;
        }
        //16
        if (_wave1Flag[15] == false && _wave1Time[15] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _right.EnemyGenerate(_Enemy2);
            _wave1Flag[15] = true;
            NowWave = 16;
        }
        //17
        if (_wave1Flag[16] == false && _wave1Time[16] < currentTime)
        {
            _right.EnemyGenerate(_Enemy1);
            _down.EnemyGenerate(_Enemy2);
            _down.EnemyGenerate(_EnemyGoat);
            _wave1Flag[16] = true;
            NowWave = 17;
        }
        //18
        if (_wave1Flag[17] == false && _wave1Time[17] < currentTime)
        {
            _down.EnemyGenerate(_Enemy1);
            _up.EnemyGenerate(_Enemy2);
            _wave1Flag[17] = true;
            NowWave = 18;
        }
        //19
        if (_wave1Flag[18] == false && _wave1Time[18] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _left.EnemyGenerate(_Enemy2);
            _wave1Flag[18] = true;
            NowWave = 19;
        }
        //20
        if (_wave1Flag[19] == false && _wave1Time[19] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _left.EnemyGenerate(_Enemy2);
            _down.EnemyGenerate(_EnemyGoat);
            _wave1Flag[19] = true;
            NowWave = 20;
        }
        //21
        if (_wave1Flag[20] == false && _wave1Time[20] < currentTime)
        {
            _up.EnemyGenerate(_Enemy2);
            _up.EnemyGenerate(_Enemy2);
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[20] = true;
            NowWave = 21;
        }
        //22
        if (_wave1Flag[21] == false && _wave1Time[21] < currentTime)
        {
            _up.EnemyGenerate(_Enemy2);
            _left.EnemyGenerate(_Enemy2);
            _left.EnemyGenerate(_Enemy1);
            _right.EnemyGenerate(_BossEnemy);
            _wave1Flag[21] = true;
            NowWave = 22;
        }
        //23
        if (_wave1Flag[22] == false && _wave1Time[22] < currentTime)
        {
            _down.EnemyGenerate(_EnemyGoat);
            _left.EnemyGenerate(_Enemy1);
            _down.EnemyGenerate(_Enemy1);
            _up.EnemyGenerate(_Enemy2);
            _wave1Flag[22] = true;
            NowWave = 23;
        }
        //24
        if (_wave1Flag[23] == false && _wave1Time[23] < currentTime)
        {
            _down.EnemyGenerate(_EnemyGoat);
            _left.EnemyGenerate(_BossEnemy);
            _wave1Flag[23] = true;
            NowWave = 24;
        }
        //25
        if (_wave1Flag[24] == false && _wave1Time[24] < currentTime)
        {
            _down.EnemyGenerate(_EnemyCow);
            _wave1Flag[24] = true;
            NowWave = 25;
        }
        // 自動出現させる
        if (_wave1Flag[24] == true)
        {
            _up.IsSpawn = true;
            _right.IsSpawn = true;
            _down.IsSpawn = true;
            _left.IsSpawn = true;
        }
    }
}
