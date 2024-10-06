using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class soulcounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    private int count;
    private float timeReset;
    private float time;
    private int currentsoul;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 0;
        timeReset = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            currentsoul+=10;
        }
        time += Time.deltaTime;

        if (time > timeReset)
        {
            if (count < currentsoul)
            {
                count++;
                time = 0;
            }
        }
        countText.text = count.ToString();
    }
}
