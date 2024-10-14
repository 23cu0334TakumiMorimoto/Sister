using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause_Back : MonoBehaviour
{
    public Button myButton;
    private GameObject _gameManager;
    private CallUI _pause;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _pause = _gameManager.GetComponent<CallUI>();

        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        _pause.PressPause();
    }
}
