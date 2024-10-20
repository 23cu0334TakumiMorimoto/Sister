using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratePattern : MonoBehaviour
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

    // 敵の出現を管理するフラグ
    private List<bool> _wave1Flag = new List<bool>();
    // 敵の出現を管理する時間
    [SerializeField]
    private List<float> _wave1Time = new List<float>();
    // 出現タイミングをカウントする変数
    private int _wave1Count;

    private float currentTime = 0f;

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
        for(int i = 0; i < _wave1Count; ++i)
        {
            _wave1Flag.Add(false);
        }
       
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
        if(_wave1Flag[0] == false && _wave1Time[0] < currentTime)
        {
            _up.EnemyGenerate(_Enemy1);
            _wave1Flag[0] = true;
        }
        // 2
        if (_wave1Flag[1] == false && _wave1Time[1] < currentTime)
        {
            _down.EnemyGenerate(_Enemy1);
            _wave1Flag[1] = true;
        }
        // 3
        if (_wave1Flag[2] == false && _wave1Time[2] < currentTime)
        {
            _left.EnemyGenerate(_Enemy1);
            _wave1Flag[2] = true;
        }
        // 4
        if (_wave1Flag[3] == false && _wave1Time[3] < currentTime)
        {
            _right.EnemyGenerate(_Enemy1);
            _wave1Flag[3] = true;
        }
    }
}
