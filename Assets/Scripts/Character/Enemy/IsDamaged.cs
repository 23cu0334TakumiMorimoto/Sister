using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class IsDamaged : MonoBehaviour
{

    private IsDamaged[] _enemyCol;       //メニューなどのボタンを格納するための配列変数

    private enum _collider
    {
      box,
      circle
    }
    [SerializeField] _collider EnemyCol;　　　　//プルダウン化

    // 他オブジェクトの位置を取得
    private GameObject _player;
    private Vector2 _playerPos;
    private GameObject _god;
    private Vector2 _godPos;

    // ステータスデータを読み込む
    [SerializeField]
    public StatusData _statusdata;
    [SerializeField]
    private PlayerData _playerdata;
    [SerializeField]
    private NewGodData _goddata;

    // 攻撃を受けたときに出す画像
    // [SerializeField]
    //private GameObject Hitmark;
    private Vector3 Hitpos;

    // 魂のプレハブ
    [SerializeField]
    private GameObject _expPrefab;

    [Header("敵の状態が仮死状態かどうか")]
    public bool IsDead;

    [SerializeField]
    [Header("死亡タイマー")]
    // 仮死状態のタイマー
    private float _deadTimer;

    //攻撃を受けるかどうかの切り替えを行う
    bool MUTEKI;

    public float _currentHP;
    private float currentTime = 0f;

    [SerializeField]
    [Header("キーを離したかどうか")]
    bool IsGetKeyUp;

    private Rigidbody2D rb;
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip Sound;

    [SerializeField]
    [Header("ボスであるかどうか")]
    private bool IsBoss;

    [SerializeField]
    [Header("弾であるかどうか")]
    private bool IsBullet;

    //[SerializeField]
    //private GameObject manager;
    //private GameManager _GM;

    [SerializeField] private string loadClear;
    [SerializeField] private Color clearColor = Color.white;
    [SerializeField] private float fadeSpeedMultiplier = 3.0f;

    private SpriteRenderer _sr;
    private float cla;
    [SerializeField]
    [Header("透明になる速度")]
    private float speed = 1;

    private GameObject _gameManager;
    private CallUI _callUI;

    // 色変更
    bool isdamage;    //ダメージを受けたらtureになる
    Color spriteColor;
    float duration = 1f;

    Color32 startColor = new Color32(255, 255, 255, 255);
    Color32 endColor = new Color32(255, 255, 255, 64);

    private BoxCollider2D _box;
    private CircleCollider2D _circle;

    void Start()
    {
        if (IsBullet == false)
        {
            _box = GetComponent<BoxCollider2D>();
            _circle = GetComponent<CircleCollider2D>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerPos = _player.transform.position;
            _god = GameObject.FindGameObjectWithTag("God");
            _godPos = _god.transform.position;
            _gameManager = GameObject.Find("GameManager");
            this.transform.LookAt(_playerPos);
            _currentHP = _statusdata.MAXHP;
            rb = GetComponent<Rigidbody2D>();//Rigidbody2Dの取得
            IsGetKeyUp = false;
            _animator = GetComponent<Animator>();
            _animator.SetInteger("Action", 0);
            _audioSource = GetComponent<AudioSource>();
            _sr = GetComponent<SpriteRenderer>();
            _callUI = _gameManager.GetComponent<CallUI>();

            _deadTimer = 0f;

            //_GM = manager.GetComponent<GameManager>();
            spriteColor = _sr.color;
        }

    }
    void Update()
    {
        if (IsBullet == false)
        {


            if (MUTEKI) //攻撃を受けてから0.2秒後にする処理
            {
                currentTime += Time.deltaTime;
                if (currentTime > _statusdata.MUTEKI_SPAN)
                {
                    currentTime = 0f;
                    MUTEKI = false;//無敵状態終わらせる
                    rb.velocity = new Vector2(0, 0);//ノックバックをとめる
                                                    //Hitmark.GetComponent<SpriteRenderer>().enabled = false;
                }

            }

            if (_currentHP <= 0)
            {
                Hitpos = this.transform.position;
                Hitpos.z = -2f;
                //Hitmark.transform.position = Hitpos;
                //Hitmark.GetComponent<SpriteRenderer>().enabled = true;



                //HPが0以下になったら仮死状態にする
                IsDead = true;
                // オブジェクトを破棄する
                //Destroy(this.gameObject);
            }

            // 仮死状態なら
            if (IsDead == true)
            {
                Asphyxia();
            }

            KeyState();
        }
    }

    public void Damage(float damage)
    {
        // 仮死状態ではないなら処理
        if (IsDead == false && IsBullet == false)
        {
            if (!MUTEKI)
            {//無敵状態じゃないときに攻撃を受ける
                isdamage = true;
                Hitpos = this.transform.position;
                Hitpos.z = -2f;//Z軸を敵キャラよりも手前に設定
                //Hitmark.transform.position = Hitpos;//ヒットマークの画像位置を移動させる
                //Hitmark.GetComponent<SpriteRenderer>().enabled = true; //ヒットマーク画像を表示する

                _currentHP -= damage;//HP減少
                Debug.Log(_currentHP);//現在のHPを表示
                MUTEKI = true;//無敵状態にする
            }
        }

    }

    public void Dead()
    {
        // 仮死状態なら処理
        if (IsDead == true && IsBullet == false)
        {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }

    // 引数１：ノックバックの強さ
    // 引数２：神像に触れたかどうか
    public void KnockBack(float nockback, bool IsGod)
    {
        // 仮死状態ではないなら処理
        if (IsDead == false && IsBullet == false)
        {
            float nb = nockback - _statusdata.Weight;
            //if(nb <= 0)
            //{
            //    nb = 0.5f;
            //}

            Vector2 thisPos = transform.position;

            if (IsGod == true)
            {
                //攻撃を受けた時点での敵キャラと神像との位置関係
                float distinationX = thisPos.x - _godPos.x;
                float distinationY = thisPos.y - _godPos.y;
                rb.velocity = new Vector2(distinationX * nb, distinationY * nb);//殴った方向に飛んでいく
            }

            else
            {
                if (_currentHP > 0)
                {
                    StartCoroutine("ColorChange");
                    //攻撃を受けた時点での敵キャラとプレイヤーとの位置関係
                    float distinationX = thisPos.x - _playerPos.x;
                    float distinationY = thisPos.y - _playerPos.y;
                    rb.velocity = new Vector2(distinationX * nb, distinationY * nb);//殴った方向に飛んでいく
                }
            }
            MUTEKI = true;//無敵状態にする
                          // Debug.Log("ノックバック！");
        }
    }

    // 仮死状態
    public void Asphyxia()
    {
        _animator.SetInteger("Action", 1);
        _deadTimer += Time.deltaTime;
        if (_deadTimer > _statusdata.DEAD_TIME)
        {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }

    private void KeyState()
    {
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            IsGetKeyUp = true;
            //Debug.Log("Key Up");
        }

        else if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            IsGetKeyUp = false;
            // Debug.Log("Key Down");
        }
    }

    private void SendSoul()
    {
        Instantiate(_expPrefab, transform.position, Quaternion.identity);

        if (IsBoss == true)
        {
            // コライダー無効化
            if(EnemyCol == _collider.box)
            {
                _box.enabled = false;
            }
            else if (EnemyCol == _collider.circle)
            {
                _circle.enabled = false;
            }

            cla = _sr.color.a;
            StartCoroutine(Display(0));
            _callUI.IsClear = true;

            SwitchClear();
        }
        else
        {
            // コライダー無効化
            if (EnemyCol == _collider.box)
            {
                _box.enabled = false;
            }
            else if (EnemyCol == _collider.circle)
            {
                _circle.enabled = false;
            }

            cla = _sr.color.a;
            StartCoroutine(Display(0));
        }
    }

    // 祈りの範囲内にいる間処理
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pray" && IsDead == true && IsBullet == false)
        {
            _sr.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
        }

        if (col.gameObject.tag == "Attck" && IsBullet == true)
        {
            Destroy(gameObject);
        }

        //if(col.gameObject.tag == "Attack")
        //{
        //    KnockBack(_statusdata.NockBack, false);
        //    if(IsDead != true)
        //    {
        //        //_audioSource.PlayOneShot(Sound);
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pray" && IsDead == true && IsGetKeyUp == true && IsBullet == false)
        {
            Debug.Log("祈りに衝突");
            SendSoul();
        }

        //if(col.gameObject.tag == "Attack")
        //{
        //    KnockBack(_statusdata.NockBack, false);
        //    if(IsDead != true)
        //    {
        //        //_audioSource.PlayOneShot(Sound);
        //    }
        //}
    }

    public void SwitchClear()
    {

        Time.timeScale = 0.1f;
        StartCoroutine("CameraShake");
        Initiate.Fade(loadClear, clearColor, fadeSpeedMultiplier);

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
        yield return new WaitForSeconds(1f);
        _goddata.EXP += _statusdata.EXP;
        Debug.Log("消去");
        Destroy(gameObject);
    }

    // ダメージを受けた際に色を変更する
    IEnumerator ColorChange()
    {
        if (isdamage == true)
        {
            // 色を赤に変更
            _sr.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds(0.1f);

            // 色を元に戻す
            _sr.color = new Color(255f, 255f, 255f, 255f);
            // isdamageの値を０に戻す
            isdamage = false;

        }
    }
}