using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransition : MonoBehaviour
{
    // フェードイン関係のスクリプト
    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        TransitionScene();
    }

    void TransitionScene()
    {
        if (Input.anyKeyDown)
        {
            Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
        }
    }
}
