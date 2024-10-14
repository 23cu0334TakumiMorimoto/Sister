using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

public class Pause_Retry : MonoBehaviour
{
    public Button myButton;
    private GameObject _gameManager;
    private CallUI _pause;

    // Start is called before the first frame update
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
        SceneManager.LoadScene("TestMainGame");
    }
}
