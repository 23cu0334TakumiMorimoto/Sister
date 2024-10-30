using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class testSprite : MonoBehaviour
{
    public float speed = 1.0f;
    private float time;
    SpriteRenderer _sr;
    UnityEngine.Color spriteColor;
    float duration = 1f;

    Color32 startColor = new Color32(255, 255, 255, 255);
    Color32 endColor = new Color32(255, 255, 255, 64);

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        spriteColor = _sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        _sr.color = UnityEngine.Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }
}
