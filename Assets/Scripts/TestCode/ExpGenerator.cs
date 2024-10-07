using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGenerator : MonoBehaviour
{
    [SerializeField] 
    private GameObject EXP_prefab;
    [SerializeField]
    private GameObject _enemy;
    private IsDamaged damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = _enemy.GetComponent<IsDamaged>(); // スクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        var exp = Instantiate(EXP_prefab, transform.position, transform.rotation);
    }
}
