using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_UIData: MonoBehaviour
{
    [System.Serializable] public class SkillData
    {
        [Header("スキル番号")]
        public int SkillNumber;

        [Header("スキル名")]
        public string SkillName;

        [Header("レアリティ")]
        [Header("0:ノーマル　1:レア　2:スーパーレア")]
        public int SkillGrade;

        [Header("出現フェーズ")]
        [Header("0:1stフェーズ　1:2ndフェーズ　2:最終フェーズ")]
        public int AppearPhase;

        [Header("スキル画像")]
        public Sprite SkillSprite;
    }
    // 通常のListとしてinspectorで扱える
    //[SerializeField] List<SkillData>skillData = new List<SkillData>();
    public List<SkillData> skillData = new List<SkillData>();
}
