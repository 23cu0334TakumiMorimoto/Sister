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

    // �����s�\�ɂ���i�����̕b���ԁj
    private IEnumerator ActiveInoperable(float i) 
    {
        // �X�N���v�g�𖳌���
        inputMove.enabled = false;
        inputATK.enabled = false;
        inputChange.enabled = false;

        // �����̕b�������҂�
        yield return new WaitForSeconds(i);

        // �X�N���v�g��L����
        inputMove.enabled = true;
        inputATK.enabled = true;
        inputChange.enabled = true;
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("ActiveInoperable", i); // ���̃X�N���v�g����Ăяo���p
    }
}
