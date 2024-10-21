using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    [Header("�����o���p�̓G�v���n�u")]
    private GameObject EnemyPrefab;//��������p�̓G�L����Prefab��ǂݍ���
    private Vector2 _myPos;
    private Vector2 _enemySpawnPos;   //���������ʒu
    private float _currentTime = 0f;
    [SerializeField]
    [Header("�X�|�[���܂ł̎���(�����o���j")]
    private float SpawnTime;

    [Header("�����o�����邩�ǂ���")]
    public bool IsSpawn;
    [SerializeField]
    [Header("�G���X�|�[��������W�̃����_���͈̔�")]
    public float RandomSpawnMinX;
    public float RandomSpawnMaxX;
    public float RandomSpawnMinY;
    public float RandomSpawnMaxY;
    // �����_���͈̔͂�������ϐ�
    private float RandomSpawnRangeX;
    private float RandomSpawnRangeY;


    //�����_���Ő����������������߂�ϐ�
    public enum SpawnDirection
    {
        DirectionX,//�iX���j
        DirectionY,//�iY���j
    }
    [SerializeField]
    [Header("�ݒ肳��Ă��鐶������")]
    private SpawnDirection _nowSpaenDirection;

    void Start()
    {
        // �W�F�l���[�^�[�̌��݂̍��W���擾����
        _myPos = this.transform.position;
    }
    void Update()
    {
        // �����o��������Ȃ�
        if (IsSpawn == true)
        {
            _currentTime += Time.deltaTime;//���Ԍo�߂�currentTime�ɑ�������Ԃ𑪂�
            if (_currentTime > SpawnTime)//span�Őݒ肵�����Ԃ��z�����珈�������s
            {
                // �W�F�l���[�g����
                EnemyGenerate(EnemyPrefab);
                _currentTime = 0f;
            }
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        // �����_���Ő�������
        RandomSpawnRangeX = Random.Range(RandomSpawnMinX, RandomSpawnMaxX);
        RandomSpawnRangeY = Random.Range(RandomSpawnMinY, RandomSpawnMaxY);

        switch (_nowSpaenDirection)
        {
            case SpawnDirection.DirectionX: // X���Ő�������ꍇ
                _enemySpawnPos.x = RandomSpawnRangeX;
                break;

            case SpawnDirection.DirectionY: // Y���Ő�������ꍇ
                _enemySpawnPos.y = RandomSpawnRangeY;
                break;
        }

        _enemySpawnPos = _enemySpawnPos + _myPos;//�v���C���[�̈ʒu�ɐ�قǂ̗����𑫂����ʒu�ɐ�������
        var enemy = Instantiate(Enemy, _enemySpawnPos, transform.rotation);//Prefab�𐶐�����
        // �ϐ��̏�����                                                                   
        _enemySpawnPos = Vector2.zero;
        //Debug.Log(_enemySpawnPos);
    }

}