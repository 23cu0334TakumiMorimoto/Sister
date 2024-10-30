using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;
    [SerializeField] private GameObject text6;
    [SerializeField] private GameObject text7;
    [SerializeField] private GameObject text8;
    [SerializeField] private GameObject text9;
    [SerializeField] private GameObject text10;
    [SerializeField] private GameObject text11;

    // ジェネレーターを取得
    [SerializeField] private GameObject _upGene;
    [SerializeField] private GameObject _downGene;
    [SerializeField] private GameObject _leftGene;
    [SerializeField] private GameObject _rightGene;
    private EnemyGenerator _up;
    private EnemyGenerator _down;
    private EnemyGenerator _left;
    private EnemyGenerator _right;

    // 敵プレハブ
    [Header("敵プレハブ")]
    [SerializeField] private GameObject _Enemy1;

    // Start is called before the first frame update
    bool flg1;
    bool flg2;
    bool flg3;
    bool flg4;
    bool flg5;
    bool flg6;
    bool flg7;
    bool flg8;
    bool flg9;
    bool flg10;
    bool flg11;

    float timer;

    PrayGenerator _pray;
    TestMover _move;
    ATKGenerator _atk;
    public GameObject player;

    void Start()
    {
        _up = _upGene.GetComponent<EnemyGenerator>();
        _down = _downGene.GetComponent<EnemyGenerator>();
        _left = _leftGene.GetComponent<EnemyGenerator>();
        _right = _rightGene.GetComponent<EnemyGenerator>();

        _pray = player.GetComponent<PrayGenerator>();
        _move = player.GetComponent<TestMover>();
        _atk = player.GetComponent<ATKGenerator>();
        text1.SetActive(true);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        text7.SetActive(false);
        text8.SetActive(false);
        text9.SetActive(false);
        text10.SetActive(false);
        text11.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TutorialText();
    }

    void TutorialText()
    {
        if (flg1 == false && timer > 3)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Time.timeScale = 1;
                timer = 0;
                flg1 = true;

            }
        }
        if (flg2 == false && timer > 10)
        {
            text2.SetActive(false);
            text3.SetActive(true);
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.K))
            {
                Time.timeScale = 1;
                flg2 = true;
            }
        }
        if (flg3 == false && timer > 15)
        {
            text3.SetActive(false);
            text4.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.J))
            {
                Time.timeScale = 1;
                flg3 = true;
            }
        }
        if (flg4 == false && timer > 20)
        {
            _down.EnemyGenerate(_Enemy1);
            text4.SetActive(false);
            text5.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg4 = true;
            }

        }
        if (flg5 == false && timer > 25)
        {
            text5.SetActive(false);
            text6.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.K))
            {
                Time.timeScale = 1;
                flg5 = true;

            }
        }
        if (flg6 == false && timer > 30)
        {
            text6.SetActive(false);
            text7.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg6 = true;
            }

        }
        if (flg7 == false && timer > 35)
        {
            text7.SetActive(false);
            text8.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg7 = true;
            }
        }
        if (flg8 == false && timer > 40)
        {
            text8.SetActive(false);
            text9.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg8 = true;
            }

        }
        if (flg9 == false && timer > 45)
        {
            text9.SetActive(false);
            text10.SetActive(true);
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg9 = true;
            }

        }
        if (flg10 == false && timer > 50)
        {
            text10.SetActive(false);
            text11.SetActive(true);
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                flg10 = true;
            }
        }

    }
}
