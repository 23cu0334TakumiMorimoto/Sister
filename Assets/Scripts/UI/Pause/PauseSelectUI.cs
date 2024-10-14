using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseSelectUI : Selectable, IPointerClickHandler
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

    // 現在のセレクト状態
    private bool IsSelected;

    private GameObject _gameManager;
    private CallUI _pause;

    [SerializeField]
    [Header("UIの役割")]
    private UIList _UI;  //列挙型の値を格納する変数

    public enum UIList
    {
        Retry, Back
    }

    protected override void Start()
    {
        //if (InitArrow == true)
        //{
        //    // 矢印を無効化
        //    _disableArrow1.SetActive(false);
        //    // 選択状態にする
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //    // フラグを有効化
        //    IsSelected = true;
        //}

        _arrowUI = GameObject.Find("PauseArrow");
        _gameManager = GameObject.Find("GameManager");
        _pause = _gameManager.GetComponent<CallUI>();
    }

    private void Update()
    {
        // Enterキーが押されたら処理
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("押された");
            PauseProcess();
        }
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
        transform.localScale = Vector3.one * 1.3f;
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
        transform.localScale = Vector3.one;

        // フラグを無効化
        IsSelected = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("押された");

        if (IsSelected == true)
        {
            // クリックされた時に行いたい処理
            PauseProcess();
        }

        // フラグを有効化
        IsSelected = true;
    }

    void PauseProcess()
    {
        if(_UI == UIList.Retry)
        {
            Debug.Log("リトライ処理");
            // シーンをリロード
            _pause.PressPause();
            SceneManager.LoadScene("TestMainGame");
        }
        else if (_UI == UIList.Back)
        {
            Debug.Log("バック処理");
            // ウィンドウを閉じる
            _pause.PressPause();
        }

        //// 初期選択状態なら
        //if (InitArrow == true)
        //{
        //    // 選択状態にする
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //}
    }

    // 外部からのみアクセス
    public void InitSelect()
    {
        if (InitArrow == true)
        {
            // 矢印を無効化
            _disableArrow1.SetActive(false);
            // 選択状態にする
            EventSystem.current.SetSelectedGameObject(gameObject);
            // フラグを有効化
            IsSelected = true;
        }
    }
}
