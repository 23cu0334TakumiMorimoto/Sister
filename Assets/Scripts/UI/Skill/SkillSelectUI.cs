using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectUI : Selectable, IPointerClickHandler
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

    // 現在のセレクト状態
    private bool IsSelected;
    private bool OnClicked;

    private GameObject _gameManager;
    private CallUI _pause;

    // 差し替え画像
    private Image image;
    private SkillProcess _skill;
    private int _callSkill;

    protected override void Start()
    {
        //if (InitArrow == true)
        //{
        //    // 矢印を無効化
        //    _disableArrow1.SetActive(false);
        //    _disableArrow2.SetActive(false);
        //    _disableArrow3.SetActive(false);
        //    // 選択状態にする
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //    // フラグを有効化
        //    IsSelected = true;
        //}

        _arrowUI = GameObject.Find("LVArrow");
        //// 色を初期化
        //GetComponent<Image>().material.color = new Color(255, 255, 255);
        _gameManager = GameObject.Find("GameManager");
        _pause = _gameManager.GetComponent<CallUI>();

        // SpriteRendererを取得
        image = GetComponent<Image>();
        _skill = GetComponent<SkillProcess>();
    }

    private void Update()
    {
        // Enterキーが押されたら処理
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //Debug.Log("押された");
            SkillProcess();
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        // Debug.Log($"{gameObject.name}が選択された");

        // 矢印を有効化
        _activeArrow.SetActive(true);

        //// 色を変更
        //GetComponent<Image>().material.color = new Color(255, 0, 0);

        // transformのアニメーション
        transform.localScale = Vector3.one * 1.3f;

        // フラグを有効化
        IsSelected = true;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        // Debug.Log($"{gameObject.name}の選択が外れた");

        // 矢印を無効化
        _activeArrow.SetActive(false);

        //// 色を戻す
        //GetComponent<Image>().material.color = new Color(255, 255, 255);

        // transformのアニメーション
        transform.localScale = Vector3.one;

        // フラグを無効化
        IsSelected = false;
        OnClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("押された");

        if (OnClicked == true)
        {
            // クリックされた時に行いたい処理
            SkillProcess();
        }

        // フラグを有効化
        OnClicked = true;
    }

    void SkillProcess()
    {
        if (IsSelected == true)
        {
            Debug.Log("スキル処理");

            _skill.ChooseSkill(_callSkill);

            // ウィンドウを閉じる
            _pause.PressLVUP();
        }
    }

    // 外部からのみアクセス
    // 矢印の初期化
    public void InitSelect()
    {
        if (InitArrow == true)
        {
            // 矢印を無効化
            _disableArrow1.SetActive(false);
            _disableArrow2.SetActive(false);
            _disableArrow3.SetActive(false);
            // 選択状態にする
            EventSystem.current.SetSelectedGameObject(gameObject);
            // フラグを有効化
            IsSelected = true;
        }
    }

    // 能力を反映する
    public void ReceiveSkillData(int SkillNum, Sprite SkillSprite)
    {
        Debug.Log(SkillNum);
        image.sprite = SkillSprite;
        _callSkill = SkillNum;
        //skill.ChooseSkill(SkillNum);
    }
}

