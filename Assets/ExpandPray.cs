using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPray : MonoBehaviour
{
    public float ExpandPower;
    public float ExpandSpeed;
    public float AreaSize;
    public float ExpandLimit;
    public float _destroyTime;
    private float _expandTimer;              //���Ԍv�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _expandTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Z))
        {
            if (ExpandLimit >= AreaSize)
            {
                // ���Ԍv��
                _expandTimer += Time.deltaTime;
                if (_expandTimer > ExpandSpeed)
                {
                    AreaSize += ExpandPower;
                }
            }
        }
            transform.localScale = new Vector3(AreaSize, AreaSize, AreaSize);
        // �F��U����j��
        OnDestroy();
    }

    private void OnDestroy()
    {
        if(Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Z))
        {
            Destroy(gameObject, _destroyTime);
        }
    }
}
