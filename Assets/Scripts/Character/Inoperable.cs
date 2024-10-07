using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inoperable : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    TestMover inputMove;
    ATKGenerator inputATK;

    private void Start()
    {
        inputMove = _player.GetComponent<TestMover>();
        inputATK = _player.GetComponent<ATKGenerator>();
    }

    // 操作を不能にする（引数の秒数間）
    private IEnumerator ActiveInoperable(float i) 
    {
        // スクリプトを無効化
        inputMove.enabled = false;
        inputATK.enabled = false;

        // 引数の秒数だけ待つ
        yield return new WaitForSeconds(i);

        // スクリプトを有効化
        inputMove.enabled = true;
        inputATK.enabled = true;
        yield break;
    }

    public void CallInoperable(float i)
    {
        StartCoroutine("ActiveInoperable", i); // 他のスクリプトから呼び出す用
    }
}
