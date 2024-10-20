using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ATKGenerator : MonoBehaviour
{

    // ステータスデータを読み込む
    [SerializeField] PlayerData statusdata;
    // 攻撃判定の弾のプレハブ
    [SerializeField] private GameObject _atkPrefab;
    // 弾を生成する座標の基準
    [SerializeField] private Transform _atkCoordinate;
    // 弾を生成する座標
    private Vector2 _atkPoint;
    // 弾を生成する角度
    private Quaternion _atkRot;
    // 発射間隔(秒)
    [SerializeField] private float _fireRate; 
    // 攻撃方向
    [SerializeField]
    [Header("攻撃方向")]
    [Header("1:上 2:下 3:左 4:右")]
    private int _atkDirection;
    private float timer;       // タイマー
    // 自動で攻撃するか手動で攻撃するか
    [SerializeField]
    [Header("自動攻撃")]
    private bool _autoAttack;

    GameObject gameManagerObj;
    Inoperable IAttacked;

    private bool ATKflg;

    private Rigidbody2D rb;
    private Animator _animator;
    float anim_speed;

    private void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        IAttacked = gameManagerObj.GetComponent<Inoperable>(); // スクリプトを取得
        rb = GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
        timer = 0;
        ATKflg = false;

        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // 攻撃方向を更新
        GetDirection();
        anim_speed = statusdata.Attack_STIFFNESS;

        if (statusdata.PLAYER_PERSON != 0)
        {
            if (_autoAttack == true)
            {
                // タイマーを更新
                timer += Time.deltaTime;

                // 指定の間隔で弾を生成して発射
                if (timer >= _fireRate)
                {
                    // 弾の生成
                    FireAtk();

                    timer = 0f; // タイマーをリセット
                }
            }

            else
            {
                // JキーかZキーで攻撃
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
                {
                    ATKflg = true;
                }

                if (ATKflg == true)
                {
                    // タイマーを更新
                    timer += Time.deltaTime;
                    // 弾の生成
                    if (timer >= statusdata.Attack_SPAN)
                    {
                        FireAtk();

                        _animator.SetInteger("Action", 5);
                        // 指定された時間プレイヤー操作を無効にする
                        IAttacked.CallInoperable(statusdata.Attack_STIFFNESS, 0);
                        // 速度を０にする
                        rb.velocity = new Vector2(0, 0);

                        // タイマーをリセット
                        timer = 0;
                        // フラグを元に戻す
                        ATKflg = false;
                    }
                }
            }
        }
    }

    void FireAtk()
    {
        // 上方向を代入
        if(_atkDirection == 1)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x, _atkCoordinate.position.y + 1f); 
            _atkRot = Quaternion.Euler(0, 0, 0);
        }
        // 下方向を代入
        else if (_atkDirection == 2)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x, _atkCoordinate.position.y - 1f);
            _atkRot = Quaternion.Euler(0, 0, 180);
        }
        // 左方向を代入
        else if (_atkDirection == 3)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x - 1f, _atkCoordinate.position.y);
            _atkRot = Quaternion.Euler(0, 0, 270);
        }
        // 右方向を代入
        else if (_atkDirection == 4)
        {
            _atkPoint = new Vector2(_atkCoordinate.position.x + 1f, _atkCoordinate.position.y);
            _atkRot = Quaternion.Euler(0, 0, 90);
        }

        // 弾の生成
        Instantiate(_atkPrefab, _atkPoint, _atkRot);
    }

    private void GetDirection()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // 攻撃方向を上に設定
            _atkDirection = 1;
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // 攻撃方向を下に設定
            _atkDirection = 2;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // 攻撃方向を左に設定
            _atkDirection = 3;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // 攻撃方向を右に設定
            _atkDirection = 4;
        }
    }
}