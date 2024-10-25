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

    private float _timer;

    [SerializeField]
    [Header("�j�󂳂�邩�ǂ���")]
    private bool IsDestroy;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
        _rb.velocity = this.transform.position, _playerPos;
        _timer += Time.deltaTime;

        if(_timer > 1 && IsDestroy)
        {
            Destroy(gameObject);
        }
    }
}
