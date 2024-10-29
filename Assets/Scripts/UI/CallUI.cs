using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CallUI : MonoBehaviour
{
    private bool _pauseFlg;
    [SerializeField]
    private GameObject _pauseUI;
    [SerializeField]
    private GameObject _lvUpUI;
    [SerializeField]
    private GameObject _pauseArrow;
    [SerializeField]
    private GameObject _lvArrow;
    [SerializeField]
    private GameObject _initPause;
    [SerializeField]
    private GameObject _initLV;
    [SerializeField]
    private GameObject _skillManager;

    private PauseSelectUI _pauseSelect;
    private SkillSelectUI _skillSelect;
    private DrawingSkill _drawingSkill;

    private bool _calledPause;
    private bool _calledSkill;

    // 一度にスキルウィンドウが呼ばれた数
    public int _callCount;
    public bool _oneMoreSkill;

    // クリアしたかどうか
    public bool IsClear;

    public AudioClip Sound;
    private AudioSource _audioSource;
    private bool _audio;


    private void Start()
    {
        _pauseFlg = false;

        _pauseUI.SetActive(false);
        _lvUpUI.SetActive(false);
        _pauseArrow.SetActive(false);
        _lvArrow.SetActive(false);

        // スクリプトを取得
        _pauseSelect = _initPause.GetComponent<PauseSelectUI>();
        _skillSelect = _initLV.GetComponent<SkillSelectUI>();
        _drawingSkill = _skillManager.GetComponent<DrawingSkill>();

        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (_calledSkill != true && IsClear != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == false || Input.GetKeyDown(KeyCode.Joystick1Button7) && _pauseFlg == false)
            {
                _calledPause = true;
                Time.timeScale = 0;
                _pauseFlg = true;
                _pauseUI.SetActive(true);
                _pauseArrow.SetActive(true);
                Debug.Log("ポーズ開始");

                // 矢印の位置初期化
                _pauseSelect.InitSelect();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == true || Input.GetKeyDown(KeyCode.Joystick1Button7) && _pauseFlg == true)
            {
                _calledPause = false;
                Time.timeScale = 1;
                _pauseFlg = false;
                _pauseUI.SetActive(false);
                _pauseArrow.SetActive(false);
                Debug.Log("ポーズ終了");
            }
        }
    }

    public void PressPause()
    {
        if (_calledSkill != true)
        {
            if (_pauseFlg == false)
            {
                _calledPause = true;
                Time.timeScale = 0;
                _pauseFlg = true;
                _pauseUI.SetActive(true);
            }
            else
            {
                _calledPause = false;
                Time.timeScale = 1;
                _pauseFlg = false;
                _pauseUI.SetActive(false);
                _pauseArrow.SetActive(false);
            }
        }
    }

    public void LVUP()
    {
        if (_calledPause != true && IsClear != true)
        {

            _calledSkill = true;
            // 呼び出される回数をカウント
            _callCount++;

            if(_callCount == 1 || _oneMoreSkill == true)
            {
                _audioSource.PlayOneShot(Sound);
                _lvUpUI.SetActive(true);
                _lvArrow.SetActive(true);
                Time.timeScale = 0;
                // 矢印の位置初期化
                _skillSelect.InitSelect();
                _drawingSkill.DrawingRarity();
            }
            else
            {
                _oneMoreSkill = true;
            }
            
        }
    }

    public void PressLVUP()
    {
        if (_calledPause != true)
        {
            _calledSkill = false;
            _callCount--;
            Time.timeScale = 1;
            _lvUpUI.SetActive(false);
            _lvArrow.SetActive(false);

            // 一度に複数回レベルアップしたなら処理
            // レベルアップ回数が残り１回なら
            if(_oneMoreSkill == true && _callCount == 1)
            {
                _oneMoreSkill = false;
                _callCount--;
                LVUP();
            }
            // レベルアップ回数が残り２回以上なら
            else if (_oneMoreSkill == true && _callCount >= 2)
            {
                _callCount--;
                LVUP();
            }
        }
    }
}
