using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallUI : MonoBehaviour
{
    private bool _pauseFlg;
    [SerializeField]
    private GameObject _pauseUI;
    [SerializeField]
    private GameObject _lvUpUI;
    [SerializeField]
    private GameObject _pauseArrow;
    [SerializeField]
    private GameObject _lvArrow;
    [SerializeField]
    private GameObject _initPause;
    [SerializeField]
    private GameObject _initLV;

    private PauseSelectUI _pauseSelect;
    private SkillSelectUI _skillSelect;


    private void Start()
    {
        _pauseFlg = false;

        _pauseUI.SetActive(false);
        _lvUpUI.SetActive(false);
        _pauseArrow.SetActive(false);
        _lvArrow.SetActive(false);

        _pauseSelect = _initPause.GetComponent<PauseSelectUI>();
        _skillSelect = _initLV.GetComponent<SkillSelectUI>();
    }

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == false)
        {
            Time.timeScale = 0;
            _pauseFlg = true;
            _pauseUI.SetActive(true);
            _pauseArrow.SetActive(true);
            Debug.Log("ポーズ開始");

            // 矢印の位置初期化
            _pauseSelect.InitSelect();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == true)
        {
            Time.timeScale = 1;
            _pauseFlg = false;
            _pauseUI.SetActive(false);
            _pauseArrow.SetActive(false);
            Debug.Log("ポーズ終了");
        }
    }

    public void PressPause()
    {
        if(_pauseFlg == true)
        {
            Time.timeScale = 1;
            _pauseFlg = false;
            _pauseUI.SetActive(false);
            _pauseArrow.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            _pauseFlg = true;
            _pauseUI.SetActive(true);
        }
    }

    public void LVUP()
    {
        _lvUpUI.SetActive(true);
        _lvArrow.SetActive(true);
        Time.timeScale = 0;
        // 矢印の位置初期化
        _skillSelect.InitSelect();
    }

    public void PressLVUP()
    {
        Time.timeScale = 1;
        _lvUpUI.SetActive(false);
        _lvArrow.SetActive(false);
    }
}
