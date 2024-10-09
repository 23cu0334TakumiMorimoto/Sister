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

    GameObject gameManagerObj;
    Inoperable IChanged;
    private Rigidbody2D rb;
    // タイマー
    [SerializeField]
    [Header("変身のクールタイマー")]
    private float ChangeCoolTimer;       

    void Start()
    {
        // SpriteRendererを取得
        image = GetComponent<SpriteRenderer>();
        // スクリプトを取得
        gameManagerObj = GameObject.Find("GameManager");
        IChanged = gameManagerObj.GetComponent<Inoperable>();
        rb = GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
        ChangeCoolTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを更新
        ChangeCoolTimer += Time.deltaTime;

        // 変身クールタイムを満たしていたら
        if (ChangeCoolTimer >= statusdata.CHANGE_COOL_TIME)
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
    }

    private void ChangeSister()
    {

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("チェンジシスター");
            image.sprite = SisterSprite;
            // 指定された時間プレイヤー操作を無効にする
            IChanged.CallInoperable(statusdata.CHANGE_TRANSITION_TIME);
            // 速度を０にする
            rb.velocity = new Vector2(0, 0);
            // 人格を切り替えてステータスを切り替える
            statusdata.PLAYER_PERSON = 0;
            // タイマーを初期化
            ChangeCoolTimer = 0;

        }
    }

    private void ChangeDevil()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("チェンジデビル");
            image.sprite = DevilSprite;
            // 指定された時間プレイヤー操作を無効にする
            IChanged.CallInoperable(statusdata.CHANGE_TRANSITION_TIME);
            // 速度を０にする
            rb.velocity = new Vector2(0, 0);
            // 人格を切り替えてステータスを切り替える
            statusdata.PLAYER_PERSON = 1;
            // タイマーを初期化
            ChangeCoolTimer = 0;
        }
    }
}
