using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_UIData: MonoBehaviour
{
    [System.Serializable] public class SkillData
    {
        [Header("スキル番号")]
        public int SkillNumber;

        [Header("レアリティ")]
        [Header("0:ノーマル　1:レア　2:スーパーレア")]
        public int SkillGrade;

        public Sprite SkillSprite;
    }
    // 通常のListとしてinspectorで扱える
    [SerializeField] List<SkillData> skillData = new List<SkillData>();
}
