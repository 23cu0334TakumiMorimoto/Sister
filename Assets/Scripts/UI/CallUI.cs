using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallUI : MonoBehaviour
{
    private bool _pauseFlg;
    private GameObject _pauseUI;
    private GameObject _lvUpUI;

    private void Start()
    {
        _pauseFlg = false;
        _pauseUI = GameObject.Find("PauseUI");
        _lvUpUI = GameObject.Find("LVupUI");

        _pauseUI.SetActive(false);
        _lvUpUI.SetActive(false);
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
            Debug.Log("ポーズ開始");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == true)
        {
            Time.timeScale = 1;
            _pauseFlg = false;
            _pauseUI.SetActive(false);
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
        Time.timeScale = 0;
    }

}
