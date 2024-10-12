using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを使用するために必要
using UnityEngine.EventSystems;  //EventSystemを使うため追記

public class PauseUIManager : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/PauseUI/Button").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
}
