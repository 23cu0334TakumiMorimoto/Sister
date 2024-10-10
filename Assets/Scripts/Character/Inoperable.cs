using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inoperable : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    // �R���|�[�l���g�擾�p
    TestMover inputMove;
    ATKGenerator inputATK;
    PlayerChange inputChange;

    private void Start()
    {
        inputMove = _player.GetComponent<TestMover>();
        inputATK = _player.GetComponent<ATKGenerator>();
        inputChange = _player.GetComponent<PlayerChange>();
    }

    // ����E�U���E�ϐg��s�\�ɂ���i�����̕b���ԁj
    private IEnumerator MoveActiveInoperable(float i) 
    {
        // �X�N���v�g�𖳌���
        inputMove.enabled = false;

        // �����̕b�������҂�
        yield return new WaitForSeconds(i);

        // �X�N���v�g��L����
        inputMove.enabled = true;
        yield break;
    }

    private IEnumerator AttackActiveInoperable(float i)
    {
        // �X�N���v�g�𖳌���
        inputATK.enabled = false;

        // �����̕b�������҂�
        yield return new WaitForSeconds(i);

        // �X�N���v�g��L����
        inputATK.enabled = true;
        yield break;
    }

    private IEnumerator ChangeActiveInoperable(float i)
    {
        // �X�N���v�g�𖳌���
        inputChange.enabled = false;

        // �����̕b�������҂�
        yield return new WaitForSeconds(i);

        // �X�N���v�g��L����
        inputChange.enabled = true;
        yield break;
    }

    // �������͌Ăяo���R���[�`��
    // 0: All 1:Move��Attack 2:Move�̂�
    public void CallInoperable(float i,int num)
    {
        if(num == 0)
        {
            StartCoroutine("MoveActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
            StartCoroutine("AttackActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
            StartCoroutine("ChangeActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
        }

        else if (num == 1)
        {
            StartCoroutine("MoveActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
            StartCoroutine("AttackActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
        }

        else if (num == 2)
        {
            StartCoroutine("MoveActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
        }

    }
}
