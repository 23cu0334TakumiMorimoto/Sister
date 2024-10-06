using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestATK : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<IsDamaged>().Damage(statusdata.ATK);
            col.gameObject.GetComponent<IsDamaged>().NockBack(statusdata.NockBack);

        }
    }
}
