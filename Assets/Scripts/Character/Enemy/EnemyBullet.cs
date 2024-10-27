using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    [Header("�e�̑��x")]
    private float _speed;

    private Rigidbody2D _rb;

    // �v���C���[�̈ʒu���擾
    private GameObject _player;
    private Vector3 _playerPos;

    // ���ˊp�x
    private float angle;

    private float _timer;

    [SerializeField]
    [Header("�j�󂳂�邩�ǂ���")]
    private bool IsDestroy;

    private float rotateX, rotateY, rotateZ;
    private float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;

        ////  ���ˊp�x�����߂�
        //float angle = GetAngle(gameObject.transform.position, _playerPos);

        _rb.AddForce(_playerPos.normalized - transform.position.normalized * _speed,ForceMode2D.Impulse);
        ////���[�^�[��Z���̐��l���{�[����X���̊p�x�ցB-1������ƒ��x�ǂ���ɂȂ�
        //transform.rotation = Quaternion.Euler(angle * -1, 0, 0);

        rotateX = 0;
        rotateY = 0;
        rotateZ = 30;
        _rotateSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > 5 && IsDestroy != true)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        ////���[�^�[��Z���̐��l���{�[����X���̊p�x�ցB-1������ƒ��x�ǂ���ɂȂ�
        //transform.rotation = Quaternion.Euler(angle * -1, 0, 0);

        // ��]��������B
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime * _rotateSpeed);
    }

    private void OnTriggrEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "God")
        {
            Destroy(gameObject);
        }
    }

    //    float GetAngle(Vector2 start, Vector2 target)
    //{
    //    Vector2 dt = target - start;
    //    float rad = Mathf.Atan2(dt.y, dt.x);
    //    float degree = rad * Mathf.Rad2Deg;

    //    return degree;
    //}
}
