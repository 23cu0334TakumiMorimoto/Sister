using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestSelectUI : Selectable
{
    [SerializeField]
    [Header("初期選択状態にするか")]
    private bool InitArrow;

    private GameObject _arrowUI;
    [SerializeField]
    [Header("有効化する矢印")]
    private GameObject _activeArrow;

    [SerializeField]
    [Header("無効化する矢印")]
    private GameObject _disableArrow1;
    [SerializeField]
    private GameObject _disableArrow2;
    [SerializeField]
    private GameObject _disableArrow3;

    protected override void Start()
    {
        if (InitArrow == true)
        {
            // 矢印を無効化
            _disableArrow1.SetActive(false);
            _disableArrow2.SetActive(false);
            _disableArrow3.SetActive(false);
            // 選択状態にする
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        _arrowUI = GameObject.Find("Arrow");
        //// 色を初期化
        //GetComponent<Image>().material.color = new Color(255, 255, 255);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}が選択された");

        // 矢印を有効化
        _activeArrow.SetActive(true);

        //// 色を変更
        //GetComponent<Image>().material.color = new Color(255, 0, 0);

        // transformのアニメーション
        transform.localScale = Vector3.one * 1.3f; // ラープで拡大・縮小
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name}の選択が外れた");

        // 矢印を無効化
        _activeArrow.SetActive(false);

        //// 色を戻す
        //GetComponent<Image>().material.color = new Color(255, 255, 255);

        // transformのアニメーション
        transform.localScale = Vector3.one; // ラープで拡大・縮小
    }
}

