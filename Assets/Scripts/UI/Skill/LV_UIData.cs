using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_UIData: MonoBehaviour
{
    [System.Serializable] public class SkillData
    {
        [Header("�X�L���ԍ�")]
        public int SkillNumber;

        [Header("���A���e�B")]
        [Header("0:�m�[�}���@1:���A�@2:�X�[�p�[���A")]
        public int SkillGrade;

        public Sprite SkillSprite;
    }
    // �ʏ��List�Ƃ���inspector�ň�����
    [SerializeField] List<SkillData> skillData = new List<SkillData>();
}
