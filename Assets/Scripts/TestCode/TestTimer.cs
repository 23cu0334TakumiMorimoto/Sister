using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestTimer : MonoBehaviour
{
    private float countTime = 0;
    private TextMeshProUGUI _testtext;       //TextMeshProUGUI‚ğŠi”[‚·‚é‚½‚ß‚Ì•Ï”

    // Start is called before the first frame update
    void Start()
    {
        _testtext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // countTime‚ÉAƒQ[ƒ€‚ªŠJn‚µ‚Ä‚©‚ç‚Ì•b”‚ğŠi”[
        countTime += Time.deltaTime;

        // ¬”2Œ…‚É‚µ‚Ä•\¦
        _testtext.text = countTime.ToString("F2");
    }
}
