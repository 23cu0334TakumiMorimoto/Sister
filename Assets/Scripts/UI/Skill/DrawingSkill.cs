using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �X�L�����I����X�N���v�g

public class DrawingSkill : LV_UIData
{
    private int _skillCount;
    private int _normalCount;
    private int _rareCount;
    private int _superRareCount;
    private SkillData _skill;

    private int _randomNum;
    [SerializeField]
    [Header("�m�[�}���̏o�₷��")]
    private int _normalProbability;
    [SerializeField]
    [Header("���A�̏o�₷��")]
    private int _rareProbability;
    [SerializeField]
    [Header("�X�[�p�[���A�̏o�₷��")]
    private int _superRareProbability;

    // Start is called before the first frame update
    void Start()
    {
        // ���X�g�̗v�f�����擾
        _skillCount = skillData.Count;

        // �e���A���e�B�̑������J�E���g
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

    // �ǂ̃��A���e�B�̃X�L����r�o���邩���I
    void DrawingRarity()
    {
        // 1�`�e���A�̍��v�l�̊ԂŃ����_���Ȑ����l���Ԃ�
        _randomNum = Random.Range(1, _normalProbability + _rareProbability + _superRareProbability);

        // �m�[�}��
        if(_randomNum < _normalProbability)
        {
            Debug.Log("�m�[�}���r�o");
        }
        // ���A
        else if (_randomNum >= _normalProbability && _randomNum < _normalProbability + _rareProbability)
        {
            Debug.Log("���A�r�o");
        }
        // �X�[�p�[���A
        else if (_randomNum >= _normalProbability + _rareProbability)
        {
            Debug.Log("�X�[�p�[���A�r�o");
        }
    }
}
