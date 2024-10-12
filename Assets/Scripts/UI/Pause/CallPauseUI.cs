using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPauseUi : MonoBehaviour
{
    private bool _pauseFlg;
    private GameObject _pauseUI;

    private void Start()
    {
        _pauseFlg = false;
        _pauseUI = GameObject.Find("PauseUI");

        _pauseUI.SetActive(false);
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
            Debug.Log("�|�[�Y�J�n");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == true)
        {
            Time.timeScale = 1;
            _pauseFlg = false;
            _pauseUI.SetActive(false);
            Debug.Log("�|�[�Y�I��");
        }
    }

    public void PressButton()
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

}
