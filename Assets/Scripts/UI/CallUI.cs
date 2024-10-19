using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        _pauseFlg = false;

        _pauseUI.SetActive(false);
        _lvUpUI.SetActive(false);
        _pauseArrow.SetActive(false);
        _lvArrow.SetActive(false);

        // �X�N���v�g���擾
        _pauseSelect = _initPause.GetComponent<PauseSelectUI>();
        _skillSelect = _initLV.GetComponent<SkillSelectUI>();
        _drawingSkill = _skillManager.GetComponent<DrawingSkill>();
    }

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (_calledSkill != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == false)
            {
                _calledPause = true;
                Time.timeScale = 0;
                _pauseFlg = true;
                _pauseUI.SetActive(true);
                _pauseArrow.SetActive(true);
                Debug.Log("�|�[�Y�J�n");

                // ���̈ʒu������
                _pauseSelect.InitSelect();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _pauseFlg == true)
            {
                _calledPause = false;
                Time.timeScale = 1;
                _pauseFlg = false;
                _pauseUI.SetActive(false);
                _pauseArrow.SetActive(false);
                Debug.Log("�|�[�Y�I��");
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
        if (_calledPause != true)
        {
            _calledSkill = true;
            _lvUpUI.SetActive(true);
            _lvArrow.SetActive(true);
            Time.timeScale = 0;
            // ���̈ʒu������
            _skillSelect.InitSelect();
            _drawingSkill.DrawingRarity();
        }
    }

    public void PressLVUP()
    {
        if (_calledPause != true)
        {
            _calledSkill = false;
            Time.timeScale = 1;
            _lvUpUI.SetActive(false);
            _lvArrow.SetActive(false);
        }
    }
}