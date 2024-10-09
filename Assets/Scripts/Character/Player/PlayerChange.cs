using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    // ステータスデータを読み込む
    [SerializeField] PlayerData statusdata;

    // 差し替え画像
    public Sprite SisterSprite;
    public Sprite DevilSprite;
    public Sprite ChangeSprite;
    private SpriteRenderer image;

    void Start()
    {
        // SpriteRendererを取得
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (statusdata.PLAYER_PERSON == 1)
        {
            ChangeSister();
        }
        else
        {
            ChangeDevil();
        }
    }

    private void ChangeSister()
    {
        if (statusdata.PLAYER_PERSON == 1)
        {
            
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("チェンジシスター");
                image.sprite = SisterSprite;
                statusdata.PLAYER_PERSON = 0;
            }
        }
    }

    private void ChangeDevil()
    {
        if (statusdata.PLAYER_PERSON == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("チェンジデビル");
                image.sprite = DevilSprite;
                statusdata.PLAYER_PERSON = 1;
            }
        }
    }
}
