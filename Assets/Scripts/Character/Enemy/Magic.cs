using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    Color spriteColor;
    float duration = 1f;
    private SpriteRenderer _sr;

    [SerializeField]
    private GameObject Goat;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Goat, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            StartCoroutine(Display(0));
        }
    }

    IEnumerator Display(float targetAlpha)
    {
        while (!Mathf.Approximately(spriteColor.a, targetAlpha))
        {
            float changePerFrame = Time.deltaTime / duration;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
            _sr.color = spriteColor;
            yield return null;
        }
        Destroy(gameObject);
    }
}
