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

        //Debug.Log(_normalCount);
        //Debug.Log(_rareCount);
        //Debug.Log(_superRareCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DrawingRarity();
        }
    }

    // どのレアリティのスキルを排出するか抽選
    void DrawingRarity()
    {
        // 各レアリティの合計値の間でランダムな整数値が返る
        _randomNum = Random.Range(0, _normalProbability + _rareProbability + _superRareProbability);

        // ノーマル
        if(_randomNum < _normalProbability)
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
            }
                
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
            }
                
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
            }

        }
    }
}
