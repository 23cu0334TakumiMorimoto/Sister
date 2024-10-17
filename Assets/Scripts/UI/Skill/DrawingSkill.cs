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

    private List<int> _normalNum = new List<int>();
    private List<int> _rareNum = new List<int>();
    private List<int> _superRareNum = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        // ���X�g�̗v�f�����擾
        _skillCount = skillData.Count;
        //Debug.Log(_skillCount);

        // �e���A���e�B�̑������J�E���g
        for (int i = 0; i < _skillCount; ++i)
        {
            // �e���A���e�B�̑����Ɣԍ����J�E���g
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

    // �ǂ̃��A���e�B�̃X�L����r�o���邩���I
    void DrawingRarity()
    {
        // �e���A���e�B�̍��v�l�̊ԂŃ����_���Ȑ����l���Ԃ�
        _randomNum = Random.Range(0, _normalProbability + _rareProbability + _superRareProbability);

        // �m�[�}��
        if(_randomNum < _normalProbability)
        {
            Debug.Log("�m�[�}���r�o");
            SelectNormal();
        }
        // ���A
        else if (_randomNum >= _normalProbability && _randomNum < _normalProbability + _rareProbability)
        {
            Debug.Log("���A�r�o");
            SelectRare();
        }
        // �X�[�p�[���A
        else if (_randomNum >= _normalProbability + _rareProbability)
        {
            Debug.Log("�X�[�p�[���A�r�o");
            SelectSuperRare();
        }
    }

    void SelectNormal()
    {
        // �m�[�}���̍��v�l�̊ԂŃ����_���Ȑ����l���Ԃ�
        _randomNum = Random.Range(0, _normalCount);
        // ���I�����X�L���f�[�^�𔽉f
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
        // ���A�̍��v�l�̊ԂŃ����_���Ȑ����l���Ԃ�
        _randomNum = Random.Range(0, _rareCount);
        // ���I�����X�L���f�[�^�𔽉f
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
        // �X�[�p�[���A�̍��v�l�̊ԂŃ����_���Ȑ����l���Ԃ�
        _randomNum = Random.Range(0, _superRareCount);
        // ���I�����X�L���f�[�^�𔽉f
        for (int i = 0; i < _skillCount; ++i)
        {
            if (skillData[i].SkillNumber == _superRareNum[_randomNum])
            {
                Debug.Log(skillData[i].SkillName);
            }

        }
    }
}
