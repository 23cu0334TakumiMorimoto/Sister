using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// スキル抽選するスクリプト

public class DrawingSkill : LV_UIData
{
    private int _skillCount;
    private int _normalCount;
    private int _rareCount;
    private int _superRareCount;
    private SkillData _skill;

    private int _randomNum;
    [SerializeField]
    [Header("ノーマルの出やすさ")]
    private int _normalProbability;
    [SerializeField]
    [Header("レアの出やすさ")]
    private int _rareProbability;
    [SerializeField]
    [Header("スーパーレアの出やすさ")]
    private int _superRareProbability;

    private List<int> _normalNum = new List<int>();
    private List<int> _rareNum = new List<int>();
    private List<int> _superRareNum = new List<int>();

    private SkillSelectUI _skill1Select;
    private SkillSelectUI _skill2Select;
    private SkillSelectUI _skill3Select;
    private SkillSelectUI _skill4Select;

    [Space(10)]
    [SerializeField]
    private GameObject _skill1;
    [SerializeField]
    private GameObject _skill2;
    [SerializeField]
    private GameObject _skill3;
    [SerializeField]
    private GameObject _skill4;

    // 抽選した回数
    private int _countDrawing;

    //// 一度にウィンドウが呼ばれた数
    //public int _callCount;
    //public bool _oneMoreSkill;

    // Start is called before the first frame update
    void Start()
    {
        // リストの要素数を取得
        _skillCount = skillData.Count;
        //Debug.Log(_skillCount);

        // 各レアリティの総数をカウント
        for (int i = 0; i < _skillCount; ++i)
        {
            // 各レアリティの総数と番号をカウント
            if (skillData[i].SkillGrade == 0)
            {
                //Debug.Log(skillData[i].SkillGrade);
                _normalCount++;
                _normalNum.Add(skillData[i].SkillNumber);
            }
            else if (skillData[i].SkillGrade == 1)
            {
                //Debug.Log(skillData[i].SkillGrade);
                _rareCount++;
                _rareNum.Add(skillData[i].SkillNumber);
            }
            else if (skillData[i].SkillGrade == 2)
            {
                //Debug.Log(skillData[i].SkillName);
                _superRareCount++;
                _superRareNum.Add(skillData[i].SkillNumber);
            }
        }

        _skill1Select = _skill1.GetComponent<SkillSelectUI>();
        _skill2Select = _skill2.GetComponent<SkillSelectUI>();
        _skill3Select = _skill3.GetComponent<SkillSelectUI>();
        _skill4Select = _skill4.GetComponent<SkillSelectUI>();

        _countDrawing = 0;

        //Debug.Log(_normalCount);
        //Debug.Log(_rareCount);
        //Debug.Log(_superRareCount);

    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用
        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    DrawingRarity();
        //}
    }

    // どのレアリティのスキルを排出するか抽選
    public void DrawingRarity()
    {
        Debug.Log("抽選開始");

        
            // 抽選回数が5回未満なら
            if (_countDrawing < 4)
            {
                // 各レアリティの合計値の間でランダムな整数値が返る
                _randomNum = Random.Range(0, _normalProbability + _rareProbability + _superRareProbability);

                // ノーマル
                if (_randomNum < _normalProbability)
                {
                    Debug.Log("ノーマル排出");
                    SelectNormal();
                }
                // レア
                else if (_randomNum >= _normalProbability && _randomNum < _normalProbability + _rareProbability)
                {
                    Debug.Log("レア排出");
                    SelectRare();
                }
                // スーパーレア
                else if (_randomNum >= _normalProbability + _rareProbability)
                {
                    Debug.Log("スーパーレア排出");
                    SelectSuperRare();
                }
            }
            // 抽選回数が5回以上なら
            else
            {
                _countDrawing = 0;
            }

    }

    void SelectNormal()
    {
        // ノーマルの合計値の間でランダムな整数値が返る
        _randomNum = Random.Range(0, _normalCount);
        // 抽選したスキルデータを反映
        for (int i = 0; i < _skillCount; ++i)
        {
            if (skillData[i].SkillNumber == _normalNum[_randomNum])
            {
                Debug.Log(skillData[i].SkillName);
                if(_countDrawing == 0)
                {
                    _skill1Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 1)
                {
                    _skill2Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 2)
                {
                    _skill3Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 3)
                {
                    _skill4Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                _countDrawing++;
            }
        }

        // 抽選回数が5回未満なら
        if (_countDrawing < 4)
        {
            DrawingRarity();
        }
        else
        {
            _countDrawing = 0;
        }
    }

    void SelectRare()
    {
        // レアの合計値の間でランダムな整数値が返る
        _randomNum = Random.Range(0, _rareCount);
        // 抽選したスキルデータを反映
        for (int i = 0; i < _skillCount; ++i)
        {
            if (skillData[i].SkillNumber == _rareNum[_randomNum])
            {
                Debug.Log(skillData[i].SkillName);
                if (_countDrawing == 0)
                {
                    _skill1Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 1)
                {
                    _skill2Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 2)
                {
                    _skill3Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 3)
                {
                    _skill4Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                _countDrawing++;
            }  
        }
        // 抽選回数が5回未満なら
        if (_countDrawing < 4)
        {
            DrawingRarity();
        }
        else
        {
            _countDrawing = 0;
        }
    }

    void SelectSuperRare()
    {
        // スーパーレアの合計値の間でランダムな整数値が返る
        _randomNum = Random.Range(0, _superRareCount);
        // 抽選したスキルデータを反映
        for (int i = 0; i < _skillCount; ++i)
        {
            if (skillData[i].SkillNumber == _superRareNum[_randomNum])
            {
                Debug.Log(skillData[i].SkillName);
                if (_countDrawing == 0)
                {
                    _skill1Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 1)
                {
                    _skill2Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 2)
                {
                    _skill3Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                else if (_countDrawing == 3)
                {
                    _skill4Select.ReceiveSkillData(skillData[i].SkillNumber, skillData[i].SkillSprite);
                }
                _countDrawing++;
            }
        }
        // 抽選回数が5回未満なら再抽選
        if (_countDrawing < 4)
        {
            DrawingRarity();
        }
        else
        {
            _countDrawing = 0;
        }
    }
}
