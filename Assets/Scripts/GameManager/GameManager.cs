using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private God _godScript;
    [SerializeField] private GameObject _god;

    // フェードイン関係のスクリプト
    [SerializeField] private string loadGameOver;
    [SerializeField] private string loadClear;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private Color clearColor = Color.white;
    [SerializeField] private float fadeSpeedMultiplier = 3.0f;

    // シェイク関係のスクリプト
    public GameObject mainCamera;
    private float moveX;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
        _godScript = _god.GetComponent<God>();
    }

    // Update is called once per frame
    void Update()
    {
        DebugCommand();
        SwitchGameOver();
    }

    void DebugCommand()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Scene ThisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("TestMainGame");
        }
    }

    public void SwitchClear()
    {
        if (_godScript._currentHealth < 0)
        {
            Time.timeScale = 0.5f;
            StartCoroutine("CameraShake");
            Initiate.Fade(loadClear, clearColor, fadeSpeedMultiplier);
        }
    }

    void SwitchGameOver()
    {
        if (_godScript._currentHealth < 0)
        {
            Time.timeScale = 0.5f;
            StartCoroutine("CameraShake");
            Initiate.Fade(loadGameOver, fadeColor, fadeSpeedMultiplier);
        }
    }

    IEnumerator CameraShake()
    {
        for (int i = 0; i < 30; i++)
        {
            mainCamera.transform.Translate(moveX, 0, 0);
            moveX *= -1;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
