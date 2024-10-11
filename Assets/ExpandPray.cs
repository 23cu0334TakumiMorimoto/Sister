using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPray : MonoBehaviour
{
    [SerializeField] PlayerData statusdata;
    public float ExpandPower;
    public float ExpandSpeed;
    public float AreaSize;
    public float ExpandLimit;
    public float _destroyTime;
    private float _expandTimer;              //���Ԍv�����邽�߂̕ϐ�

    // �v���C���[�̈ʒu���擾
    private GameObject _player;
    private Transform _pray;

    GameObject gameManagerObj;
    Inoperable IPrayed;

    // Start is called before the first frame update
    void Start()
    {
        _expandTimer = 0;
        _player = GameObject.FindGameObjectWithTag("Player");
        gameManagerObj = GameObject.Find("GameManager");
        IPrayed = gameManagerObj.GetComponent<Inoperable>(); // �X�N���v�g���擾
        _pray = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z))
        {
            // �w�肳�ꂽ���ԃv���C���[����𖳌��ɂ���
            IPrayed.CallInoperable(_expandTimer, 2);

            if (ExpandLimit >= AreaSize)
            {
                // ���Ԍv��
                _expandTimer += Time.deltaTime;
                if (_expandTimer > ExpandSpeed)
                {
                    AreaSize += ExpandPower;
                }
            }
        }
            transform.localScale = new Vector3(AreaSize, AreaSize, AreaSize);
    }

    private void FixedUpdate()
    {
        _pray.position = _player.transform.position;
    }
}
