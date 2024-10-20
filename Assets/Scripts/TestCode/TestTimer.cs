using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestTimer : MonoBehaviour
{
    private float countTime = 0;
    private TextMeshProUGUI _testtext;       //TextMeshProUGUI���i�[���邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _testtext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // countTime�ɁA�Q�[�����J�n���Ă���̕b�����i�[
        countTime += Time.deltaTime;

        // ����2���ɂ��ĕ\��
        _testtext.text = countTime.ToString("F2");
    }
}
