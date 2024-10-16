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

    // Start is called before the first frame update
    void Start()
    {
        // リストの要素数を取得
        _skillCount = skillData.Count;

        // 各レアリティの総数をカウント
        for(int i = 0; i > _skillCount; ++i)
        {
            if (skillData[i].SkillGrade == 0)
            {
                _normalCount++;
            }
            else if (skillData[i].SkillGrade == 1)
            {
                _rareCount++;
            }
            else if (skillData[i].SkillGrade == 2)
            {
                _superRareCount++;
            }
        }
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
        // 1～各レアの合計値の間でランダムな整数値が返る
        _randomNum = Random.Range(1, _normalProbability + _rareProbability + _superRareProbability);

        // ノーマル
        if(_randomNum < _normalProbability)
        {
            Debug.Log("ノーマル排出");
        }
        // レア
        else if (_randomNum >= _normalProbability && _randomNum < _normalProbability + _rareProbability)
        {
            Debug.Log("レア排出");
        }
        // スーパーレア
        else if (_randomNum >= _normalProbability + _rareProbability)
        {
            Debug.Log("スーパーレア排出");
        }
    }
}
