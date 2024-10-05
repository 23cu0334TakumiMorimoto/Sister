using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGeneratorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyPrefab;//��������p�̓G�L����Prefab��ǂݍ���
    private GameObject Player;
    private Vector2 PlayerPos;//�L�����N�^�[�̈ʒu��������ϐ�
    private Vector2 _enemySpawnPos;   //���������ʒu
    private float _currentTime = 0f;
    [SerializeField]
    [Header("�X�|�[���܂ł̎���")]
    public float SpawnTime;
    //[SerializeField]
    //[Header("�G���X�|�[��������W�̃����_���͈̔�")]
    //public float RandomSpawnRangeX = Random.Range(1.0f, 3.0f);
    //public float RandomSpawnRangeY = Random.Range(1.0f, 3.0f);

    // �ݒ肳��Ă��鐶������
    private SpawnDirection _nowSpaenDirection;
    //�����_���Ő����������������߂�ϐ�
    public enum SpawnDirection
    {
        DirectionX,//�iX���j
        DirectionY,//�iY���j
    }
   
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//Player�Ƃ����^�O���������A���������I�u�W�F�N�g��������
    }
    void Update()
    {
        _currentTime += Time.deltaTime;//���Ԍo�߂�currentTime�ɑ�������Ԃ𑪂�
        if (_currentTime > SpawnTime)//span�Őݒ肵��3�b���z�����珈�������s
        {
            EnemyGenerate(EnemyPrefab);
            _currentTime = 0f;
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        //EnemyPrefab�̃X�|�[���ʒu�����߂�
        //PlayerPos = Player.transform.position;//Player�̌��݈ʒu���擾

        //�㉺�ǂ���ɃX�|�[�����邩
        //rndUD = Random.Range(0, 2);//0:�� 1:��
        //                           //���E�ǂ���ɂȂ邩
        //rndLR = Random.Range(0, 2);//0:�� 1:�E

        //    switch(_nowSpaenDirection)
        //    {
        //        case SpawnDirection.DirectionX: // X���Ő�������ꍇ
        //            _enemySpawnPos.
        //    }


        //    switch (rndUD)
        //    {
        //        case 0://rndUD����̏ꍇ
        //            enemyspwnPos.y = rndPositiveY;//������̗�������

        //            break;
        //        case 1://rndUD�����̏ꍇ
        //            enemyspwnPos.y = rndNegativeY;//�������̗�������
        //            break;
        //    }

        //    switch (rndLR)
        //    {
        //        case 0://rndLR�����̏ꍇ
        //            enemyspwnPos.x = rndPositiveX;//�������̗�������
        //            break;
        //        case 1://rndLR���E�̏ꍇ
        //            enemyspwnPos.x = rndNegativeX;//�E�����̗�������
        //            break;
        //    }

        //    enemyspwnPos = enemyspwnPos + PlayerPos;//�v���C���[�̈ʒu�ɐ�قǂ̗����𑫂����ʒu�ɐ�������
        //    var enemy = Instantiate(Enemy, enemyspwnPos, transform.rotation);//Prefab�𐶐�����
    }

}