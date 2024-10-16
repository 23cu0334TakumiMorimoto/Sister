using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_UIData: MonoBehaviour
{
    [System.Serializable] public class SkillData
    {
        [Header("�X�L���ԍ�")]
        public int SkillNumber;

        [Header("�X�L����")]
        public string SkillName;

        [Header("���A���e�B")]
        [Header("0:�m�[�}���@1:���A�@2:�X�[�p�[���A")]
        public int SkillGrade;

        [Header("�o���t�F�[�Y")]
        [Header("0:1st�t�F�[�Y�@1:2nd�t�F�[�Y�@2:�ŏI�t�F�[�Y")]
        public int AppearPhase;

        [Header("�X�L���摜")]
        public Sprite SkillSprite;
    }
    // �ʏ��List�Ƃ���inspector�ň�����
    //[SerializeField] List<SkillData>skillData = new List<SkillData>();
    public List<SkillData> skillData = new List<SkillData>();
}
