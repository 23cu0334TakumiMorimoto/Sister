using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAttack : MonoBehaviour
{
    // �X�e�[�^�X�f�[�^��ǂݍ���
    [SerializeField]
    public StatusData statusdata;

    // �G�̎��
    private enum _movement
    {
        Bat,
        Goat
    }
    [SerializeField] _movement EnemyMove;    //�v���_�E����

    // ���S�󋵂��擾
    public GameObject Enemy;
    private IsDamaged Dead;

    //// �v���C���[�̈ʒu���擾
    //private GameObject _player;
    //private Vector3 _playerPos;

    [SerializeField]
    [Header("���M�̍U���e")]
    private GameObject _bulletGoat;
    private float _bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        Dead = Enemy.GetComponent<IsDamaged>();
        //_player = GameObject.FindGameObjectWithTag("Player");
        //_playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTimer += Time.deltaTime;
        // �R�E����
        if (EnemyMove == _movement.Goat)
        {
            DevilGoat();
        }
    }

    private void DevilGoat()
    {
        // ������Ԃł͂Ȃ��Ȃ珈��
        if (Dead.IsDead == false)
        {
            if(_bulletTimer > statusdata.ATK_Interval)
            {
                Instantiate(_bulletGoat, transform.position, Quaternion.identity);
                _bulletTimer = 0;
            }
        }
    }
}
