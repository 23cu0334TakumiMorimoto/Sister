using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inoperable : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    // コンポーネント取得用
    TestMover inputMove;
    ATKGenerator inputATK;
    PlayerChange inputChange;

    private void Start()
    {
        inputMove = _player.GetComponent<TestMover>();
        inputATK = _player.GetComponent<ATKGenerator>();
        inputChange = _player.GetComponent<PlayerChange>();
    }

    // 操作・攻撃・変身を不能にする（引数の秒数間）
    private IEnumerator MoveActiveInoperable(float i) 
    {
        // スクリプトを無効化
        inputMove.enabled = false;

        // 引数の秒数だけ待つ
        yield return new WaitForSeconds(i);

        // スクリプトを有効化
        inputMove.enabled = true;
        yield break;
    }

    private IEnumerator AttackActiveInoperable(float i)
    {
        // スクリプトを無効化
        inputATK.enabled = false;

        // 引数の秒数だけ待つ
        yield return new WaitForSeconds(i);

        // スクリプトを有効化
        inputATK.enabled = true;
        yield break;
    }

    private IEnumerator ChangeActiveInoperable(float i)
    {
        // スクリプトを無効化
        inputChange.enabled = false;

        // 引数の秒数だけ待つ
        yield return new WaitForSeconds(i);

        // スクリプトを有効化
        inputChange.enabled = true;
        yield break;
    }

    // 第二引数は呼び出すコルーチン
    // 0: All 1:MoveとAttack 2:Moveのみ
    public void CallInoperable(float i,int num)
    {
        if(num == 0)
        {
            StartCoroutine("MoveActiveInoperable", i); // 他のスクリプトから呼び出す用
            StartCoroutine("AttackActiveInoperable", i); // 他のスクリプトから呼び出す用
            StartCoroutine("ChangeActiveInoperable", i); // 他のスクリプトから呼び出す用
        }

        else if (num == 1)
        {
            StartCoroutine("MoveActiveInoperable", i); // 他のスクリプトから呼び出す用
            StartCoroutine("AttackActiveInoperable", i); // 他のスクリプトから呼び出す用
        }

        else if (num == 2)
        {
            StartCoroutine("MoveActiveInoperable", i); // 他のスクリプトから呼び出す用
        }

    }
}
