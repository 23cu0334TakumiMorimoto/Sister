using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestTimer : MonoBehaviour
{
    private float countTime = 0;
    private TextMeshProUGUI _testtext;       //TextMeshProUGUIを格納するための変数

    // Start is called before the first frame update
    void Start()
    {
        _testtext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // countTimeに、ゲームが開始してからの秒数を格納
        countTime += Time.deltaTime;

        // 小数2桁にして表示
        _testtext.text = countTime.ToString("F2");
    }
}
