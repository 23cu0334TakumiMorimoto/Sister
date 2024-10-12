using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを使用するために必要

public class PauseUIManager : MonoBehaviour
{
    public Button myButton; // エディタからアサインするボタンの参照
    public GameObject gameObjectToActivate; // アクティブにするゲームオブジェクトの参照

    void Start()
    {
        // ボタンのonClickイベントにリスナーを追加
        myButton.onClick.AddListener(ActivateObject);
    }

    // ゲームオブジェクトをアクティブにするメソッド
    void ActivateObject()
    {
        gameObjectToActivate.SetActive(true); // ゲームオブジェクトをアクティブにする
    }

    void OnDestroy()
    {
        // オブジェクトが破棄された時にリスナーを削除する（重要）
        myButton.onClick.RemoveListener(ActivateObject);
    }
}
