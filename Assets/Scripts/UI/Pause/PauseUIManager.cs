using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g���g�p���邽�߂ɕK�v
using UnityEngine.EventSystems;  //EventSystem���g�����ߒǋL

public class PauseUIManager : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/PauseUI/Button").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();
    }
}
