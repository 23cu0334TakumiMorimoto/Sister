using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayStageNum : MonoBehaviour
{
    //TextMeshProUGUIÇäiî[Ç∑ÇÈÇΩÇﬂÇÃïœêî
    private TextMeshProUGUI _testtext;

    // Start is called before the first frame update
    void Start()
    {
        _testtext = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "TestMainGame")
        {
            _testtext.text = "1";
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            _testtext.text = "2";
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            _testtext.text = "3";
        }
        else
        {
            _testtext.text = "?";
        }
    }
}
