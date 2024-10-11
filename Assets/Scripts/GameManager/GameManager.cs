using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        DebugCommand();
    }

    void DebugCommand()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("TestMainGame");
        }
    }
}
