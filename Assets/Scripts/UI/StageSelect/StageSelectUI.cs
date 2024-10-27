using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectUI : Selectable, IPointerClickHandler
{
    private StageSelectUI[] _stage;       //ステージ配列変数
    private enum _select
    {
        Stage1,
        Stage2,
        Stage3,
        None
    }
    [SerializeField] _select StageSelect;　　　　//プルダウン化

    [SerializeField]
    [Header("初期選択状態にするか")]
    private bool Init;

    // 現在のセレクト状態
    private bool IsSelected;
    private bool OnClicked;

    // Start is called before the first frame update
    private void Start()
    {
        InitSelect();
    }

    // Update is called once per frame
    private void Update()
    {
        // Enterキーが押されたら処理
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //Debug.Log("押された");
            TransitionStage();
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        //base.OnSelect(eventData);
        // Debug.Log($"{gameObject.name}が選択された");

        // transformのアニメーション
        transform.localScale = Vector3.one * 1.1f;

        // フラグを有効化
        IsSelected = true;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        //base.OnDeselect(eventData);
        // Debug.Log($"{gameObject.name}の選択が外れた");

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
            TransitionStage();
        }

        // フラグを有効化
        OnClicked = true;
    }

    private void TransitionStage()
    {
        if (IsSelected == true)
        {
            if(StageSelect == _select.Stage1)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (StageSelect == _select.Stage2)
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (StageSelect == _select.Stage3)
            {
                SceneManager.LoadScene("Stage3");
            }
            else if (StageSelect == _select.None)
            {

            }
        }
    }

    public void InitSelect()
    {
        if (Init == true)
        {
            // 選択状態にする
            EventSystem.current.SetSelectedGameObject(gameObject);
            // フラグを有効化
            IsSelected = true;
        }
    }
}
